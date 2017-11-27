using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VixenPlus.Dialogs
{
    public partial class AutoPlayStatus : Form
    {
        bool stopRequested = false;

        public AutoPlayStatus()
        {
            InitializeComponent();
        }

        public void UpdateCurrentSequence(string name)
        {
            this.currentSequenceLabel.Text = name;
        }

        public bool StopRequested { get { return stopRequested; } }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopRequested = true;
        }
    }
}
