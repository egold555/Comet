﻿namespace Vixen
{
    using FMOD;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Vixen.Dialogs;

    internal class PreferencesDialog : Form
    {
        private TabPage backgroundItemsTab;
        private Button buttonCancel;
        private Button buttonCreateProfile;
        private Button buttonEngine;
        private Button buttonLogFilePath;
        private Button buttonOK;
        private Button buttonPluginSetup;
        private CheckBox checkBoxAutoScrolling;
        private CheckBox checkBoxClearAtEndOfSequence;
        private CheckBox checkBoxDisableAutoUpdate;
        private CheckBox checkBoxEnableBackgroundMusic;
        private CheckBox checkBoxEnableBackgroundSequence;
        private CheckBox checkBoxEnableMusicFade;
        private CheckBox checkBoxEventSequenceAutoSize;
        private CheckBox checkBoxFlipMouseScroll;
        private CheckBox checkBoxLogManual;
        private CheckBox checkBoxLogMusicPlayer;
        private CheckBox checkBoxLogScheduled;
        private CheckBox checkBoxResetAtStartup;
        private CheckBox checkBoxSavePlugInDialogPositions;
        private CheckBox checkBoxSaveZoomLevels;
        private CheckBox checkBoxShowNaturalChannelNumber;
        private CheckBox checkBoxShowPositionMarker;
        private CheckBox checkBoxShowSaveConfirmation;
        private CheckBox checkBoxUseDefaultPlugInData;
        private CheckBox checkBoxWizardForNewSequences;
        private ComboBox comboBoxAsyncProfile;
        private ComboBox comboBoxDefaultAudioDevice;
        private ComboBox comboBoxDefaultProfile;
        private ComboBox comboBoxSequenceType;
        private ComboBox comboBoxSyncProfile;
        private IContainer components = null;
        private DateTimePicker dateTimePickerAutoShutdownTime;
        private TabPage engineTab;
        private FolderBrowserDialog folderBrowserDialog;
        private TabPage generalTab;
        private GroupBox groupBox1;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private GroupBox groupBox12;
        private GroupBox groupBox13;
        private GroupBox groupBox14;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelAutoShutdownTime;
        private Preference2 m_preferences = null;
        private IUIPlugIn[] m_uiPlugins;
        private TabPage newSequenceSettingsTab;
        private NumericUpDown numericUpDownHistoryImages;
        private NumericUpDown numericUpDownMaximumLevel;
        private NumericUpDown numericUpDownMinimumLevel;
        private OpenFileDialog openFileDialog;
        private Panel panel1;
        private RadioButton radioButtonAsyncDefaultProfileData;
        private RadioButton radioButtonAsyncProfileData;
        private RadioButton radioButtonAsyncSyncObject;
        private RadioButton radioButtonSyncDefaultProfileData;
        private RadioButton radioButtonSyncEmbeddedData;
        private RadioButton radioButtonSyncProfileData;
        private TabPage remoteExecutionTab;
        private TabPage sequenceEditingTab;
        private TabPage sequenceExecutionTab;
        private Vixen.TabControl tabControl;
        private TextBox textBoxBackgroundMusicDelay;
        private TextBox textBoxBackgroundSequenceDelay;
        private TextBox textBoxClientName;
        private TextBox textBoxCurveLibraryFileName;
        private TextBox textBoxCurveLibraryFtpPassword;
        private TextBox textBoxCurveLibraryFtpUrl;
        private TextBox textBoxCurveLibraryFtpUserName;
        private TextBox textBoxCurveLibraryHttpUrl;
        private TextBox textBoxDefaultChannelCount;
        private TextBox textBoxDefaultSequenceSaveDirectory;
        private TextBox textBoxEngine;
        private TextBox textBoxEventPeriod;
        private TextBox textBoxIntensityLargeDelta;
        private TextBox textBoxLogFilePath;
        private TextBox textBoxMaxColumnWidth;
        private TextBox textBoxMaxRowHeight;
        private TextBox textBoxMouseWheelHorizontal;
        private TextBox textBoxMouseWheelVertical;
        private TextBox textBoxMusicFadeDuration;
        private TextBox textBoxTimerCheckFrequency;
        private ToolTip toolTip;
        private TreeView treeView;

        public PreferencesDialog(Preference2 preferences, IUIPlugIn[] uiPlugins)
        {
            this.InitializeComponent();
            this.m_preferences = Preference2.GetInstance();
            this.m_uiPlugins = uiPlugins;
            foreach (IUIPlugIn @in in uiPlugins)
            {
                this.comboBoxSequenceType.Items.Add(@in.FileTypeDescription);
            }
            this.treeView.Nodes["nodeGeneral"].Tag = this.generalTab;
            this.treeView.Nodes["nodeNewSequenceSettings"].Tag = this.newSequenceSettingsTab;
            this.treeView.Nodes["nodeSequenceEditing"].Tag = this.sequenceEditingTab;
            this.treeView.Nodes["nodeSequenceExecution"].Tag = this.sequenceExecutionTab;
            this.treeView.Nodes["nodeBackgroundItems"].Tag = this.backgroundItemsTab;
            this.treeView.Nodes["nodeAdvanced"].Nodes["nodeRemoteExecution"].Tag = this.remoteExecutionTab;
            this.treeView.Nodes["nodeAdvanced"].Nodes["nodeEngine"].Tag = this.engineTab;
            this.tabControl.SelectedTab = this.generalTab;
            this.PopulateTo(this.tabControl.TabPages.IndexOf(this.generalTab));
            this.PopulateProfileLists();
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shutdown.exe")))
            {
                this.labelAutoShutdownTime.Enabled = false;
                this.dateTimePickerAutoShutdownTime.Checked = false;
                this.dateTimePickerAutoShutdownTime.Enabled = false;
            }
            this.PopulateAudioDeviceList();
        }

        private void buttonCreateProfile_Click(object sender, EventArgs e)
        {
            ProfileManagerDialog dialog = new ProfileManagerDialog(null);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.PopulateProfileLists();
            }
            dialog.Dispose();
        }

        private void buttonEngine_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "Engine assembly|*.dll";
            this.openFileDialog.FileName = string.Empty;
            this.openFileDialog.InitialDirectory = Paths.BinaryPath;
            this.openFileDialog.Title = "Select an engine assembly";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxEngine.Text = Path.GetFileName(this.openFileDialog.FileName);
            }
        }

        private void buttonLogFilePath_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            string fileName = "audio.log";
            try
            {
                path = Path.GetDirectoryName(this.textBoxLogFilePath.Text);
            }
            catch
            {
            }
            fileName = Path.GetFileName(this.textBoxLogFilePath.Text);
            if (Directory.Exists(path))
            {
                this.folderBrowserDialog.SelectedPath = path;
            }
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileName != string.Empty)
                {
                    this.textBoxLogFilePath.Text = Path.Combine(this.folderBrowserDialog.SelectedPath, fileName);
                }
                else
                {
                    this.textBoxLogFilePath.Text = Path.Combine(this.folderBrowserDialog.SelectedPath, "audio.log");
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.PopulateFrom(this.tabControl.SelectedIndex);
            this.m_preferences.Flush();
        }

        private void buttonPluginSetup_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            TreeNode node = new TreeNode("General");
            TreeNode node2 = new TreeNode("New Sequence Settings");
            TreeNode node3 = new TreeNode("Sequence Editing");
            TreeNode node4 = new TreeNode("Sequence Execution");
            TreeNode node5 = new TreeNode("Background Items");
            TreeNode node6 = new TreeNode("Remote Execution");
            TreeNode node7 = new TreeNode("Engine");
            TreeNode node8 = new TreeNode("Advanced", new TreeNode[] { node6, node7 });
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PreferencesDialog));
            this.treeView = new TreeView();
            this.panel1 = new Panel();
            this.toolTip = new ToolTip(this.components);
            this.checkBoxDisableAutoUpdate = new CheckBox();
            this.label26 = new Label();
            this.dateTimePickerAutoShutdownTime = new DateTimePicker();
            this.labelAutoShutdownTime = new Label();
            this.comboBoxSequenceType = new ComboBox();
            this.label23 = new Label();
            this.checkBoxResetAtStartup = new CheckBox();
            this.label16 = new Label();
            this.textBoxClientName = new TextBox();
            this.label15 = new Label();
            this.groupBox2 = new GroupBox();
            this.textBoxMouseWheelHorizontal = new TextBox();
            this.label4 = new Label();
            this.textBoxMouseWheelVertical = new TextBox();
            this.label3 = new Label();
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.textBoxTimerCheckFrequency = new TextBox();
            this.comboBoxDefaultAudioDevice = new ComboBox();
            this.label27 = new Label();
            this.buttonPluginSetup = new Button();
            this.textBoxDefaultChannelCount = new TextBox();
            this.comboBoxDefaultProfile = new ComboBox();
            this.label22 = new Label();
            this.label19 = new Label();
            this.label18 = new Label();
            this.buttonCreateProfile = new Button();
            this.numericUpDownMaximumLevel = new NumericUpDown();
            this.label17 = new Label();
            this.numericUpDownMinimumLevel = new NumericUpDown();
            this.label14 = new Label();
            this.textBoxEventPeriod = new TextBox();
            this.label12 = new Label();
            this.checkBoxWizardForNewSequences = new CheckBox();
            this.checkBoxShowNaturalChannelNumber = new CheckBox();
            this.textBoxIntensityLargeDelta = new TextBox();
            this.label5 = new Label();
            this.checkBoxShowSaveConfirmation = new CheckBox();
            this.checkBoxSaveZoomLevels = new CheckBox();
            this.checkBoxEventSequenceAutoSize = new CheckBox();
            this.textBoxMaxRowHeight = new TextBox();
            this.label7 = new Label();
            this.textBoxMaxColumnWidth = new TextBox();
            this.label6 = new Label();
            this.checkBoxClearAtEndOfSequence = new CheckBox();
            this.checkBoxShowPositionMarker = new CheckBox();
            this.checkBoxSavePlugInDialogPositions = new CheckBox();
            this.checkBoxAutoScrolling = new CheckBox();
            this.textBoxMusicFadeDuration = new TextBox();
            this.label21 = new Label();
            this.checkBoxEnableMusicFade = new CheckBox();
            this.textBoxBackgroundMusicDelay = new TextBox();
            this.label11 = new Label();
            this.checkBoxEnableBackgroundMusic = new CheckBox();
            this.textBoxBackgroundSequenceDelay = new TextBox();
            this.label8 = new Label();
            this.checkBoxEnableBackgroundSequence = new CheckBox();
            this.radioButtonAsyncSyncObject = new RadioButton();
            this.radioButtonAsyncDefaultProfileData = new RadioButton();
            this.radioButtonAsyncProfileData = new RadioButton();
            this.radioButtonSyncDefaultProfileData = new RadioButton();
            this.radioButtonSyncProfileData = new RadioButton();
            this.radioButtonSyncEmbeddedData = new RadioButton();
            this.checkBoxLogManual = new CheckBox();
            this.checkBoxLogScheduled = new CheckBox();
            this.checkBoxLogMusicPlayer = new CheckBox();
            this.buttonLogFilePath = new Button();
            this.textBoxLogFilePath = new TextBox();
            this.checkBoxFlipMouseScroll = new CheckBox();
            this.label29 = new Label();
            this.textBoxCurveLibraryHttpUrl = new TextBox();
            this.textBoxCurveLibraryFtpUrl = new TextBox();
            this.label30 = new Label();
            this.textBoxCurveLibraryFileName = new TextBox();
            this.label31 = new Label();
            this.label32 = new Label();
            this.textBoxCurveLibraryFtpUserName = new TextBox();
            this.label33 = new Label();
            this.textBoxCurveLibraryFtpPassword = new TextBox();
            this.textBoxDefaultSequenceSaveDirectory = new TextBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.openFileDialog = new OpenFileDialog();
            this.tabControl = new Vixen.TabControl(this.components);
            this.generalTab = new TabPage();
            this.groupBox3 = new GroupBox();
            this.numericUpDownHistoryImages = new NumericUpDown();
            this.label28 = new Label();
            this.newSequenceSettingsTab = new TabPage();
            this.groupBox12 = new GroupBox();
            this.checkBoxUseDefaultPlugInData = new CheckBox();
            this.groupBox8 = new GroupBox();
            this.label13 = new Label();
            this.sequenceEditingTab = new TabPage();
            this.groupBox14 = new GroupBox();
            this.groupBox5 = new GroupBox();
            this.label34 = new Label();
            this.sequenceExecutionTab = new TabPage();
            this.groupBox13 = new GroupBox();
            this.groupBox4 = new GroupBox();
            this.backgroundItemsTab = new TabPage();
            this.groupBox7 = new GroupBox();
            this.label20 = new Label();
            this.label10 = new Label();
            this.groupBox6 = new GroupBox();
            this.label9 = new Label();
            this.remoteExecutionTab = new TabPage();
            this.groupBox10 = new GroupBox();
            this.comboBoxAsyncProfile = new ComboBox();
            this.label25 = new Label();
            this.groupBox9 = new GroupBox();
            this.comboBoxSyncProfile = new ComboBox();
            this.label24 = new Label();
            this.engineTab = new TabPage();
            this.groupBox11 = new GroupBox();
            this.buttonEngine = new Button();
            this.textBoxEngine = new TextBox();
            this.folderBrowserDialog = new FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.numericUpDownMaximumLevel.BeginInit();
            this.numericUpDownMinimumLevel.BeginInit();
            this.tabControl.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.numericUpDownHistoryImages.BeginInit();
            this.newSequenceSettingsTab.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.sequenceEditingTab.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.sequenceExecutionTab.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.backgroundItemsTab.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.remoteExecutionTab.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.engineTab.SuspendLayout();
            this.groupBox11.SuspendLayout();
            base.SuspendLayout();
            this.treeView.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.treeView.Location = new Point(12, 12);
            this.treeView.Name = "treeView";
            node.Name = "nodeGeneral";
            node.Text = "General";
            node2.Name = "nodeNewSequenceSettings";
            node2.Text = "New Sequence Settings";
            node3.Name = "nodeSequenceEditing";
            node3.Text = "Sequence Editing";
            node4.Name = "nodeSequenceExecution";
            node4.Text = "Sequence Execution";
            node5.Name = "nodeBackgroundItems";
            node5.Text = "Background Items";
            node6.Name = "nodeRemoteExecution";
            node6.Text = "Remote Execution";
            node7.Name = "nodeEngine";
            node7.Text = "Engine";
            node8.Name = "nodeAdvanced";
            node8.Text = "Advanced";
            this.treeView.Nodes.AddRange(new TreeNode[] { node, node2, node3, node4, node5, node8 });
            this.treeView.Size = new Size(0xa1, 0x1a7);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new TreeViewEventHandler(this.treeView_AfterSelect);
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Location = new Point(0xb3, 0x1af);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1be, 4);
            this.panel1.TabIndex = 2;
            this.checkBoxDisableAutoUpdate.AutoSize = true;
            this.checkBoxDisableAutoUpdate.Location = new Point(0xd7, 0x72);
            this.checkBoxDisableAutoUpdate.Name = "checkBoxDisableAutoUpdate";
            this.checkBoxDisableAutoUpdate.Size = new Size(15, 14);
            this.checkBoxDisableAutoUpdate.TabIndex = 0x49;
            this.toolTip.SetToolTip(this.checkBoxDisableAutoUpdate, "Stops the application from trying to update itself over the internet.");
            this.checkBoxDisableAutoUpdate.UseVisualStyleBackColor = true;
            this.label26.AutoSize = true;
            this.label26.Location = new Point(0x11, 0x73);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0x66, 13);
            this.label26.TabIndex = 0x48;
            this.label26.Text = "Disable auto-update";
            this.toolTip.SetToolTip(this.label26, "Stops the application from trying to update itself over the internet.");
            this.dateTimePickerAutoShutdownTime.Checked = false;
            this.dateTimePickerAutoShutdownTime.CustomFormat = "  hh:mm tt";
            this.dateTimePickerAutoShutdownTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerAutoShutdownTime.Location = new Point(0xd7, 0x53);
            this.dateTimePickerAutoShutdownTime.Name = "dateTimePickerAutoShutdownTime";
            this.dateTimePickerAutoShutdownTime.ShowCheckBox = true;
            this.dateTimePickerAutoShutdownTime.ShowUpDown = true;
            this.dateTimePickerAutoShutdownTime.Size = new Size(0x5c, 20);
            this.dateTimePickerAutoShutdownTime.TabIndex = 0x47;
            this.toolTip.SetToolTip(this.dateTimePickerAutoShutdownTime, "If the application is running, it can shut down your computer at a time you specify");
            this.dateTimePickerAutoShutdownTime.Value = new DateTime(0x7d7, 4, 20, 12, 0, 0, 0);
            this.labelAutoShutdownTime.AutoSize = true;
            this.labelAutoShutdownTime.Location = new Point(0x11, 0x57);
            this.labelAutoShutdownTime.Name = "labelAutoShutdownTime";
            this.labelAutoShutdownTime.Size = new Size(0x4e, 13);
            this.labelAutoShutdownTime.TabIndex = 0x45;
            this.labelAutoShutdownTime.Text = "Auto shutdown";
            this.toolTip.SetToolTip(this.labelAutoShutdownTime, "If the application is running, it can shut down your computer at a time you specify");
            this.comboBoxSequenceType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSequenceType.FormattingEnabled = true;
            this.comboBoxSequenceType.Location = new Point(0xd7, 0x38);
            this.comboBoxSequenceType.Name = "comboBoxSequenceType";
            this.comboBoxSequenceType.Size = new Size(0xc4, 0x15);
            this.comboBoxSequenceType.TabIndex = 6;
            this.toolTip.SetToolTip(this.comboBoxSequenceType, "The sequence type you want to initially display when opening a sequence");
            this.label23.AutoSize = true;
            this.label23.Location = new Point(0x11, 0x3b);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x7e, 13);
            this.label23.TabIndex = 5;
            this.label23.Text = "Preferred sequence  type";
            this.toolTip.SetToolTip(this.label23, "The sequence type you want to initially display when opening a sequence");
            this.checkBoxResetAtStartup.AutoSize = true;
            this.checkBoxResetAtStartup.Enabled = false;
            this.checkBoxResetAtStartup.Location = new Point(0xd7, 0x9e);
            this.checkBoxResetAtStartup.Name = "checkBoxResetAtStartup";
            this.checkBoxResetAtStartup.Size = new Size(15, 14);
            this.checkBoxResetAtStartup.TabIndex = 0x44;
            this.toolTip.SetToolTip(this.checkBoxResetAtStartup, "Sends a blank event to the plugins in the default plugin setup.\r\nUseful for parallel port-based controllers.  Does not affect every\r\ncontroller type.");
            this.checkBoxResetAtStartup.UseVisualStyleBackColor = true;
            this.checkBoxResetAtStartup.Visible = false;
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Location = new Point(0x11, 0x9f);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x86, 0x27);
            this.label16.TabIndex = 7;
            this.label16.Text = "Reset controller at startup\r\n(Requires default profiles in\r\nNew Sequence Settings)";
            this.toolTip.SetToolTip(this.label16, "Sends a blank event to the plugins in the default plugin setup.\r\nUseful for parallel port-based controllers.  Does not affect every\r\ncontroller type.");
            this.label16.Visible = false;
            this.textBoxClientName.Location = new Point(0xd7, 0x1c);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new Size(0xc4, 20);
            this.textBoxClientName.TabIndex = 4;
            this.toolTip.SetToolTip(this.textBoxClientName, "Name used to identify this installation to remote clients and servers");
            this.label15.AutoSize = true;
            this.label15.Location = new Point(0x11, 0x1f);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x3e, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Client name";
            this.toolTip.SetToolTip(this.label15, "Name used to identify this installation to remote clients and servers");
            this.groupBox2.Controls.Add(this.textBoxMouseWheelHorizontal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxMouseWheelVertical);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new Point(0x13, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x1a8, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mouse Wheel";
            this.toolTip.SetToolTip(this.groupBox2, "Mouse wheel increments");
            this.textBoxMouseWheelHorizontal.Location = new Point(0xd7, 0x3e);
            this.textBoxMouseWheelHorizontal.Name = "textBoxMouseWheelHorizontal";
            this.textBoxMouseWheelHorizontal.Size = new Size(50, 20);
            this.textBoxMouseWheelHorizontal.TabIndex = 3;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x11, 0x41);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x95, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mouse wheel event increment";
            this.toolTip.SetToolTip(this.label4, "How many event periods a single mouse wheel movement scrolls through");
            this.textBoxMouseWheelVertical.Location = new Point(0xd7, 30);
            this.textBoxMouseWheelVertical.Name = "textBoxMouseWheelVertical";
            this.textBoxMouseWheelVertical.Size = new Size(50, 20);
            this.textBoxMouseWheelVertical.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x11, 0x21);
            this.label3.Name = "label3";
            this.label3.Size = new Size(160, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mouse wheel channel increment";
            this.toolTip.SetToolTip(this.label3, "How many channels a single mouse wheel movement scrolls through");
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxTimerCheckFrequency);
            this.groupBox1.Location = new Point(0x13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1a8, 0x45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timers";
            this.toolTip.SetToolTip(this.groupBox1, "How often the timer schedule is checked (in seconds)");
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x10f, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2f, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer check frequency";
            this.textBoxTimerCheckFrequency.Location = new Point(0xd7, 0x1b);
            this.textBoxTimerCheckFrequency.Name = "textBoxTimerCheckFrequency";
            this.textBoxTimerCheckFrequency.Size = new Size(50, 20);
            this.textBoxTimerCheckFrequency.TabIndex = 1;
            this.comboBoxDefaultAudioDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxDefaultAudioDevice.FormattingEnabled = true;
            this.comboBoxDefaultAudioDevice.Location = new Point(0xd7, 0x4e);
            this.comboBoxDefaultAudioDevice.Name = "comboBoxDefaultAudioDevice";
            this.comboBoxDefaultAudioDevice.Size = new Size(0xc0, 0x15);
            this.comboBoxDefaultAudioDevice.TabIndex = 0x13;
            this.toolTip.SetToolTip(this.comboBoxDefaultAudioDevice, "Audio device that will be selected for a new sequence");
            this.label27.AutoSize = true;
            this.label27.Location = new Point(0x11, 0x51);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x9b, 13);
            this.label27.TabIndex = 0x12;
            this.label27.Text = "Default sequence audio device";
            this.toolTip.SetToolTip(this.label27, "Audio device that will be selected for a new sequence");
            this.buttonPluginSetup.Location = new Point(0xd7, 130);
            this.buttonPluginSetup.Name = "buttonPluginSetup";
            this.buttonPluginSetup.Size = new Size(0x4b, 0x17);
            this.buttonPluginSetup.TabIndex = 13;
            this.buttonPluginSetup.Text = "Plugin Setup";
            this.toolTip.SetToolTip(this.buttonPluginSetup, "Plugin data for new sequences or for circumstances with no sequence available");
            this.buttonPluginSetup.UseVisualStyleBackColor = true;
            this.buttonPluginSetup.Visible = false;
            this.textBoxDefaultChannelCount.Location = new Point(0xd7, 0x68);
            this.textBoxDefaultChannelCount.Name = "textBoxDefaultChannelCount";
            this.textBoxDefaultChannelCount.Size = new Size(50, 20);
            this.textBoxDefaultChannelCount.TabIndex = 11;
            this.toolTip.SetToolTip(this.textBoxDefaultChannelCount, "The number of channels for new sequences or the number of channels to assume for circumstances with no sequence available");
            this.textBoxDefaultChannelCount.Visible = false;
            this.comboBoxDefaultProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxDefaultProfile.DropDownWidth = 150;
            this.comboBoxDefaultProfile.FormattingEnabled = true;
            this.comboBoxDefaultProfile.Location = new Point(0xd7, 0x16);
            this.comboBoxDefaultProfile.Name = "comboBoxDefaultProfile";
            this.comboBoxDefaultProfile.Size = new Size(0xc0, 0x15);
            this.comboBoxDefaultProfile.TabIndex = 0x10;
            this.toolTip.SetToolTip(this.comboBoxDefaultProfile, "Profile that will be used for new sequences and");
            this.label22.AutoSize = true;
            this.label22.Location = new Point(0x11, 0x19);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x48, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "Default profile";
            this.toolTip.SetToolTip(this.label22, "Profile that will be used for new sequences and\r\nfor external clients.");
            this.label19.AutoSize = true;
            this.label19.Location = new Point(0x11, 0x87);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x65, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Default plugin setup";
            this.toolTip.SetToolTip(this.label19, "Plugin data for new sequences or for circumstances with no sequence available");
            this.label19.Visible = false;
            this.label18.AutoSize = true;
            this.label18.Location = new Point(0x11, 0x6b);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x70, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Default channel count";
            this.toolTip.SetToolTip(this.label18, "The number of channels for new sequences or for circumstances with no sequence available");
            this.label18.Visible = false;
            this.buttonCreateProfile.Location = new Point(0xd7, 0x31);
            this.buttonCreateProfile.Name = "buttonCreateProfile";
            this.buttonCreateProfile.Size = new Size(0x4b, 0x17);
            this.buttonCreateProfile.TabIndex = 0x11;
            this.buttonCreateProfile.Text = "Create new";
            this.toolTip.SetToolTip(this.buttonCreateProfile, "Create new profiles now");
            this.buttonCreateProfile.UseVisualStyleBackColor = true;
            this.numericUpDownMaximumLevel.Location = new Point(0xd7, 0x4a);
            int[] bits = new int[4];
            bits[0] = 0xff;
            this.numericUpDownMaximumLevel.Maximum = new decimal(bits);
            this.numericUpDownMaximumLevel.Name = "numericUpDownMaximumLevel";
            this.numericUpDownMaximumLevel.Size = new Size(50, 20);
            this.numericUpDownMaximumLevel.TabIndex = 7;
            this.toolTip.SetToolTip(this.numericUpDownMaximumLevel, "Maximum illumination level allowed by a sequence");
            this.label17.AutoSize = true;
            this.label17.Location = new Point(0x11, 0x4c);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0xa6, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Maximum illumination level (0-255)";
            this.toolTip.SetToolTip(this.label17, "Maximum illumination level allowed by a sequence");
            this.numericUpDownMinimumLevel.Location = new Point(0xd7, 0x30);
            bits = new int[4];
            bits[0] = 0xff;
            this.numericUpDownMinimumLevel.Maximum = new decimal(bits);
            this.numericUpDownMinimumLevel.Name = "numericUpDownMinimumLevel";
            this.numericUpDownMinimumLevel.Size = new Size(50, 20);
            this.numericUpDownMinimumLevel.TabIndex = 4;
            this.toolTip.SetToolTip(this.numericUpDownMinimumLevel, "Minimum illumination level allowed by a sequence");
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x11, 50);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0xa3, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Minimum illumination level (0-255)";
            this.toolTip.SetToolTip(this.label14, "Minimum illumination level allowed by a sequence");
            this.textBoxEventPeriod.Location = new Point(0xd7, 0x16);
            this.textBoxEventPeriod.Name = "textBoxEventPeriod";
            this.textBoxEventPeriod.Size = new Size(50, 20);
            this.textBoxEventPeriod.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxEventPeriod, "The length of a single event period (in milliseconds)");
            this.label12.AutoSize = true;
            this.label12.Location = new Point(0x11, 0x19);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x63, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Event period length";
            this.toolTip.SetToolTip(this.label12, "The length of a single event period (in milliseconds)");
            this.checkBoxWizardForNewSequences.AutoSize = true;
            this.checkBoxWizardForNewSequences.Location = new Point(0x13, 260);
            this.checkBoxWizardForNewSequences.Name = "checkBoxWizardForNewSequences";
            this.checkBoxWizardForNewSequences.Size = new Size(0x13c, 0x11);
            this.checkBoxWizardForNewSequences.TabIndex = 2;
            this.checkBoxWizardForNewSequences.Text = "Use the sequence wizard for new sequences, when available";
            this.toolTip.SetToolTip(this.checkBoxWizardForNewSequences, "Use the sequence wizard for new sequences, when the editor allows for a wizard to be used");
            this.checkBoxWizardForNewSequences.UseVisualStyleBackColor = true;
            this.checkBoxShowNaturalChannelNumber.AutoSize = true;
            this.checkBoxShowNaturalChannelNumber.Location = new Point(20, 0xb5);
            this.checkBoxShowNaturalChannelNumber.Name = "checkBoxShowNaturalChannelNumber";
            this.checkBoxShowNaturalChannelNumber.Size = new Size(0xa7, 0x11);
            this.checkBoxShowNaturalChannelNumber.TabIndex = 9;
            this.checkBoxShowNaturalChannelNumber.Text = "Show natural channel number";
            this.toolTip.SetToolTip(this.checkBoxShowNaturalChannelNumber, "Show the channel numbers according to the order they were created in");
            this.checkBoxShowNaturalChannelNumber.UseVisualStyleBackColor = true;
            this.textBoxIntensityLargeDelta.Location = new Point(0xd7, 0x4f);
            this.textBoxIntensityLargeDelta.Name = "textBoxIntensityLargeDelta";
            this.textBoxIntensityLargeDelta.Size = new Size(50, 20);
            this.textBoxIntensityLargeDelta.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBoxIntensityLargeDelta, "When using Ctrl-Up or Ctrl-Down to adjust the intensity\r\nof a selection.");
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x11, 0x52);
            this.label5.Name = "label5";
            this.label5.Size = new Size(190, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Intensity adjust large change (% points)";
            this.toolTip.SetToolTip(this.label5, "When using Ctrl-Up or Ctrl-Down to adjust the intensity");
            this.checkBoxShowSaveConfirmation.AutoSize = true;
            this.checkBoxShowSaveConfirmation.Location = new Point(20, 0x9e);
            this.checkBoxShowSaveConfirmation.Name = "checkBoxShowSaveConfirmation";
            this.checkBoxShowSaveConfirmation.Size = new Size(0x8b, 0x11);
            this.checkBoxShowSaveConfirmation.TabIndex = 8;
            this.checkBoxShowSaveConfirmation.Text = "Show save confirmation";
            this.toolTip.SetToolTip(this.checkBoxShowSaveConfirmation, "Show a confirmation message after saving a sequence");
            this.checkBoxShowSaveConfirmation.UseVisualStyleBackColor = true;
            this.checkBoxSaveZoomLevels.AutoSize = true;
            this.checkBoxSaveZoomLevels.Location = new Point(20, 0x87);
            this.checkBoxSaveZoomLevels.Name = "checkBoxSaveZoomLevels";
            this.checkBoxSaveZoomLevels.Size = new Size(0x6d, 0x11);
            this.checkBoxSaveZoomLevels.TabIndex = 7;
            this.checkBoxSaveZoomLevels.Text = "Save zoom levels";
            this.toolTip.SetToolTip(this.checkBoxSaveZoomLevels, "Save the row and height zoom levels");
            this.checkBoxSaveZoomLevels.UseVisualStyleBackColor = true;
            this.checkBoxEventSequenceAutoSize.AutoSize = true;
            this.checkBoxEventSequenceAutoSize.Location = new Point(20, 0x70);
            this.checkBoxEventSequenceAutoSize.Name = "checkBoxEventSequenceAutoSize";
            this.checkBoxEventSequenceAutoSize.Size = new Size(0x9a, 0x11);
            this.checkBoxEventSequenceAutoSize.TabIndex = 6;
            this.checkBoxEventSequenceAutoSize.Text = "Auto size event sequences";
            this.toolTip.SetToolTip(this.checkBoxEventSequenceAutoSize, "Automatically resize an event sequence to the length of the selected audio");
            this.checkBoxEventSequenceAutoSize.UseVisualStyleBackColor = true;
            this.textBoxMaxRowHeight.Location = new Point(0xd7, 0x30);
            this.textBoxMaxRowHeight.Name = "textBoxMaxRowHeight";
            this.textBoxMaxRowHeight.Size = new Size(50, 20);
            this.textBoxMaxRowHeight.TabIndex = 3;
            this.toolTip.SetToolTip(this.textBoxMaxRowHeight, "The height of a channel in the editing grid at 100%");
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x11, 0x33);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x4f, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Max row height";
            this.toolTip.SetToolTip(this.label7, "The height of a channel in the editing grid at 100%");
            this.textBoxMaxColumnWidth.Location = new Point(0xd7, 0x1b);
            this.textBoxMaxColumnWidth.Name = "textBoxMaxColumnWidth";
            this.textBoxMaxColumnWidth.Size = new Size(50, 20);
            this.textBoxMaxColumnWidth.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxMaxColumnWidth, "The width of an event period in the editing grid at 100%");
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x11, 30);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x5c, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Max column width";
            this.toolTip.SetToolTip(this.label6, "The width of an event period in the editing grid at 100%");
            this.checkBoxClearAtEndOfSequence.AutoSize = true;
            this.checkBoxClearAtEndOfSequence.Location = new Point(0x1a, 0x60);
            this.checkBoxClearAtEndOfSequence.Name = "checkBoxClearAtEndOfSequence";
            this.checkBoxClearAtEndOfSequence.Size = new Size(200, 0x11);
            this.checkBoxClearAtEndOfSequence.TabIndex = 3;
            this.checkBoxClearAtEndOfSequence.Text = "Reset controller at end of sequences";
            this.toolTip.SetToolTip(this.checkBoxClearAtEndOfSequence, "Sends a blank event to the plugins at the end of a sequence.\r\nUseful for parallel port-based controllers.  Does not affect every\r\ncontroller type.");
            this.checkBoxClearAtEndOfSequence.UseVisualStyleBackColor = true;
            this.checkBoxShowPositionMarker.AutoSize = true;
            this.checkBoxShowPositionMarker.Location = new Point(0x1a, 0x1b);
            this.checkBoxShowPositionMarker.Name = "checkBoxShowPositionMarker";
            this.checkBoxShowPositionMarker.Size = new Size(0x7f, 0x11);
            this.checkBoxShowPositionMarker.TabIndex = 0;
            this.checkBoxShowPositionMarker.Text = "Show position marker";
            this.toolTip.SetToolTip(this.checkBoxShowPositionMarker, "Show the current point of exeuction with a mark in the time panel");
            this.checkBoxShowPositionMarker.UseVisualStyleBackColor = true;
            this.checkBoxSavePlugInDialogPositions.AutoSize = true;
            this.checkBoxSavePlugInDialogPositions.Location = new Point(0x1a, 0x49);
            this.checkBoxSavePlugInDialogPositions.Name = "checkBoxSavePlugInDialogPositions";
            this.checkBoxSavePlugInDialogPositions.Size = new Size(0x9d, 0x11);
            this.checkBoxSavePlugInDialogPositions.TabIndex = 2;
            this.checkBoxSavePlugInDialogPositions.Text = "Save plugin dialog positions";
            this.toolTip.SetToolTip(this.checkBoxSavePlugInDialogPositions, "Save the positions of any windows created and displayed by plugins during execution");
            this.checkBoxSavePlugInDialogPositions.UseVisualStyleBackColor = true;
            this.checkBoxAutoScrolling.AutoSize = true;
            this.checkBoxAutoScrolling.Location = new Point(0x1a, 50);
            this.checkBoxAutoScrolling.Name = "checkBoxAutoScrolling";
            this.checkBoxAutoScrolling.Size = new Size(0x59, 0x11);
            this.checkBoxAutoScrolling.TabIndex = 1;
            this.checkBoxAutoScrolling.Text = "Auto scrolling";
            this.toolTip.SetToolTip(this.checkBoxAutoScrolling, "Automatically scroll the editing display during execution so that the current point of execution is always visible");
            this.checkBoxAutoScrolling.UseVisualStyleBackColor = true;
            this.textBoxMusicFadeDuration.Location = new Point(0xd7, 0x66);
            this.textBoxMusicFadeDuration.Name = "textBoxMusicFadeDuration";
            this.textBoxMusicFadeDuration.Size = new Size(50, 20);
            this.textBoxMusicFadeDuration.TabIndex = 10;
            this.toolTip.SetToolTip(this.textBoxMusicFadeDuration, "How long (in seconds) it will take the background music to fade out");
            this.label21.AutoSize = true;
            this.label21.Location = new Point(14, 0x69);
            this.label21.Name = "label21";
            this.label21.Size = new Size(100, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Music fade duration";
            this.toolTip.SetToolTip(this.label21, "How long (in seconds) it will take the background music to fade out");
            this.checkBoxEnableMusicFade.AutoSize = true;
            this.checkBoxEnableMusicFade.Location = new Point(0x11, 80);
            this.checkBoxEnableMusicFade.Name = "checkBoxEnableMusicFade";
            this.checkBoxEnableMusicFade.Size = new Size(0x71, 0x11);
            this.checkBoxEnableMusicFade.TabIndex = 8;
            this.checkBoxEnableMusicFade.Text = "Enable music fade";
            this.toolTip.SetToolTip(this.checkBoxEnableMusicFade, "Enable the fading of the background music when it's stopped");
            this.checkBoxEnableMusicFade.UseVisualStyleBackColor = true;
            this.textBoxBackgroundMusicDelay.Location = new Point(0xd7, 0x2d);
            this.textBoxBackgroundMusicDelay.Name = "textBoxBackgroundMusicDelay";
            this.textBoxBackgroundMusicDelay.Size = new Size(50, 20);
            this.textBoxBackgroundMusicDelay.TabIndex = 6;
            this.toolTip.SetToolTip(this.textBoxBackgroundMusicDelay, "How long (in seconds) the background sequence will wait before starting after sequence or program execution stops");
            this.label11.AutoSize = true;
            this.label11.Location = new Point(14, 0x30);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x7b, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Background music delay";
            this.toolTip.SetToolTip(this.label11, "How long (in seconds) the background music will wait before starting after sequence or program execution stops");
            this.checkBoxEnableBackgroundMusic.AutoSize = true;
            this.checkBoxEnableBackgroundMusic.Location = new Point(0x11, 0x17);
            this.checkBoxEnableBackgroundMusic.Name = "checkBoxEnableBackgroundMusic";
            this.checkBoxEnableBackgroundMusic.Size = new Size(0x95, 0x11);
            this.checkBoxEnableBackgroundMusic.TabIndex = 4;
            this.checkBoxEnableBackgroundMusic.Text = "Enable background music";
            this.toolTip.SetToolTip(this.checkBoxEnableBackgroundMusic, "Enable the playing of background music while no sequences or programs are playing");
            this.checkBoxEnableBackgroundMusic.UseVisualStyleBackColor = true;
            this.textBoxBackgroundSequenceDelay.Location = new Point(0xd7, 0x43);
            this.textBoxBackgroundSequenceDelay.Name = "textBoxBackgroundSequenceDelay";
            this.textBoxBackgroundSequenceDelay.Size = new Size(50, 20);
            this.textBoxBackgroundSequenceDelay.TabIndex = 2;
            this.toolTip.SetToolTip(this.textBoxBackgroundSequenceDelay, "How long (in seconds) the background sequence will wait before starting after sequence or program execution stops");
            this.label8.AutoSize = true;
            this.label8.Location = new Point(14, 70);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x8f, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Background sequence delay";
            this.toolTip.SetToolTip(this.label8, "How long (in seconds) the background sequence will wait before starting after sequence or program execution stops");
            this.checkBoxEnableBackgroundSequence.AutoSize = true;
            this.checkBoxEnableBackgroundSequence.Location = new Point(0x11, 30);
            this.checkBoxEnableBackgroundSequence.Name = "checkBoxEnableBackgroundSequence";
            this.checkBoxEnableBackgroundSequence.Size = new Size(0xa9, 0x11);
            this.checkBoxEnableBackgroundSequence.TabIndex = 0;
            this.checkBoxEnableBackgroundSequence.Text = "Enable background sequence";
            this.toolTip.SetToolTip(this.checkBoxEnableBackgroundSequence, "Enable the playing of a scripted background sequence while no sequences or programs are playing");
            this.checkBoxEnableBackgroundSequence.UseVisualStyleBackColor = true;
            this.radioButtonAsyncSyncObject.AutoSize = true;
            this.radioButtonAsyncSyncObject.Location = new Point(100, 0x60);
            this.radioButtonAsyncSyncObject.Name = "radioButtonAsyncSyncObject";
            this.radioButtonAsyncSyncObject.Size = new Size(0xf2, 0x11);
            this.radioButtonAsyncSyncObject.TabIndex = 1;
            this.radioButtonAsyncSyncObject.TabStop = true;
            this.radioButtonAsyncSyncObject.Text = "Use the sequence loaded for execution, if any";
            this.toolTip.SetToolTip(this.radioButtonAsyncSyncObject, "The sequence will use channel masking and plugin setup data from\r\nthe default profile.");
            this.radioButtonAsyncSyncObject.UseVisualStyleBackColor = true;
            this.radioButtonAsyncSyncObject.CheckedChanged += new EventHandler(this.radioButtonAsyncProfileData_CheckedChanged);
            this.radioButtonAsyncDefaultProfileData.AutoSize = true;
            this.radioButtonAsyncDefaultProfileData.Location = new Point(100, 0x8e);
            this.radioButtonAsyncDefaultProfileData.Name = "radioButtonAsyncDefaultProfileData";
            this.radioButtonAsyncDefaultProfileData.Size = new Size(0x80, 0x11);
            this.radioButtonAsyncDefaultProfileData.TabIndex = 4;
            this.radioButtonAsyncDefaultProfileData.TabStop = true;
            this.radioButtonAsyncDefaultProfileData.Text = "Use the default profile";
            this.toolTip.SetToolTip(this.radioButtonAsyncDefaultProfileData, "The sequence will use channel masking and plugin setup data from\r\nthe default profile.");
            this.radioButtonAsyncDefaultProfileData.UseVisualStyleBackColor = true;
            this.radioButtonAsyncDefaultProfileData.CheckedChanged += new EventHandler(this.radioButtonAsyncProfileData_CheckedChanged);
            this.radioButtonAsyncProfileData.AutoSize = true;
            this.radioButtonAsyncProfileData.Location = new Point(100, 0x77);
            this.radioButtonAsyncProfileData.Name = "radioButtonAsyncProfileData";
            this.radioButtonAsyncProfileData.Size = new Size(0x7b, 0x11);
            this.radioButtonAsyncProfileData.TabIndex = 2;
            this.radioButtonAsyncProfileData.TabStop = true;
            this.radioButtonAsyncProfileData.Text = "Use a specific profile";
            this.toolTip.SetToolTip(this.radioButtonAsyncProfileData, "The sequence will use channel masking and plugin setup data from\r\na specified profile.");
            this.radioButtonAsyncProfileData.UseVisualStyleBackColor = true;
            this.radioButtonAsyncProfileData.CheckedChanged += new EventHandler(this.radioButtonAsyncProfileData_CheckedChanged);
            this.radioButtonSyncDefaultProfileData.AutoSize = true;
            this.radioButtonSyncDefaultProfileData.Location = new Point(100, 130);
            this.radioButtonSyncDefaultProfileData.Name = "radioButtonSyncDefaultProfileData";
            this.radioButtonSyncDefaultProfileData.Size = new Size(0x80, 0x11);
            this.radioButtonSyncDefaultProfileData.TabIndex = 3;
            this.radioButtonSyncDefaultProfileData.TabStop = true;
            this.radioButtonSyncDefaultProfileData.Text = "Use the default profile";
            this.toolTip.SetToolTip(this.radioButtonSyncDefaultProfileData, "The sequence will use channel masking and plugin setup data from\r\nthe default profile.");
            this.radioButtonSyncDefaultProfileData.UseVisualStyleBackColor = true;
            this.radioButtonSyncDefaultProfileData.CheckedChanged += new EventHandler(this.radioButtonSyncProfileData_CheckedChanged);
            this.radioButtonSyncProfileData.AutoSize = true;
            this.radioButtonSyncProfileData.Location = new Point(100, 0x6b);
            this.radioButtonSyncProfileData.Name = "radioButtonSyncProfileData";
            this.radioButtonSyncProfileData.Size = new Size(0x7b, 0x11);
            this.radioButtonSyncProfileData.TabIndex = 2;
            this.radioButtonSyncProfileData.TabStop = true;
            this.radioButtonSyncProfileData.Text = "Use a specific profile";
            this.toolTip.SetToolTip(this.radioButtonSyncProfileData, "The sequence will use channel masking and plugin setup data from\r\na specified profile.");
            this.radioButtonSyncProfileData.UseVisualStyleBackColor = true;
            this.radioButtonSyncProfileData.CheckedChanged += new EventHandler(this.radioButtonSyncProfileData_CheckedChanged);
            this.radioButtonSyncEmbeddedData.AutoSize = true;
            this.radioButtonSyncEmbeddedData.Location = new Point(100, 0x54);
            this.radioButtonSyncEmbeddedData.Name = "radioButtonSyncEmbeddedData";
            this.radioButtonSyncEmbeddedData.Size = new Size(0x72, 0x11);
            this.radioButtonSyncEmbeddedData.TabIndex = 1;
            this.radioButtonSyncEmbeddedData.TabStop = true;
            this.radioButtonSyncEmbeddedData.Text = "Use their own data";
            this.toolTip.SetToolTip(this.radioButtonSyncEmbeddedData, "The sequence will determine its own channel masking and use\r\nits own plugin setup.");
            this.radioButtonSyncEmbeddedData.UseVisualStyleBackColor = true;
            this.radioButtonSyncEmbeddedData.CheckedChanged += new EventHandler(this.radioButtonSyncProfileData_CheckedChanged);
            this.checkBoxLogManual.AutoSize = true;
            this.checkBoxLogManual.Location = new Point(0x1a, 30);
            this.checkBoxLogManual.Name = "checkBoxLogManual";
            this.checkBoxLogManual.Size = new Size(0xb9, 0x11);
            this.checkBoxLogManual.TabIndex = 0;
            this.checkBoxLogManual.Text = "Log manual sequence executions";
            this.toolTip.SetToolTip(this.checkBoxLogManual, "Sequence executions that you start manually in an editor");
            this.checkBoxLogManual.UseVisualStyleBackColor = true;
            this.checkBoxLogScheduled.AutoSize = true;
            this.checkBoxLogScheduled.Location = new Point(0x1a, 0x35);
            this.checkBoxLogScheduled.Name = "checkBoxLogScheduled";
            this.checkBoxLogScheduled.Size = new Size(200, 0x11);
            this.checkBoxLogScheduled.TabIndex = 1;
            this.checkBoxLogScheduled.Text = "Log scheduled sequence executions";
            this.toolTip.SetToolTip(this.checkBoxLogScheduled, "Sequence executions that are started automatically by the scheduler");
            this.checkBoxLogScheduled.UseVisualStyleBackColor = true;
            this.checkBoxLogMusicPlayer.AutoSize = true;
            this.checkBoxLogMusicPlayer.Location = new Point(0x1a, 0x4c);
            this.checkBoxLogMusicPlayer.Name = "checkBoxLogMusicPlayer";
            this.checkBoxLogMusicPlayer.Size = new Size(0x9f, 0x11);
            this.checkBoxLogMusicPlayer.TabIndex = 2;
            this.checkBoxLogMusicPlayer.Text = "Log music player executions";
            this.toolTip.SetToolTip(this.checkBoxLogMusicPlayer, "Log the audio files that the music player executes");
            this.checkBoxLogMusicPlayer.UseVisualStyleBackColor = true;
            this.buttonLogFilePath.Location = new Point(0x1a, 0x6a);
            this.buttonLogFilePath.Name = "buttonLogFilePath";
            this.buttonLogFilePath.Size = new Size(0x4b, 0x17);
            this.buttonLogFilePath.TabIndex = 3;
            this.buttonLogFilePath.Text = "Log path";
            this.toolTip.SetToolTip(this.buttonLogFilePath, "Path of the log file");
            this.buttonLogFilePath.UseVisualStyleBackColor = true;
            this.buttonLogFilePath.Click += new EventHandler(this.buttonLogFilePath_Click);
            this.textBoxLogFilePath.Location = new Point(0x6b, 0x6c);
            this.textBoxLogFilePath.Name = "textBoxLogFilePath";
            this.textBoxLogFilePath.Size = new Size(0x137, 20);
            this.textBoxLogFilePath.TabIndex = 4;
            this.toolTip.SetToolTip(this.textBoxLogFilePath, "Path of the log file");
            this.checkBoxFlipMouseScroll.AutoSize = true;
            this.checkBoxFlipMouseScroll.Location = new Point(20, 0xcc);
            this.checkBoxFlipMouseScroll.Name = "checkBoxFlipMouseScroll";
            this.checkBoxFlipMouseScroll.Size = new Size(180, 0x11);
            this.checkBoxFlipMouseScroll.TabIndex = 10;
            this.checkBoxFlipMouseScroll.Text = "Flip mouse scroll + Shift behavior";
            this.toolTip.SetToolTip(this.checkBoxFlipMouseScroll, "The default behavior scrolls horizontally when Shift is down.\r\nSelect this to make it scroll vertically when Shift is down.");
            this.checkBoxFlipMouseScroll.UseVisualStyleBackColor = true;
            this.label29.AutoSize = true;
            this.label29.Location = new Point(20, 0x18);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x3d, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "HTTP URL";
            this.toolTip.SetToolTip(this.label29, "HTTP location of the remote curve library");
            this.textBoxCurveLibraryHttpUrl.Location = new Point(0x69, 0x15);
            this.textBoxCurveLibraryHttpUrl.Name = "textBoxCurveLibraryHttpUrl";
            this.textBoxCurveLibraryHttpUrl.Size = new Size(310, 20);
            this.textBoxCurveLibraryHttpUrl.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxCurveLibraryHttpUrl, "HTTP location of the remote curve library");
            this.textBoxCurveLibraryFtpUrl.Location = new Point(0x69, 0x2f);
            this.textBoxCurveLibraryFtpUrl.Name = "textBoxCurveLibraryFtpUrl";
            this.textBoxCurveLibraryFtpUrl.Size = new Size(310, 20);
            this.textBoxCurveLibraryFtpUrl.TabIndex = 3;
            this.toolTip.SetToolTip(this.textBoxCurveLibraryFtpUrl, "FTP location of the remote curve library.  May possibly be the same as the HTTP location.");
            this.label30.AutoSize = true;
            this.label30.Location = new Point(20, 50);
            this.label30.Name = "label30";
            this.label30.Size = new Size(0x34, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "FTP URL";
            this.toolTip.SetToolTip(this.label30, "FTP location of the remote curve library.  May possibly be the same as the HTTP location.");
            this.textBoxCurveLibraryFileName.Location = new Point(0x69, 0x49);
            this.textBoxCurveLibraryFileName.Name = "textBoxCurveLibraryFileName";
            this.textBoxCurveLibraryFileName.Size = new Size(0x8e, 20);
            this.textBoxCurveLibraryFileName.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBoxCurveLibraryFileName, "Name of the remote curve library file.");
            this.label31.AutoSize = true;
            this.label31.Location = new Point(20, 0x4c);
            this.label31.Name = "label31";
            this.label31.Size = new Size(0x34, 13);
            this.label31.TabIndex = 4;
            this.label31.Text = "File name";
            this.toolTip.SetToolTip(this.label31, "Name of the remote curve library file.");
            this.label32.AutoSize = true;
            this.label32.Location = new Point(20, 0x66);
            this.label32.Name = "label32";
            this.label32.Size = new Size(0x4f, 13);
            this.label32.TabIndex = 6;
            this.label32.Text = "FTP user name";
            this.toolTip.SetToolTip(this.label32, "FTP user name for the FTP server on which the remote curve library is located.  May possibly be blank.");
            this.label32.Visible = false;
            this.textBoxCurveLibraryFtpUserName.Location = new Point(0x69, 0x63);
            this.textBoxCurveLibraryFtpUserName.Name = "textBoxCurveLibraryFtpUserName";
            this.textBoxCurveLibraryFtpUserName.Size = new Size(100, 20);
            this.textBoxCurveLibraryFtpUserName.TabIndex = 7;
            this.toolTip.SetToolTip(this.textBoxCurveLibraryFtpUserName, "FTP user name for the FTP server on which the remote curve library is located.  May possibly be blank.");
            this.textBoxCurveLibraryFtpUserName.Visible = false;
            this.label33.AutoSize = true;
            this.label33.Location = new Point(0xdf, 0x66);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x4b, 13);
            this.label33.TabIndex = 8;
            this.label33.Text = "FTP password";
            this.toolTip.SetToolTip(this.label33, "FTP password for the FTP server on which the remote curve library is located.  May possibly be blank.");
            this.label33.Visible = false;
            this.textBoxCurveLibraryFtpPassword.Location = new Point(0x130, 0x63);
            this.textBoxCurveLibraryFtpPassword.Name = "textBoxCurveLibraryFtpPassword";
            this.textBoxCurveLibraryFtpPassword.Size = new Size(0x6f, 20);
            this.textBoxCurveLibraryFtpPassword.TabIndex = 9;
            this.toolTip.SetToolTip(this.textBoxCurveLibraryFtpPassword, "FTP password for the FTP server on which the remote curve library is located.  May possibly be blank.");
            this.textBoxCurveLibraryFtpPassword.Visible = false;
            this.textBoxDefaultSequenceSaveDirectory.Location = new Point(20, 0xfd);
            this.textBoxDefaultSequenceSaveDirectory.Name = "textBoxDefaultSequenceSaveDirectory";
            this.textBoxDefaultSequenceSaveDirectory.Size = new Size(0x18b, 20);
            this.textBoxDefaultSequenceSaveDirectory.TabIndex = 12;
            this.toolTip.SetToolTip(this.textBoxDefaultSequenceSaveDirectory, @"Application default is My Documents\Vixen\Sequences");
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x1d5, 0x1bd);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(550, 0x1bd);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.tabControl.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.tabControl.Controls.Add(this.generalTab);
            this.tabControl.Controls.Add(this.newSequenceSettingsTab);
            this.tabControl.Controls.Add(this.sequenceEditingTab);
            this.tabControl.Controls.Add(this.sequenceExecutionTab);
            this.tabControl.Controls.Add(this.backgroundItemsTab);
            this.tabControl.Controls.Add(this.remoteExecutionTab);
            this.tabControl.Controls.Add(this.engineTab);
            this.tabControl.HideTabs = true;
            this.tabControl.Location = new Point(0xb3, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new Size(0x1be, 0x19d);
            this.tabControl.TabIndex = 1;
            this.tabControl.Selected += new TabControlEventHandler(this.tabControl_Selected);
            this.tabControl.Deselecting += new TabControlCancelEventHandler(this.tabControl_Deselecting);
            this.generalTab.BackColor = Color.Transparent;
            this.generalTab.Controls.Add(this.groupBox3);
            this.generalTab.Controls.Add(this.groupBox2);
            this.generalTab.Controls.Add(this.groupBox1);
            this.generalTab.Location = new Point(0, 0);
            this.generalTab.Name = "generalTab";
            this.generalTab.Size = new Size(0x1be, 0x19d);
            this.generalTab.TabIndex = 3;
            this.generalTab.Text = "generalTab";
            this.groupBox3.Controls.Add(this.numericUpDownHistoryImages);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.checkBoxDisableAutoUpdate);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.dateTimePickerAutoShutdownTime);
            this.groupBox3.Controls.Add(this.labelAutoShutdownTime);
            this.groupBox3.Controls.Add(this.comboBoxSequenceType);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.checkBoxResetAtStartup);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.textBoxClientName);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new Point(0x13, 0xbc);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x1a8, 0xae);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Miscellaneous";
            this.numericUpDownHistoryImages.Location = new Point(0xd7, 140);
            this.numericUpDownHistoryImages.Name = "numericUpDownHistoryImages";
            this.numericUpDownHistoryImages.Size = new Size(50, 20);
            this.numericUpDownHistoryImages.TabIndex = 0x4b;
            this.label28.AutoSize = true;
            this.label28.Location = new Point(0x11, 0x8e);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x71, 13);
            this.label28.TabIndex = 0x4a;
            this.label28.Text = "Backup history images";
            this.newSequenceSettingsTab.BackColor = Color.Transparent;
            this.newSequenceSettingsTab.Controls.Add(this.groupBox12);
            this.newSequenceSettingsTab.Controls.Add(this.groupBox8);
            this.newSequenceSettingsTab.Controls.Add(this.checkBoxWizardForNewSequences);
            this.newSequenceSettingsTab.Location = new Point(0, 0);
            this.newSequenceSettingsTab.Name = "newSequenceSettingsTab";
            this.newSequenceSettingsTab.Padding = new Padding(3);
            this.newSequenceSettingsTab.Size = new Size(0x1be, 0x19d);
            this.newSequenceSettingsTab.TabIndex = 0;
            this.newSequenceSettingsTab.Text = "newSequenceSettingsTab";
            this.groupBox12.Controls.Add(this.comboBoxDefaultAudioDevice);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.checkBoxUseDefaultPlugInData);
            this.groupBox12.Controls.Add(this.buttonPluginSetup);
            this.groupBox12.Controls.Add(this.textBoxDefaultChannelCount);
            this.groupBox12.Controls.Add(this.comboBoxDefaultProfile);
            this.groupBox12.Controls.Add(this.label22);
            this.groupBox12.Controls.Add(this.label19);
            this.groupBox12.Controls.Add(this.label18);
            this.groupBox12.Controls.Add(this.buttonCreateProfile);
            this.groupBox12.Location = new Point(0x13, 0x81);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new Size(0x1a8, 0x70);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Defaults";
            this.checkBoxUseDefaultPlugInData.AutoSize = true;
            this.checkBoxUseDefaultPlugInData.CheckAlign = ContentAlignment.TopLeft;
            this.checkBoxUseDefaultPlugInData.Location = new Point(0xd7, 0x9f);
            this.checkBoxUseDefaultPlugInData.Name = "checkBoxUseDefaultPlugInData";
            this.checkBoxUseDefaultPlugInData.Size = new Size(0x9f, 0x11);
            this.checkBoxUseDefaultPlugInData.TabIndex = 14;
            this.checkBoxUseDefaultPlugInData.Text = "Copy this to new sequences";
            this.checkBoxUseDefaultPlugInData.UseVisualStyleBackColor = true;
            this.checkBoxUseDefaultPlugInData.Visible = false;
            this.groupBox8.Controls.Add(this.numericUpDownMaximumLevel);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.numericUpDownMinimumLevel);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.textBoxEventPeriod);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Location = new Point(0x13, 14);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new Size(0x1a8, 0x6d);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Editing Grid";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0x10f, 0x19);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x3f, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "milliseconds";
            this.sequenceEditingTab.BackColor = Color.Transparent;
            this.sequenceEditingTab.Controls.Add(this.groupBox14);
            this.sequenceEditingTab.Controls.Add(this.groupBox5);
            this.sequenceEditingTab.Location = new Point(0, 0);
            this.sequenceEditingTab.Name = "sequenceEditingTab";
            this.sequenceEditingTab.Padding = new Padding(3);
            this.sequenceEditingTab.Size = new Size(0x1be, 0x19d);
            this.sequenceEditingTab.TabIndex = 1;
            this.sequenceEditingTab.Text = "sequenceEditingTab";
            this.groupBox14.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox14.Controls.Add(this.textBoxCurveLibraryFtpPassword);
            this.groupBox14.Controls.Add(this.label33);
            this.groupBox14.Controls.Add(this.textBoxCurveLibraryFtpUserName);
            this.groupBox14.Controls.Add(this.label32);
            this.groupBox14.Controls.Add(this.textBoxCurveLibraryFileName);
            this.groupBox14.Controls.Add(this.label31);
            this.groupBox14.Controls.Add(this.textBoxCurveLibraryFtpUrl);
            this.groupBox14.Controls.Add(this.label30);
            this.groupBox14.Controls.Add(this.textBoxCurveLibraryHttpUrl);
            this.groupBox14.Controls.Add(this.label29);
            this.groupBox14.Location = new Point(0x13, 0x131);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new Size(0x1a8, 0x6b);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Remote curve library";
            this.groupBox14.Visible = false;
            this.groupBox5.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox5.Controls.Add(this.textBoxDefaultSequenceSaveDirectory);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.checkBoxFlipMouseScroll);
            this.groupBox5.Controls.Add(this.checkBoxShowNaturalChannelNumber);
            this.groupBox5.Controls.Add(this.textBoxIntensityLargeDelta);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.checkBoxShowSaveConfirmation);
            this.groupBox5.Controls.Add(this.checkBoxSaveZoomLevels);
            this.groupBox5.Controls.Add(this.checkBoxEventSequenceAutoSize);
            this.groupBox5.Controls.Add(this.textBoxMaxRowHeight);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.textBoxMaxColumnWidth);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new Point(0x13, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x1a8, 0x11d);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sequence Editing";
            this.label34.AutoSize = true;
            this.label34.Location = new Point(20, 0xed);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x12e, 13);
            this.label34.TabIndex = 11;
            this.label34.Text = "Default sequence save directory: (blank for application default)";
            this.sequenceExecutionTab.BackColor = Color.Transparent;
            this.sequenceExecutionTab.Controls.Add(this.groupBox13);
            this.sequenceExecutionTab.Controls.Add(this.groupBox4);
            this.sequenceExecutionTab.Location = new Point(0, 0);
            this.sequenceExecutionTab.Name = "sequenceExecutionTab";
            this.sequenceExecutionTab.Size = new Size(0x1be, 0x19d);
            this.sequenceExecutionTab.TabIndex = 2;
            this.sequenceExecutionTab.Text = "sequenceExecutionTab";
            this.groupBox13.Controls.Add(this.textBoxLogFilePath);
            this.groupBox13.Controls.Add(this.buttonLogFilePath);
            this.groupBox13.Controls.Add(this.checkBoxLogMusicPlayer);
            this.groupBox13.Controls.Add(this.checkBoxLogScheduled);
            this.groupBox13.Controls.Add(this.checkBoxLogManual);
            this.groupBox13.Location = new Point(0x13, 0xa6);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new Size(0x1a8, 0x8b);
            this.groupBox13.TabIndex = 4;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Audio Log";
            this.groupBox4.Controls.Add(this.checkBoxClearAtEndOfSequence);
            this.groupBox4.Controls.Add(this.checkBoxShowPositionMarker);
            this.groupBox4.Controls.Add(this.checkBoxSavePlugInDialogPositions);
            this.groupBox4.Controls.Add(this.checkBoxAutoScrolling);
            this.groupBox4.Location = new Point(0x13, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x1a8, 0x7e);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sequence Execution";
            this.backgroundItemsTab.BackColor = Color.Transparent;
            this.backgroundItemsTab.Controls.Add(this.groupBox7);
            this.backgroundItemsTab.Controls.Add(this.groupBox6);
            this.backgroundItemsTab.Location = new Point(0, 0);
            this.backgroundItemsTab.Name = "backgroundItemsTab";
            this.backgroundItemsTab.Size = new Size(0x1be, 0x19d);
            this.backgroundItemsTab.TabIndex = 4;
            this.backgroundItemsTab.Text = "backgroundItemsTab";
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.textBoxMusicFadeDuration);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.checkBoxEnableMusicFade);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.textBoxBackgroundMusicDelay);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.checkBoxEnableBackgroundMusic);
            this.groupBox7.Location = new Point(0x13, 0x93);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0x1a8, 0x87);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Music";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(0x10f, 0x69);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x2f, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "seconds";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x10f, 0x30);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x2f, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "seconds";
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.textBoxBackgroundSequenceDelay);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.checkBoxEnableBackgroundSequence);
            this.groupBox6.Location = new Point(0x13, 14);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x1a8, 0x71);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sequence";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x10f, 70);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x2f, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "seconds";
            this.remoteExecutionTab.BackColor = Color.Transparent;
            this.remoteExecutionTab.Controls.Add(this.groupBox10);
            this.remoteExecutionTab.Controls.Add(this.groupBox9);
            this.remoteExecutionTab.Location = new Point(0, 0);
            this.remoteExecutionTab.Name = "remoteExecutionTab";
            this.remoteExecutionTab.Size = new Size(0x1be, 0x19d);
            this.remoteExecutionTab.TabIndex = 5;
            this.remoteExecutionTab.Text = "remoteExecutionTab";
            this.groupBox10.Controls.Add(this.radioButtonAsyncSyncObject);
            this.groupBox10.Controls.Add(this.comboBoxAsyncProfile);
            this.groupBox10.Controls.Add(this.radioButtonAsyncDefaultProfileData);
            this.groupBox10.Controls.Add(this.radioButtonAsyncProfileData);
            this.groupBox10.Controls.Add(this.label25);
            this.groupBox10.Location = new Point(0x13, 0xb2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new Size(0x1a8, 0xa9);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Channel Control";
            this.comboBoxAsyncProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxAsyncProfile.Enabled = false;
            this.comboBoxAsyncProfile.FormattingEnabled = true;
            this.comboBoxAsyncProfile.Location = new Point(0xf4, 0x76);
            this.comboBoxAsyncProfile.Name = "comboBoxAsyncProfile";
            this.comboBoxAsyncProfile.Size = new Size(160, 0x15);
            this.comboBoxAsyncProfile.TabIndex = 3;
            this.label25.Location = new Point(0x12, 0x17);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x182, 0x42);
            this.label25.TabIndex = 0;
            this.label25.Text = manager.GetString("label25.Text");
            this.groupBox9.Controls.Add(this.comboBoxSyncProfile);
            this.groupBox9.Controls.Add(this.radioButtonSyncDefaultProfileData);
            this.groupBox9.Controls.Add(this.radioButtonSyncProfileData);
            this.groupBox9.Controls.Add(this.radioButtonSyncEmbeddedData);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Location = new Point(0x13, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new Size(0x1a8, 0xa9);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Sequence Execution";
            this.comboBoxSyncProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSyncProfile.Enabled = false;
            this.comboBoxSyncProfile.FormattingEnabled = true;
            this.comboBoxSyncProfile.Location = new Point(0xf4, 0x6a);
            this.comboBoxSyncProfile.Name = "comboBoxSyncProfile";
            this.comboBoxSyncProfile.Size = new Size(160, 0x15);
            this.comboBoxSyncProfile.TabIndex = 4;
            this.label24.Location = new Point(0x15, 0x1a);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x17f, 0x2e);
            this.label24.TabIndex = 0;
            this.label24.Text = "When a sequence is executed remotely, would you like it to use its own data (for plugins and channel masking) or would you prefer to have all sequences use the same profile?";
            this.engineTab.BackColor = Color.Transparent;
            this.engineTab.Controls.Add(this.groupBox11);
            this.engineTab.Location = new Point(0, 0);
            this.engineTab.Name = "engineTab";
            this.engineTab.Size = new Size(0x1be, 0x19d);
            this.engineTab.TabIndex = 6;
            this.engineTab.Text = "engineTab";
            this.groupBox11.Controls.Add(this.buttonEngine);
            this.groupBox11.Controls.Add(this.textBoxEngine);
            this.groupBox11.Location = new Point(0x13, 14);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new Size(0x1a8, 0x40);
            this.groupBox11.TabIndex = 4;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Secondary Engine";
            this.buttonEngine.Location = new Point(0x181, 0x1a);
            this.buttonEngine.Name = "buttonEngine";
            this.buttonEngine.Size = new Size(0x18, 0x18);
            this.buttonEngine.TabIndex = 1;
            this.buttonEngine.Text = "...";
            this.buttonEngine.UseVisualStyleBackColor = true;
            this.buttonEngine.Click += new EventHandler(this.buttonEngine_Click);
            this.textBoxEngine.Location = new Point(14, 0x1c);
            this.textBoxEngine.Name = "textBoxEngine";
            this.textBoxEngine.Size = new Size(0x16d, 20);
            this.textBoxEngine.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x27d, 0x1e4);
            base.ControlBox = false;
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.tabControl);
            base.Controls.Add(this.treeView);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Name = "PreferencesDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.numericUpDownMaximumLevel.EndInit();
            this.numericUpDownMinimumLevel.EndInit();
            this.tabControl.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.numericUpDownHistoryImages.EndInit();
            this.newSequenceSettingsTab.ResumeLayout(false);
            this.newSequenceSettingsTab.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.sequenceEditingTab.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.sequenceExecutionTab.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.backgroundItemsTab.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.remoteExecutionTab.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.engineTab.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            base.ResumeLayout(false);
        }

        private void PopulateAudioDeviceList()
        {
            this.comboBoxDefaultAudioDevice.Items.Add("Use application's default device");
            this.comboBoxDefaultAudioDevice.Items.AddRange(fmod.GetSoundDeviceList());
        }

        private void PopulateFrom(int tabIndex)
        {
            if (this.m_preferences != null)
            {
                switch (tabIndex)
                {
                    case 0:
                    {
                        this.m_preferences.SetString("TimerCheckFrequency", this.textBoxTimerCheckFrequency.Text);
                        this.m_preferences.SetString("MouseWheelVerticalDelta", this.textBoxMouseWheelVertical.Text);
                        this.m_preferences.SetString("MouseWheelHorizontalDelta", this.textBoxMouseWheelHorizontal.Text);
                        this.m_preferences.SetString("ClientName", this.textBoxClientName.Text);
                        this.m_preferences.SetBoolean("ResetAtStartup", this.checkBoxResetAtStartup.Checked);
                        this.m_preferences.SetString("PreferredSequenceType", this.m_uiPlugins[this.comboBoxSequenceType.SelectedIndex].FileExtension);
                        if (!this.dateTimePickerAutoShutdownTime.Checked)
                        {
                            this.m_preferences.SetString("ShutdownTime", string.Empty);
                        }
                        else
                        {
                            this.m_preferences.SetString("ShutdownTime", this.dateTimePickerAutoShutdownTime.Value.ToString("h:mm tt"));
                        }
                        string path = Path.Combine(Paths.DataPath, "no.update");
                        if (this.checkBoxDisableAutoUpdate.Checked)
                        {
                            if (!File.Exists(path))
                            {
                                File.Create(path).Close();
                            }
                        }
                        else if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        this.m_preferences.SetInteger("HistoryImages", (int) this.numericUpDownHistoryImages.Value);
                        return;
                    }
                    case 1:
                        this.m_preferences.SetString("EventPeriod", this.textBoxEventPeriod.Text);
                        this.m_preferences.SetInteger("MinimumLevel", (int) this.numericUpDownMinimumLevel.Value);
                        this.m_preferences.SetInteger("MaximumLevel", (int) this.numericUpDownMaximumLevel.Value);
                        this.m_preferences.SetBoolean("WizardForNewSequences", this.checkBoxWizardForNewSequences.Checked);
                        if (this.comboBoxDefaultProfile.SelectedIndex != 0)
                        {
                            this.m_preferences.SetString("DefaultProfile", this.comboBoxDefaultProfile.SelectedItem.ToString());
                        }
                        else
                        {
                            this.m_preferences.SetString("DefaultProfile", string.Empty);
                        }
                        this.m_preferences.SetInteger("DefaultSequenceAudioDevice", this.comboBoxDefaultAudioDevice.SelectedIndex - 1);
                        return;

                    case 2:
                    {
                        this.m_preferences.SetString("MaxColumnWidth", this.textBoxMaxColumnWidth.Text);
                        this.m_preferences.SetString("MaxRowHeight", this.textBoxMaxRowHeight.Text);
                        int index = this.textBoxIntensityLargeDelta.Text.Trim().IndexOf('%');
                        if (index != -1)
                        {
                            this.textBoxIntensityLargeDelta.Text = this.textBoxIntensityLargeDelta.Text.Substring(0, index).Trim();
                        }
                        this.m_preferences.SetString("IntensityLargeDelta", this.textBoxIntensityLargeDelta.Text);
                        this.m_preferences.SetBoolean("EventSequenceAutoSize", this.checkBoxEventSequenceAutoSize.Checked);
                        this.m_preferences.SetBoolean("SaveZoomLevels", this.checkBoxSaveZoomLevels.Checked);
                        this.m_preferences.SetBoolean("ShowSaveConfirmation", this.checkBoxShowSaveConfirmation.Checked);
                        this.m_preferences.SetBoolean("ShowNaturalChannelNumber", this.checkBoxShowNaturalChannelNumber.Checked);
                        this.m_preferences.SetBoolean("FlipScrollBehavior", this.checkBoxFlipMouseScroll.Checked);
                        this.m_preferences.SetString("RemoteLibraryHTTPURL", this.textBoxCurveLibraryHttpUrl.Text);
                        this.m_preferences.SetString("RemoteLibraryFTPURL", this.textBoxCurveLibraryFtpUrl.Text);
                        this.m_preferences.SetString("RemoteLibraryFileName", this.textBoxCurveLibraryFileName.Text);
                        this.m_preferences.SetString("DefaultSequenceDirectory", this.textBoxDefaultSequenceSaveDirectory.Text);
                        return;
                    }
                    case 3:
                        this.m_preferences.SetBoolean("ShowPositionMarker", this.checkBoxShowPositionMarker.Checked);
                        this.m_preferences.SetBoolean("AutoScrolling", this.checkBoxAutoScrolling.Checked);
                        this.m_preferences.SetBoolean("SavePlugInDialogPositions", this.checkBoxSavePlugInDialogPositions.Checked);
                        this.m_preferences.SetBoolean("ClearAtEndOfSequence", this.checkBoxClearAtEndOfSequence.Checked);
                        this.m_preferences.SetBoolean("LogAudioManual", this.checkBoxLogManual.Checked);
                        this.m_preferences.SetBoolean("LogAudioScheduled", this.checkBoxLogScheduled.Checked);
                        this.m_preferences.SetBoolean("LogAudioMusicPlayer", this.checkBoxLogMusicPlayer.Checked);
                        this.m_preferences.SetString("AudioLogFilePath", this.textBoxLogFilePath.Text);
                        return;

                    case 4:
                        this.m_preferences.SetBoolean("EnableBackgroundSequence", this.checkBoxEnableBackgroundSequence.Checked);
                        this.m_preferences.SetString("BackgroundSequenceDelay", this.textBoxBackgroundSequenceDelay.Text);
                        this.m_preferences.SetBoolean("EnableBackgroundMusic", this.checkBoxEnableBackgroundMusic.Checked);
                        this.m_preferences.SetString("BackgroundMusicDelay", this.textBoxBackgroundMusicDelay.Text);
                        this.m_preferences.SetBoolean("EnableMusicFade", this.checkBoxEnableMusicFade.Checked);
                        this.m_preferences.SetString("MusicFadeDuration", this.textBoxMusicFadeDuration.Text);
                        return;

                    case 5:
                        if (!this.radioButtonSyncEmbeddedData.Checked)
                        {
                            if (this.radioButtonSyncDefaultProfileData.Checked || (this.comboBoxSyncProfile.SelectedItem == null))
                            {
                                this.m_preferences.SetString("SynchronousData", "Default");
                            }
                            else
                            {
                                this.m_preferences.SetString("SynchronousData", this.comboBoxSyncProfile.SelectedItem.ToString());
                            }
                        }
                        else
                        {
                            this.m_preferences.SetString("SynchronousData", "Embedded");
                        }
                        if (this.radioButtonAsyncSyncObject.Checked)
                        {
                            this.m_preferences.SetString("AsynchronousData", "Sync");
                        }
                        else if (this.radioButtonAsyncDefaultProfileData.Checked || (this.comboBoxAsyncProfile.SelectedItem == null))
                        {
                            this.m_preferences.SetString("AsynchronousData", "Default");
                        }
                        else
                        {
                            this.m_preferences.SetString("AsynchronousData", this.comboBoxAsyncProfile.SelectedItem.ToString());
                        }
                        return;

                    case 6:
                        this.m_preferences.SetString("SecondaryEngine", Path.GetFileName(this.textBoxEngine.Text));
                        return;
                }
            }
        }

        private void PopulateProfileLists()
        {
            ComboBox[] boxArray = new ComboBox[] { this.comboBoxDefaultProfile, this.comboBoxSyncProfile, this.comboBoxAsyncProfile };
            List<string> list = new List<string>();
            foreach (string str in Directory.GetFiles(Paths.ProfilePath, "*.pro"))
            {
                list.Add(Path.GetFileNameWithoutExtension(str));
            }
            foreach (ComboBox box in boxArray)
            {
                int selectedIndex = box.SelectedIndex;
                box.BeginUpdate();
                box.Items.Clear();
                box.Items.AddRange(list.ToArray());
                if (selectedIndex < box.Items.Count)
                {
                    box.SelectedIndex = selectedIndex;
                }
                box.EndUpdate();
            }
            this.comboBoxDefaultProfile.Items.Insert(0, "None");
        }

        private void PopulateTo(int tabIndex)
        {
            if (this.m_preferences != null)
            {
                switch (tabIndex)
                {
                    case 0:
                    {
                        this.textBoxTimerCheckFrequency.Text = this.m_preferences.GetString("TimerCheckFrequency");
                        this.textBoxMouseWheelVertical.Text = this.m_preferences.GetString("MouseWheelVerticalDelta");
                        this.textBoxMouseWheelHorizontal.Text = this.m_preferences.GetString("MouseWheelHorizontalDelta");
                        this.textBoxClientName.Text = this.m_preferences.GetString("ClientName");
                        this.checkBoxResetAtStartup.Checked = this.m_preferences.GetBoolean("ResetAtStartup");
                        string str = this.m_preferences.GetString("PreferredSequenceType");
                        for (int i = 0; i < this.m_uiPlugins.Length; i++)
                        {
                            if (this.m_uiPlugins[i].FileExtension == str)
                            {
                                this.comboBoxSequenceType.SelectedIndex = i;
                                break;
                            }
                        }
                        if (this.comboBoxSequenceType.SelectedIndex == -1)
                        {
                            this.comboBoxSequenceType.SelectedIndex = 0;
                        }
                        string s = this.m_preferences.GetString("ShutdownTime");
                        if (s != string.Empty)
                        {
                            this.dateTimePickerAutoShutdownTime.Checked = true;
                            this.dateTimePickerAutoShutdownTime.Value = DateTime.Parse(s);
                        }
                        this.checkBoxDisableAutoUpdate.Checked = File.Exists(Path.Combine(Paths.DataPath, "no.update"));
                        this.numericUpDownHistoryImages.Value = this.m_preferences.GetInteger("HistoryImages");
                        return;
                    }
                    case 1:
                    {
                        this.textBoxEventPeriod.Text = this.m_preferences.GetString("EventPeriod");
                        this.numericUpDownMinimumLevel.Value = this.m_preferences.GetInteger("MinimumLevel");
                        this.numericUpDownMaximumLevel.Value = this.m_preferences.GetInteger("MaximumLevel");
                        this.checkBoxWizardForNewSequences.Checked = this.m_preferences.GetBoolean("WizardForNewSequences");
                        string str3 = string.Empty;
                        if (((str3 = this.m_preferences.GetString("DefaultProfile")).Length != 0) && File.Exists(Path.Combine(Paths.ProfilePath, str3 + ".pro")))
                        {
                            this.comboBoxDefaultProfile.SelectedIndex = this.comboBoxDefaultProfile.Items.IndexOf(str3);
                        }
                        else
                        {
                            this.comboBoxDefaultProfile.SelectedIndex = 0;
                        }
                        int num2 = this.m_preferences.GetInteger("DefaultSequenceAudioDevice") + 1;
                        if (num2 < this.comboBoxDefaultAudioDevice.Items.Count)
                        {
                            this.comboBoxDefaultAudioDevice.SelectedIndex = num2;
                        }
                        else
                        {
                            this.comboBoxDefaultAudioDevice.SelectedIndex = 0;
                        }
                        return;
                    }
                    case 2:
                        this.textBoxMaxColumnWidth.Text = this.m_preferences.GetString("MaxColumnWidth");
                        this.textBoxMaxRowHeight.Text = this.m_preferences.GetString("MaxRowHeight");
                        this.textBoxIntensityLargeDelta.Text = this.m_preferences.GetString("IntensityLargeDelta");
                        this.checkBoxEventSequenceAutoSize.Checked = this.m_preferences.GetBoolean("EventSequenceAutoSize");
                        this.checkBoxSaveZoomLevels.Checked = this.m_preferences.GetBoolean("SaveZoomLevels");
                        this.checkBoxShowSaveConfirmation.Checked = this.m_preferences.GetBoolean("ShowSaveConfirmation");
                        this.checkBoxShowNaturalChannelNumber.Checked = this.m_preferences.GetBoolean("ShowNaturalChannelNumber");
                        this.checkBoxFlipMouseScroll.Checked = this.m_preferences.GetBoolean("FlipScrollBehavior");
                        this.textBoxCurveLibraryHttpUrl.Text = this.m_preferences.GetString("RemoteLibraryHTTPURL");
                        this.textBoxCurveLibraryFtpUrl.Text = this.m_preferences.GetString("RemoteLibraryFTPURL");
                        this.textBoxCurveLibraryFileName.Text = this.m_preferences.GetString("RemoteLibraryFileName");
                        this.textBoxDefaultSequenceSaveDirectory.Text = this.m_preferences.GetString("DefaultSequenceDirectory");
                        return;

                    case 3:
                        this.checkBoxShowPositionMarker.Checked = this.m_preferences.GetBoolean("ShowPositionMarker");
                        this.checkBoxAutoScrolling.Checked = this.m_preferences.GetBoolean("AutoScrolling");
                        this.checkBoxSavePlugInDialogPositions.Checked = this.m_preferences.GetBoolean("SavePlugInDialogPositions");
                        this.checkBoxClearAtEndOfSequence.Checked = this.m_preferences.GetBoolean("ClearAtEndOfSequence");
                        this.checkBoxLogManual.Checked = this.m_preferences.GetBoolean("LogAudioManual");
                        this.checkBoxLogScheduled.Checked = this.m_preferences.GetBoolean("LogAudioScheduled");
                        this.checkBoxLogMusicPlayer.Checked = this.m_preferences.GetBoolean("LogAudioMusicPlayer");
                        this.textBoxLogFilePath.Text = this.m_preferences.GetString("AudioLogFilePath");
                        return;

                    case 4:
                        this.checkBoxEnableBackgroundSequence.Checked = this.m_preferences.GetBoolean("EnableBackgroundSequence");
                        this.textBoxBackgroundSequenceDelay.Text = this.m_preferences.GetString("BackgroundSequenceDelay");
                        this.checkBoxEnableBackgroundMusic.Checked = this.m_preferences.GetBoolean("EnableBackgroundMusic");
                        this.textBoxBackgroundMusicDelay.Text = this.m_preferences.GetString("BackgroundMusicDelay");
                        this.checkBoxEnableMusicFade.Checked = this.m_preferences.GetBoolean("EnableMusicFade");
                        this.textBoxMusicFadeDuration.Text = this.m_preferences.GetString("MusicFadeDuration");
                        return;

                    case 5:
                    {
                        string str4 = this.m_preferences.GetString("SynchronousData");
                        if (!(str4 == "Embedded"))
                        {
                            if (str4 == "Default")
                            {
                                this.radioButtonSyncDefaultProfileData.Checked = true;
                            }
                            else
                            {
                                this.radioButtonSyncProfileData.Checked = true;
                                this.comboBoxSyncProfile.SelectedIndex = this.comboBoxSyncProfile.Items.IndexOf(str4);
                            }
                        }
                        else
                        {
                            this.radioButtonSyncEmbeddedData.Checked = true;
                        }
                        str4 = this.m_preferences.GetString("AsynchronousData");
                        if (str4 == "Sync")
                        {
                            this.radioButtonAsyncSyncObject.Checked = true;
                        }
                        else if (str4 == "Default")
                        {
                            this.radioButtonAsyncDefaultProfileData.Checked = true;
                        }
                        else
                        {
                            this.radioButtonAsyncProfileData.Checked = true;
                            this.comboBoxAsyncProfile.SelectedIndex = this.comboBoxAsyncProfile.Items.IndexOf(str4);
                        }
                        return;
                    }
                    case 6:
                        this.textBoxEngine.Text = Path.GetFileName(this.m_preferences.GetString("SecondaryEngine"));
                        return;
                }
            }
        }

        private void radioButtonAsyncProfileData_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxAsyncProfile.Enabled = this.radioButtonAsyncProfileData.Checked;
            if (this.comboBoxAsyncProfile.Enabled && (this.comboBoxAsyncProfile.SelectedIndex == -1))
            {
                this.comboBoxAsyncProfile.SelectedIndex = 0;
            }
        }

        private void radioButtonSyncProfileData_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxSyncProfile.Enabled = this.radioButtonSyncProfileData.Checked;
            if (this.comboBoxSyncProfile.Enabled && (this.comboBoxSyncProfile.SelectedIndex == -1))
            {
                this.comboBoxSyncProfile.SelectedIndex = 0;
            }
        }

        private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            this.PopulateFrom(e.TabPageIndex);
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            this.PopulateTo(e.TabPageIndex);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                this.tabControl.SelectedTab = (TabPage) e.Node.Tag;
            }
        }
    }
}

