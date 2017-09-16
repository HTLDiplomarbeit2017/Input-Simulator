using ControllerServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsInputEmulator
{
    public partial class ClientShow : Form
    {
        private Client client;
        public ClientShow(Client client)
        {
            InitializeComponent();
            this.client = client;
            this.client.ClientStatusChanged += Client_ClientStatusChanged;

            this.client.input.XBOX_Input_Changed += Input_XBOX_Input_Changed;
            labelStatus.Text = client.status.ToString();
        }

        private void Input_XBOX_Input_Changed(object sender, Input.XBOXChangedEventArgs e)
        {
            dataInput.Rows.Clear();
            foreach (XBOXButton button in e.pressed)
            {
                dataInput.Rows.Add(new object[] { button.ToString() });
            }
        }

        private void Client_ClientStatusChanged(object sender, EventArgs e)
        {
            labelStatus.Text = client.status.ToString();
        }
    }
}
