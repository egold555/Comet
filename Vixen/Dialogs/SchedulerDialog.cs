using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using Action = Microsoft.Win32.TaskScheduler.Action;
using VixenPlusCommon;

namespace VixenPlus.Dialogs
{
    public partial class SchedulerDialog : Form
    {
        TaskService taskService;
        List<ScheduledProgram> programList = new List<ScheduledProgram>();

        public SchedulerDialog()
        {
            InitializeComponent();

            taskService = TaskService.Instance;

            UpdateProgramList();
            UpdateButtons();

            if (programList.Count > 0)
                listBoxPrograms.SelectedIndex = 0;
            else
                DefaultProgramSettings();
        }

        private void UpdateProgramList()
        {
            GetProgramList();
            listBoxPrograms.Items.Clear();
            foreach (ScheduledProgram program in programList) {
                listBoxPrograms.Items.Add(program);
            }
        }

        private void GetProgramList()
        {
            programList.Clear();
            TaskFolder folder = taskService.RootFolder.CreateFolder("Comet", null, false);
            if (folder == null)
                return;

            foreach (Task t in folder.AllTasks) {
                programList.Add(ScheduledProgramFromTask(t));
            }
        }

        bool ProgramListContains(string name)
        {
            return programList.Exists(p => string.Equals(p.name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        private void UpdateButtons()
        {
            if (textBoxName.Text.Length > 0 && 
                listBoxSequences.Items.Count > 0 && 
                (checkBoxMon.Checked || checkBoxTue.Checked || checkBoxWed.Checked || checkBoxThu.Checked || checkBoxFri.Checked || checkBoxSat.Checked || checkBoxSun.Checked)) 
            {
                buttonUpdateProgram.Enabled = true;
            }
            else {
                buttonUpdateProgram.Enabled = false;
            }

            buttonRemoveSequence.Enabled = (listBoxSequences.SelectedItem != null);
            buttonRemoveProgram.Enabled = (listBoxPrograms.SelectedItem != null);

            if (ProgramListContains(textBoxName.Text))
                buttonUpdateProgram.Text = "Update Program";
            else
                buttonUpdateProgram.Text = "Add Program";
        }

        private void DefaultProgramSettings()
        {
            string name = "Program1";
            for (int i = 1; i < 9999; ++i) {
                name = "Program" + i;
                if (!ProgramListContains(name))
                    break;
            }
            textBoxName.Text = name;
            timePickerStart.Value = new DateTime(1970, 1, 1, 18, 0, 0);
            timePickerStop.Value = new DateTime(1970, 1, 1, 19, 0, 0);
            dateTimePickerFirstDay.Value = DateTime.Now;
            dateTimePickerLastDay.Value = DateTime.Now.AddYears(1);
            checkBoxMon.Checked = checkBoxTue.Checked = checkBoxWed.Checked = checkBoxThu.Checked = checkBoxFri.Checked = checkBoxSat.Checked = checkBoxSun.Checked = true;
            listBoxSequences.Items.Clear();
        }

        private ScheduledProgram ScheduledProgramFromDialog()
        {
            ScheduledProgram program = new ScheduledProgram();

            program.name = this.textBoxName.Text;
            program.startTime = this.timePickerStart.Value.TimeOfDay;
            program.endTime = this.timePickerStop.Value.TimeOfDay;
            program.firstDate = this.dateTimePickerFirstDay.Value;
            program.lastDate = this.dateTimePickerLastDay.Value;
            program.weekDays = (this.checkBoxMon.Checked ? DaysOfTheWeek.Monday : 0) |
                                (this.checkBoxTue.Checked ? DaysOfTheWeek.Tuesday : 0) |
                                (this.checkBoxWed.Checked ? DaysOfTheWeek.Wednesday : 0) |
                                (this.checkBoxThu.Checked ? DaysOfTheWeek.Thursday : 0) |
                                (this.checkBoxFri.Checked ? DaysOfTheWeek.Friday : 0) |
                                (this.checkBoxSat.Checked ? DaysOfTheWeek.Saturday : 0) |
                                (this.checkBoxSun.Checked ? DaysOfTheWeek.Sunday : 0);
            program.sequences = Enumerable.Cast<string>(this.listBoxSequences.Items).ToList();

            return program;
        }

        private void DialogFromScheduledProgram(ScheduledProgram program)
        {
            this.textBoxName.Text = program.name;
            this.timePickerStart.Value = DateTime.Now.Date + program.startTime;
            this.timePickerStop.Value = DateTime.Now.Date + program.endTime;
            this.dateTimePickerFirstDay.Value = program.firstDate;
            this.dateTimePickerLastDay.Value = program.lastDate;
            this.checkBoxMon.Checked = (program.weekDays & DaysOfTheWeek.Monday) != 0;
            this.checkBoxTue.Checked = (program.weekDays & DaysOfTheWeek.Tuesday) != 0;
            this.checkBoxWed.Checked = (program.weekDays & DaysOfTheWeek.Wednesday) != 0;
            this.checkBoxThu.Checked = (program.weekDays & DaysOfTheWeek.Thursday) != 0;
            this.checkBoxFri.Checked = (program.weekDays & DaysOfTheWeek.Friday) != 0;
            this.checkBoxSat.Checked = (program.weekDays & DaysOfTheWeek.Saturday) != 0;
            this.checkBoxSun.Checked = (program.weekDays & DaysOfTheWeek.Sunday) != 0;
            this.listBoxSequences.Items.Clear();
            this.listBoxSequences.Items.AddRange(program.sequences.ToArray());
        }

        private ScheduledProgram ScheduledProgramFromTask(Task task)
        {
            WeeklyTrigger trigger = task.Definition.Triggers.Where(trig => trig is WeeklyTrigger).Cast<WeeklyTrigger>().FirstOrDefault();
            ExecAction action = task.Definition.Actions.Where(a => a is ExecAction).Cast<ExecAction>().FirstOrDefault();

            if (trigger == null || action == null)
                return null;

            ScheduledProgram program = new ScheduledProgram();

            if (task.Name.StartsWith("Comet\\"))
                program.name = task.Name.Substring("Comet\\".Length);
            else
                program.name = task.Name;

            program.weekDays = trigger.DaysOfWeek;
            program.startTime = trigger.StartBoundary.TimeOfDay;
            program.endTime = trigger.EndBoundary.TimeOfDay;
            program.firstDate = trigger.StartBoundary.Date;
            program.lastDate = trigger.EndBoundary.Date;

            CommandLineOptions options = AutoPlay.ParseCommandLine(action.Arguments);
            program.sequences = options.Sequences.ToList();
            program.endTime = program.startTime.Add(TimeSpan.FromMinutes(options.Minutes)); 

            return program;
        }

        private void checkBoxDayOfWeek_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtons();
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
            UpdateButtons();
        }

        private void buttonRemoveSequence_Click(object sender, EventArgs e)
        {
            listBoxSequences.Items.RemoveAt(listBoxSequences.SelectedIndex);
        }

        private void listBoxSequences_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void listBoxPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPrograms.SelectedItem != null)
                DialogFromScheduledProgram((ScheduledProgram)listBoxPrograms.SelectedItem);

            UpdateButtons();
        }


        private void buttonUpdateProgram_Click(object sender, EventArgs e)
        {
            ScheduledProgramFromDialog().RegisterTask(taskService);
            UpdateProgramList();
            UpdateButtons();
        }

        private void buttonRemoveProgram_Click(object sender, EventArgs e)
        {
            ScheduledProgram program = listBoxPrograms.SelectedItem as ScheduledProgram;
            if (program != null) {
                program.UnregisterTask(taskService);
                UpdateProgramList();
                UpdateButtons();
            }
        }

        private void buttonAddProgram_Click(object sender, EventArgs e)
        {
            DefaultProgramSettings();
            UpdateButtons();
        }
    }
}
