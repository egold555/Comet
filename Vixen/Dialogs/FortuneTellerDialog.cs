using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.Windows.Forms;
using System.Windows.Input;
using VixenPlusCommon;
using System.IO;

namespace VixenPlus.Dialogs
{
    public partial class FortuneTellerDialog : Form
    {

        bool modeRandom = false;
        int currentObject = 0;
        AutoPlay.AutoPlaySequence currentSequence;

        Random random = new Random();

        public FortuneTellerDialog()
        {
            InitializeComponent();
        }

        private void textBoxKey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            textBoxKey.Text = e.KeyCode.ToString();
        }

        private void buttonAddSequence_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = FileIOHelper.GetOpenFilters();
            openFileDialog1.InitialDirectory = Paths.SequencePath;
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            listBoxSequences.Items.Add(Path.GetFullPath(openFileDialog1.FileName));
        }

        private void buttonRemoveSequence_Click(object sender, EventArgs e)
        {
            listBoxSequences.Items.RemoveAt(listBoxSequences.SelectedIndex);
        }

        private void checkBoxRandom_CheckedChanged(object sender, EventArgs e)
        {
            modeRandom = checkBoxRandom.Checked;
        }

        private String getNextSequence()
        {
            if (modeRandom) {
                return (String)listBoxSequences.Items[random.Next(listBoxSequences.Items.Count)];
            }
            else {
                String toReturn = (String) listBoxSequences.Items[currentObject];
                currentObject++;
                if(currentObject >= listBoxSequences.Items.Count) {
                    currentObject = 0;
                }
                return toReturn;
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            playSequence();
        }

        private void playSequence()
        {
            if (currentSequence == null || !currentSequence.IsPlaying) {
                currentSequence = new AutoPlay.AutoPlaySequence(getNextSequence());
                currentSequence.Play();
            }
            
        }

        private void textBoxDetection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == textBoxKey.Text) {
                playSequence();
            }
            e.SuppressKeyPress = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            currentSequence.Stop(true);
            currentSequence = null;
        }
    }
}
