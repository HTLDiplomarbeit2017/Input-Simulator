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
    public partial class MainForm : Form
    {

        private Manager server;
        private List<ClientShow> clientForms = new List<ClientShow>();
        public MainForm()
        {
            InitializeComponent();
            server = new Manager(4);
            server.ClientChange += Server_ClientChange;
            server.ClientConnected += Server_ClientConnected;
            dataConnections.CellDoubleClick += DataConnections_CellDoubleClick;

        }

        private void Server_ClientConnected(object sender, EventArgs e)
        {
            RefreshList();
            
        }
        private void RefreshList()
        {

            dataConnections.Rows.Clear();
            foreach (Client client in server.clients)
            {
                dataConnections.Rows.Add(new object[] { client.name, client.status, client.client_ip });
            }

        }

        private void DataConnections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Client clicked_c = server.clients[e.RowIndex];
            ClientShow show = new ClientShow(clicked_c);
            show.Show(this);
            clientForms.Add(show);
        }

        private void Server_ClientChange(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            server.log.Debug("Showing log window..");
            using(LogDisplay form=new LogDisplay(server.log))
            {
                Cursor.Position = this.PointToScreen(new Point(this.Width / 2, -10));
                form.ShowDialog(this);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            
        }

        private void Input_XBOX_Button_Up(object sender, Input.XBOXPressedEventArgs e)
        {
            switch (e.pressed)
            {
                case XBOXButton.A:
                    checkBoxA.Checked = false;
                    break;
            }
        }

        private void Input_XBOX_Button_Down(object sender, Input.XBOXPressedEventArgs e)
        {
            switch (e.pressed)
            {
                case XBOXButton.A:
                    checkBoxA.Checked = true;
                    break;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            server.Start();
        }
    }
}
