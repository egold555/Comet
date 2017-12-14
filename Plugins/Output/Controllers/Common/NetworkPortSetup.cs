using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Controllers.Common
{
    public partial class NetworkPortSetup : UserControl
    {
        public NetworkPortSetup()
        {
            InitializeComponent();
        }

        public string HostName {
            get { return textBoxHostName.Text; }
            set { textBoxHostName.Text = value; }
        }

        public int PortNumber {
            get {
                int port = 0;
                int.TryParse(textBoxPortNumber.Text, out port);
                return port;
            }
            set {
                textBoxPortNumber.Text = value.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
