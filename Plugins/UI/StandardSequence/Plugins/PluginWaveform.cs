using FMOD;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using VixenPlus;
using VixenPlusCommon;

namespace VixenEditor.Plugins
{
    public partial class PluginWaveform : Form
    {

        private bool m_completed = false;
        public bool Completed
        {
            get {
                return this.m_completed;
            }
        }

        public PluginWaveform(EventSequence sequence)
        {
            InitializeComponent();
            label1.Text = "Name: " + sequence.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.m_completed = true;
            MessageBox.Show("Done.", "Comet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            base.Close();
        }
    }
}
