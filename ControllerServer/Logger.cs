using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerServer
{
    public class Logger
    {
        public class Message
        {
            public enum Status
            {
                Error, Warning, Debug
            }
            public Status s { private set; get; }
            public string message { private set; get; }

            public DateTime time { private set; get; }
            public Message(string message) : this(message, Status.Debug)
            {
            }
            public Message(string message, Status s)
            {
                this.s = s;
                this.message = message;
                this.time = DateTime.Now;
            }

        }
        private static Logger _l;
        private List<Message> _messages = new List<Message>();
        public event EventHandler newMessage;
        Logger l
        {
            get
            {
                if (_l == null)
                {
                    _l = new Logger();
                }

                return _l;
            }
        }
        public Message[] messages
        {
            get
            {
                Message[] m = new Message[_messages.Count];
                _messages.CopyTo(m);
                return m;
            }
        }
        public void Log(string message, Message.Status status)
        {
            _messages.Add(new Message(message, status));
            newMessage?.Invoke(this, EventArgs.Empty);
        }
        public void Error(string message)
        {
            Log(message, Message.Status.Error);
        }
        public void Debug(string message)
        {
            Log(message, Message.Status.Debug);
        }
        public void Warning(string message)
        {
            Log(message, Message.Status.Warning);
        }
    }
}
