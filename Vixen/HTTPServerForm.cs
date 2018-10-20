using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VixenPlus
{
    public partial class HTTPServerForm : Form
    {
        static VixenHTTPServer server = null;

        public HTTPServerForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            server = new VixenHTTPServer();
            server.start();
            updateStatus("Server Started");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            server.stop();
            server = null;
            updateStatus("Server Stopped.");
        }

        public void updateStatus(String msg)
        {
            textBoxStatus.Text += msg + Environment.NewLine;
        }
    }
}
