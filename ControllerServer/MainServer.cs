using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerServer
{
    public class MainServer
    {
        private int port_login = 25920;
        private UdpClient server_login;
        public Input input;
        public Logger log { private set; get; }
        public delegate SendPayload ReceieveData(string data, byte[] raw_data, IPEndPoint ip);
        public event ReceieveData recieveData;
        private List<Task> currentlyRunning = new List<Task>();
        public MainServer()
        {

            log = new Logger();
        }
        public void Start()
        {
            server_login = new UdpClient(port_login);
            server_login.BeginReceive(new AsyncCallback(ProcessData), null);

            log.Debug("Started!");
        }
        private void ProcessData(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8000);
            byte[] received = server_login.EndReceive(res, ref RemoteIpEndPoint);
            server_login.BeginReceive(new AsyncCallback(ProcessData), null);
            ProcessString(Encoding.ASCII.GetString(received),received,RemoteIpEndPoint);


        }
        
        private void ProcessString(string text, byte[] raw_data, IPEndPoint ip)
        {
            
            log.Debug(text);
            SendPayload toSend = recieveData?.Invoke(text, raw_data, ip);
            Task sendTask = Task.Factory.StartNew((object dataSend) =>
            {
                SendPayload payload = dataSend as SendPayload;
                byte[] data_b = Encoding.ASCII.GetBytes(payload.data);
                server_login.Send(data_b, data_b.Length, payload.client.client_ip);
            },toSend);
        }
    }
    public class SendPayload
    {
        public string data;
        public Client client;
    }
}
