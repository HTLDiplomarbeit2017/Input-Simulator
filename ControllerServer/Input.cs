using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerServer
{
    public class Input
    {
        public Input() : this(null,null)
        {

        }
        public Input(Client client) : this(null, client)
        {

        }
        public Input(Manager manager,Client client)
        {
            this.manager = manager;
            this.client = client;
        }
        private Client client;
        private Manager manager;
        public class XBOXChangedEventArgs : EventArgs
        {
            public List<XBOXButton> pressed = new List<XBOXButton>();
            public Client client;
        }
        public class XBOXPressedEventArgs : EventArgs
        {
            public XBOXButton pressed;
            public Client client;
        }
        public delegate void XBOXChangedEventHandler(object sender, XBOXChangedEventArgs e);
        public event XBOXChangedEventHandler XBOX_Input_Changed;

        public delegate void XBOXPressedEventHandler(object sender, XBOXPressedEventArgs e);
        public event XBOXPressedEventHandler XBOX_Button_Down;
        public event XBOXPressedEventHandler XBOX_Button_Up;
        private List<XBOXButton> pressed_x = new List<XBOXButton>();
        public void analyzeMessage(string data, byte[] raw_data)
        {
            if (data.StartsWith("x"))
            {
                bool changedXBOX = false;
                short[] data_b = new short[] { (short)raw_data[1], (short)raw_data[2] };
                int data_i = (data_b[0] << 8) + data_b[1];

                manager?.log.Debug("Input:" + Convert.ToString(data_b[0], 2).PadLeft(8, '0') + Convert.ToString(data_b[1], 2).PadLeft(8, '0') + "=" + data_i);

                foreach (XBOXButton button in Enum.GetValues(typeof(XBOXButton)))
                {
                    if (((1 << (int)button) & data_i) > 0)
                    {
                        if (!pressed_x.Contains(button))
                        {
                            //XBOX_Button_Down?.Invoke(this, new XBOXPressedEventArgs() { pressed = button });
                            RaiseEventOnUIThread(XBOX_Button_Down, this, new XBOXPressedEventArgs() { pressed = button ,client=this.client});
                            if (!changedXBOX)
                            {
                                changedXBOX = true;
                            }
                            pressed_x.Add(button);
                        }
                    }
                    else
                    {
                        if (pressed_x.Contains(button))
                        {
                            //XBOX_Button_Up?.Invoke(this, new XBOXPressedEventArgs() { pressed = button });
                            RaiseEventOnUIThread(XBOX_Button_Up, this, new XBOXPressedEventArgs() { pressed = button, client = this.client });
                            if (!changedXBOX)
                            {
                                changedXBOX = true;
                            }
                            pressed_x.Remove(button);
                        }
                    }
                }
                if (changedXBOX)
                {

                    RaiseEventOnUIThread(XBOX_Input_Changed, this, new XBOXChangedEventArgs() { pressed = pressed_x, client = this.client });
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        //https://stackoverflow.com/questions/1698889/raise-events-in-net-on-the-main-ui-thread
        private void RaiseEventOnUIThread(XBOXChangedEventHandler theEvent, object sender, XBOXChangedEventArgs args)
        {
            if (theEvent!=null)
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
        private void RaiseEventOnUIThread(XBOXPressedEventHandler theEvent, object sender, XBOXPressedEventArgs args)
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
