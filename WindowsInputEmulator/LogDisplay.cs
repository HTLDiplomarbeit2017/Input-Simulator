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
    public partial class LogDisplay : Form
    {
        private Logger logger;
        private System.Timers.Timer logRefresh = new System.Timers.Timer(500);
        public LogDisplay(Logger logger)
        {
            this.logger = logger;
            InitializeComponent();

            dataLog.DataSource = logger.messages;
            logRefresh.Elapsed += async (sender, e) => await new Task(()=>
            {
                dataLog.DataSource = logger.messages;
            });
            logRefresh.Start();
        }
        

        private void buttonCopy_Click(object sender, EventArgs e)
        {

        }
    }
}
