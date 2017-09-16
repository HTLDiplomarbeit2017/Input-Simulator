using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerServer
{
    public class Client
    {
        public IPEndPoint client_ip { private set; get; }
        public event EventHandler ClientStatusChanged;
        private ClientStatus _status;
        private Manager manager;
        private Task timeOut;
        private readonly int maxTime = 5000;
        private CancellationTokenSource cancelTokenSrc = new CancellationTokenSource();
        private CancellationToken cancelToken;
        public Input input;
        public ClientStatus status
        {
            set
            {
                if (status == ClientStatus.LOGGED_IN)
                {
                    resetTimer();
                }
                ClientStatusChanged?.Invoke(this, EventArgs.Empty);
                _status = value;

            }
            get
            {
                return _status;
            }
        }
        public enum ClientStatus
        {
            CONNECTING, LOGGING_IN, PASSWORD_REQUESTED, LOGGED_IN, CONNECTION_LOST
        }
        public string name { get; private set; }
        public Client(Manager manager, IPEndPoint ip, string name)
        {
            this.name = name;
            this.client_ip = ip;
            this.status = ClientStatus.CONNECTING;
            this.manager = manager;
            this.input = new Input(manager, this);
        }
        public Client(Manager mananger, IPEndPoint ip) : this(mananger, ip, "PLAYER")
        {

        }
        public void sentName(string name)
        {
            status = ClientStatus.LOGGING_IN;
            this.name = name;

        }
        public void resetTimer()
        {
            if (timeOut != null&&cancelToken!=null)
            {
                cancelTokenSrc.Cancel();
                
            }
            cancelToken = cancelTokenSrc.Token;
            timeOut = Task.Run(() =>
            {
                Task.Delay(maxTime, cancelToken).Wait();
                status = ClientStatus.CONNECTION_LOST;
            }, cancelToken);
        }
    }
}
