using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControllerServer
{
    public class Manager
    {
        private static class ServerPhrases
        {
            public const string PASS_REQ = "pass req";
            public const string LOGIN_SUCCESSFUL = "login successful";
            public const string SERVER_FULL = "server full";
            public const string BANNED = "client banned";

        }
        private MainServer server;
        private string _password;
        public List<Client> clients = new List<Client>();
        private List<IPEndPoint> bannedEndPoints = new List<IPEndPoint>();
        public event EventHandler ClientConnected;
        public event EventHandler ClientChange;
        public int maxClients { private set; get; }
        public bool requirePass
        {
            get
            {
                return password != null && password.Length > 0;
            }
        }
        public string password
        {
            set
            {
                PasswordChanged?.Invoke(this, EventArgs.Empty);
                _password = value;
            }
            get
            {
                return _password;
            }
        }
        public event EventHandler PasswordChanged;
        public Logger log
        {
            get
            {
                return server.log;
            }
        }
        public Manager(int maxClients)
        {
            server = new MainServer();
            server.recieveData += Server_recieveData;
            this.maxClients = maxClients;
        }
        

        private SendPayload Server_recieveData(string data, byte[] raw_data, IPEndPoint ip)
        {
            //Search with LINQ for matching IP+socket
            Client client = clients.FirstOrDefault(i => i.client_ip.Equals(ip));
            SendPayload payload = new SendPayload();
            payload.client = client;
            if (client == null)
            {

                client = new Client(this, ip);
                client.ClientStatusChanged += Client_ClientStatusChanged;
                payload.client = client;
                if (clients.Count == maxClients)
                {
                    payload.data = ServerPhrases.SERVER_FULL;
                    return payload;
                }
                if (bannedEndPoints.Contains(ip))
                {
                    payload.data = ServerPhrases.BANNED;
                    return payload;
                }
                else
                {
                    clients.Add(client);
                    RaiseEventOnUIThread(ClientConnected, this, EventArgs.Empty);
                }
            }
            client.resetTimer();
            switch (client.status)
            {
                case Client.ClientStatus.CONNECTING:
                    if (data.StartsWith("login "))
                    {
                        client.sentName(data.Substring(data.IndexOf(' ')));
                        if (requirePass)
                        {
                            client.status = Client.ClientStatus.PASSWORD_REQUESTED;
                            payload.data = ServerPhrases.PASS_REQ;
                            return payload;
                        }
                        else
                        {

                            client.status = Client.ClientStatus.LOGGED_IN;
                            payload.data = ServerPhrases.LOGIN_SUCCESSFUL;

                            return payload;
                        }
                    }
                    else
                    {
                        log.Warning("Client with IP " + ip + " not using standard Protocol!");
                        bannedEndPoints.Add(ip);
                        clients.Remove(client);
                    }
                    break;
                case Client.ClientStatus.PASSWORD_REQUESTED:
                    if (data.StartsWith("password "))
                    {
                        string passwordSent = data.Substring(data.IndexOf(' '));
                        if (password != this.password)
                        {
                            client.status = Client.ClientStatus.PASSWORD_REQUESTED;
                            payload.data = ServerPhrases.PASS_REQ;
                            return payload;
                        }
                        else
                        {
                            client.status = Client.ClientStatus.LOGGED_IN;
                            payload.data = ServerPhrases.LOGIN_SUCCESSFUL;
                            return payload;
                        }
                    }
                    else
                    {
                        log.Warning("Client with IP " + ip + " not using standard Protocol!");
                        bannedEndPoints.Add(ip);
                        clients.Remove(client);
                    }
                    break;
                case Client.ClientStatus.LOGGED_IN:
                    client.input.analyzeMessage(data, raw_data);
                    break;
            }
            payload.data = "" + ((char)3);
            return payload;

        }

        private void Client_ClientStatusChanged(object sender, EventArgs e)
        {
            RaiseEventOnUIThread(ClientChange, this, EventArgs.Empty);
        }

        public void Start()
        {
            server.Start();
        }
        private void RaiseEventOnUIThread(EventHandler theEvent, object sender, EventArgs args)
        {
            if (theEvent != null)
            {
                foreach (Delegate d in theEvent.GetInvocationList())
                {
                    ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
                    if (syncer == null)
                    {
                        d.DynamicInvoke(args);
                    }
                    else
                    {
                        syncer.BeginInvoke(d, new[] { sender, args });  // cleanup omitted
                    }
                }
            }
        }
    }
}
