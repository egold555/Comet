using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenPlus.Dialogs {
    public partial class NewSequenceWizardDialog {
        private IContainer components = null;

        #region Windows Form Designer generated code

        private Button buttonAssignAudio;
        private Button buttonCancel;
        private Button buttonImportChannels;
        private Button buttonNext;
        private Button buttonOK;
        private Button buttonPrev;
        private Button buttonProfileManager;
        private Button buttonSetupPlugins;
        private Button buttonSkip;
        private ComboBox comboBoxProfiles;
        private GroupBox groupBox1;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelEffect;
        private Label labelExplanation;
        private Label labelNamesChannels;
        private Label labelNotes;
        private Label labelWhat;
        private Label labelWhy;
        private OpenFileDialog openFileDialog;
        private TabControl tabControl;
        private TabPage tabPageAudio;
        private TabPage tabPageChannelCount;
        private TabPage tabPageChannelNames;
        private TabPage tabPageEventPeriod;
        private TabPage tabPagePlugin;
        private TabPage tabPageProfile;
        private TabPage tabPageStart;
        private TabPage tabPageTime;
        private TextBox textBoxChannelCount;
        private TextBox textBoxChannelNames;
        private TextBox textBoxEventPeriod;
        private TextBox textBoxTime;


        private void InitializeComponent() {
            this.tabControl = new TabControl();
            this.tabPageStart = new TabPage();
            this.label2 = new Label();
            this.label1 = new Label();
            this.tabPageEventPeriod = new TabPage();
            this.label12 = new Label();
            this.textBoxEventPeriod = new TextBox();
            this.label7 = new Label();
            this.tabPageProfile = new TabPage();
            this.comboBoxProfiles = new ComboBox();
            this.label16 = new Label();
            this.label14 = new Label();
            this.buttonProfileManager = new Button();
            this.label15 = new Label();
            this.tabPageChannelCount = new TabPage();
            this.buttonImportChannels = new Button();
            this.label9 = new Label();
            this.textBoxChannelCount = new TextBox();
            this.label3 = new Label();
            this.tabPageChannelNames = new TabPage();
            this.labelNamesChannels = new Label();
            this.textBoxChannelNames = new TextBox();
            this.label10 = new Label();
            this.label4 = new Label();
            this.tabPagePlugin = new TabPage();
            this.label13 = new Label();
            this.buttonSetupPlugins = new Button();
            this.label8 = new Label();
            this.tabPageAudio = new TabPage();
            this.buttonAssignAudio = new Button();
            this.label5 = new Label();
            this.tabPageTime = new TabPage();
            this.label11 = new Label();
            this.textBoxTime = new TextBox();
            this.label6 = new Label();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox1 = new GroupBox();
            this.labelExplanation = new Label();
            this.labelNotes = new Label();
            this.labelEffect = new Label();
            this.labelWhy = new Label();
            this.labelWhat = new Label();
            this.buttonPrev = new Button();
            this.buttonNext = new Button();
            this.buttonSkip = new Button();
            this.openFileDialog = new OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPageStart.SuspendLayout();
            this.tabPageEventPeriod.SuspendLayout();
            this.tabPageProfile.SuspendLayout();
            this.tabPageChannelCount.SuspendLayout();
            this.tabPageChannelNames.SuspendLayout();
            this.tabPagePlugin.SuspendLayout();
            this.tabPageAudio.SuspendLayout();
            this.tabPageTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor =
                ((AnchorStyles)
                 ((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) |
                   AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageStart);
            this.tabControl.Controls.Add(this.tabPageEventPeriod);
            this.tabControl.Controls.Add(this.tabPageProfile);
            this.tabControl.Controls.Add(this.tabPageChannelCount);
            this.tabControl.Controls.Add(this.tabPageChannelNames);
            this.tabControl.Controls.Add(this.tabPagePlugin);
            this.tabControl.Controls.Add(this.tabPageAudio);
            this.tabControl.Controls.Add(this.tabPageTime);
            this.tabControl.Location = new Point(0, -22);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(448, 271);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new TabControlEventHandler(this.tabControl_Selected);
            this.tabControl.Deselecting += new TabControlCancelEventHandler(this.tabControl_Deselecting);
            // 
            // tabPageStart
            // 
            this.tabPageStart.Controls.Add(this.label2);
            this.tabPageStart.Controls.Add(this.label1);
            this.tabPageStart.Location = new Point(4, 22);
            this.tabPageStart.Name = "tabPageStart";
            this.tabPageStart.Size = new Size(440, 245);
            this.tabPageStart.TabIndex = 7;
            this.tabPageStart.Text = "tabPageStart";
            this.tabPageStart.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(391, 114);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.label1.Location = new Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(181, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Sequence Wizard";
            // 
            // tabPageEventPeriod
            // 
            this.tabPageEventPeriod.Controls.Add(this.label12);
            this.tabPageEventPeriod.Controls.Add(this.textBoxEventPeriod);
            this.tabPageEventPeriod.Controls.Add(this.label7);
            this.tabPageEventPeriod.Location = new Point(4, 22);
            this.tabPageEventPeriod.Name = "tabPageEventPeriod";
            this.tabPageEventPeriod.Size = new Size(440, 245);
            this.tabPageEventPeriod.TabIndex = 8;
            this.tabPageEventPeriod.Text = "tabPageEventPeriod";
            this.tabPageEventPeriod.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new Point(216, 115);
            this.label12.Name = "label12";
            this.label12.Size = new Size(63, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "milliseconds";
            // 
            // textBoxEventPeriod
            // 
            this.textBoxEventPeriod.Location = new Point(175, 112);
            this.textBoxEventPeriod.Name = "textBoxEventPeriod";
            this.textBoxEventPeriod.Size = new Size(35, 20);
            this.textBoxEventPeriod.TabIndex = 4;
            this.textBoxEventPeriod.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.label7.Location = new Point(24, 20);
            this.label7.Name = "label7";
            this.label7.Size = new Size(107, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Event Period";
            // 
            // tabPageProfile
            // 
            this.tabPageProfile.Controls.Add(this.comboBoxProfiles);
            this.tabPageProfile.Controls.Add(this.label16);
            this.tabPageProfile.Controls.Add(this.label14);
            this.tabPageProfile.Controls.Add(this.buttonProfileManager);
            this.tabPageProfile.Controls.Add(this.label15);
            this.tabPageProfile.Location = new Point(4, 22);
            this.tabPageProfile.Name = "tabPageProfile";
            this.tabPageProfile.Size = new Size(440, 245);
            this.tabPageProfile.TabIndex = 9;
            this.tabPageProfile.Text = "tabPageProfile";
            this.tabPageProfile.UseVisualStyleBackColor = true;
            // 
            // comboBoxProfiles
            // 
            this.comboBoxProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxProfiles.FormattingEnabled = true;
            this.comboBoxProfiles.Location = new Point(141, 105);
            this.comboBoxProfiles.Name = "comboBoxProfiles";
            this.comboBoxProfiles.Size = new Size(159, 21);
            this.comboBoxProfiles.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new Point(62, 186);
            this.label16.Name = "label16";
            this.label16.Size = new Size(332, 26);
            this.label16.TabIndex = 4;
            this.label16.Text = "If you don\'t want to use a profile at this point, you can manually\r\ndefine channe" +
                                "ls and setup output plugins by clicking the Skip button.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new Point(62, 51);
            this.label14.Name = "label14";
            this.label14.Size = new Size(312, 39);
            this.label14.TabIndex = 1;
            this.label14.Text = "If you have a default profile defined in the user preferences, this\r\nsequence is " +
                                "already using it.  You may edit or verify it at this point\r\nif you would like, o" +
                                "r create a new one altogether.";
            // 
            // buttonProfileManager
            // 
            this.buttonProfileManager.Location = new Point(172, 132);
            this.buttonProfileManager.Name = "buttonProfileManager";
            this.buttonProfileManager.Size = new Size(97, 23);
            this.buttonProfileManager.TabIndex = 3;
            this.buttonProfileManager.Text = "Profile Manager";
            this.buttonProfileManager.UseVisualStyleBackColor = true;
            this.buttonProfileManager.Click += new EventHandler(this.buttonProfileManager_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            this.label15.Location = new Point(24, 20);
            this.label15.Name = "label15";
            this.label15.Size = new Size(58, 19);
            this.label15.TabIndex = 0;
            this.label15.Text = "Profile";
            // 
            // tabPageChannelCount
            // 
            this.tabPageChannelCount.Controls.Add(this.buttonImportChannels);
            this.tabPageChannelCount.Controls.Add(this.label9);
            this.tabPageChannelCount.Controls.Add(this.textBoxChannelCount);
            this.tabPageChannelCount.Controls.Add(this.label3);
            this.tabPageChannelCount.Location = new Point(4, 22);
            this.tabPageChannelCount.Name = "tabPageChannelCount";
            this.tabPageChannelCount.Padding = new Padding(3);
            this.tabPageChannelCount.Size = new Size(440, 245);
            this.tabPageChannelCount.TabIndex = 1;
            this.tabPageChannelCount.Text = "tabPageChannelCount";
            this.tabPageChannelCount.UseVisualStyleBackColor = true;
            // 
            // buttonImportChannels
            // 
            this.buttonImportChannels.Location = new Point(170, 134);
            this.buttonImportChannels.Name = "buttonImportChannels";
            this.buttonImportChannels.Size = new Size(100, 23);
            this.buttonImportChannels.TabIndex = 7;
            this.buttonImportChannels.Text = "Import channels";
            this.buttonImportChannels.UseVisualStyleBackColor = true;
            this.buttonImportChannels.Click += new EventHandler(this.buttonImportChannels_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new Point(216, 90);
            this.label9.Name = "label9";
            this.label9.Size = new Size(50, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "channels";
            // 
            // textBoxChannelCount
            // 
            this.textBoxChannelCount.Location = new Point(175, 87);
            this.textBoxChannelCount.Name = "textBoxChannelCount";
            this.textBoxChannelCount.Size = new Size(35, 20);
            this.textBoxChannelCount.TabIndex = 2;
            this.textBoxChannelCount.Text = "16";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new Point(24, 20);
            this.label3.Name = "label3";
            this.label3.Size = new Size(124, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Channel Count";
            // 
            // tabPageChannelNames
            // 
            this.tabPageChannelNames.Controls.Add(this.labelNamesChannels);
            this.tabPageChannelNames.Controls.Add(this.textBoxChannelNames);
            this.tabPageChannelNames.Controls.Add(this.label10);
            this.tabPageChannelNames.Controls.Add(this.label4);
            this.tabPageChannelNames.Location = new Point(4, 22);
            this.tabPageChannelNames.Name = "tabPageChannelNames";
            this.tabPageChannelNames.Size = new Size(440, 245);
            this.tabPageChannelNames.TabIndex = 2;
            this.tabPageChannelNames.Text = "tabPageChannelNames";
            this.tabPageChannelNames.UseVisualStyleBackColor = true;
            // 
            // labelNamesChannels
            // 
            this.labelNamesChannels.AutoSize = true;
            this.labelNamesChannels.Location = new Point(144, 190);
            this.labelNamesChannels.Name = "labelNamesChannels";
            this.labelNamesChannels.Size = new Size(0, 13);
            this.labelNamesChannels.TabIndex = 5;
            // 
            // textBoxChannelNames
            // 
            this.textBoxChannelNames.Location = new Point(147, 78);
            this.textBoxChannelNames.Multiline = true;
            this.textBoxChannelNames.Name = "textBoxChannelNames";
            this.textBoxChannelNames.ScrollBars = ScrollBars.Vertical;
            this.textBoxChannelNames.Size = new Size(143, 105);
            this.textBoxChannelNames.TabIndex = 4;
            this.textBoxChannelNames.TextChanged += new EventHandler(this.textBoxChannelNames_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new Point(144, 53);
            this.label10.Name = "label10";
            this.label10.Size = new Size(146, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Edit this list of channel names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new Point(24, 20);
            this.label4.Name = "label4";
            this.label4.Size = new Size(130, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Channel Names";
            // 
            // tabPagePlugin
            // 
            this.tabPagePlugin.Controls.Add(this.label13);
            this.tabPagePlugin.Controls.Add(this.buttonSetupPlugins);
            this.tabPagePlugin.Controls.Add(this.label8);
            this.tabPagePlugin.Location = new Point(4, 22);
            this.tabPagePlugin.Name = "tabPagePlugin";
            this.tabPagePlugin.Size = new Size(440, 245);
            this.tabPagePlugin.TabIndex = 6;
            this.tabPagePlugin.Text = "tabPagePlugin";
            this.tabPagePlugin.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new Point(62, 51);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0, 13);
            this.label13.TabIndex = 7;
            // 
            // buttonSetupPlugins
            // 
            this.buttonSetupPlugins.Location = new Point(172, 115);
            this.buttonSetupPlugins.Name = "buttonSetupPlugins";
            this.buttonSetupPlugins.Size = new Size(97, 23);
            this.buttonSetupPlugins.TabIndex = 6;
            this.buttonSetupPlugins.Text = "Setup Plugins";
            this.buttonSetupPlugins.UseVisualStyleBackColor = true;
            this.buttonSetupPlugins.Click += new EventHandler(this.buttonSetupPlugins_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            this.label8.Location = new Point(24, 20);
            this.label8.Name = "label8";
            this.label8.Size = new Size(163, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "Output Plugin Setup";
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.buttonAssignAudio);
            this.tabPageAudio.Controls.Add(this.label5);
            this.tabPageAudio.Location = new Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Size = new Size(440, 245);
            this.tabPageAudio.TabIndex = 3;
            this.tabPageAudio.Text = "tabPageAudio";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // buttonAssignAudio
            // 
            this.buttonAssignAudio.Location = new Point(111, 115);
            this.buttonAssignAudio.Name = "buttonAssignAudio";
            this.buttonAssignAudio.Size = new Size(218, 23);
            this.buttonAssignAudio.TabIndex = 3;
            this.buttonAssignAudio.Text = "Assign audio / Define event patterns";
            this.buttonAssignAudio.UseVisualStyleBackColor = true;
            this.buttonAssignAudio.Click += new EventHandler(this.buttonAssignAudio_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new Point(24, 20);
            this.label5.Name = "label5";
            this.label5.Size = new Size(203, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Audio and Event Patterns";
            // 
            // tabPageTime
            // 
            this.tabPageTime.Controls.Add(this.label11);
            this.tabPageTime.Controls.Add(this.textBoxTime);
            this.tabPageTime.Controls.Add(this.label6);
            this.tabPageTime.Location = new Point(4, 22);
            this.tabPageTime.Name = "tabPageTime";
            this.tabPageTime.Size = new Size(440, 245);
            this.tabPageTime.TabIndex = 4;
            this.tabPageTime.Text = "tabPageTime";
            this.tabPageTime.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new Point(142, 110);
            this.label11.Name = "label11";
            this.label11.Size = new Size(157, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "minutes : seconds . milliseconds";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new Point(187, 87);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new Size(66, 20);
            this.textBoxTime.TabIndex = 3;
            this.textBoxTime.Text = "5:00.000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new Point(24, 20);
            this.label6.Name = "label6";
            this.label6.Size = new Size(127, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sequence Time";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor =
                ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(279, 466);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "Create It";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor =
                ((AnchorStyles) ((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(360, 466);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor =
                ((AnchorStyles)
                 (((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelExplanation);
            this.groupBox1.Controls.Add(this.labelNotes);
            this.groupBox1.Controls.Add(this.labelEffect);
            this.groupBox1.Controls.Add(this.labelWhy);
            this.groupBox1.Controls.Add(this.labelWhat);
            this.groupBox1.Location = new Point(12, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(421, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Explanations";
            // 
            // labelExplanation
            // 
            this.labelExplanation.Location = new Point(90, 26);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new Size(316, 100);
            this.labelExplanation.TabIndex = 4;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold,
                                                           GraphicsUnit.Point, ((byte) (0)));
            this.labelNotes.Location = new Point(15, 114);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new Size(51, 13);
            this.labelNotes.TabIndex = 3;
            this.labelNotes.Text = "Notes >";
            this.labelNotes.Click += new EventHandler(this.labelNotes_Click);
            // 
            // labelEffect
            // 
            this.labelEffect.AutoSize = true;
            this.labelEffect.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold,
                                                            GraphicsUnit.Point, ((byte) (0)));
            this.labelEffect.Location = new Point(14, 85);
            this.labelEffect.Name = "labelEffect";
            this.labelEffect.Size = new Size(52, 13);
            this.labelEffect.TabIndex = 2;
            this.labelEffect.Text = "Effect >";
            this.labelEffect.Click += new EventHandler(this.labelEffect_Click);
            // 
            // labelWhy
            // 
            this.labelWhy.AutoSize = true;
            this.labelWhy.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold,
                                                         GraphicsUnit.Point, ((byte) (0)));
            this.labelWhy.Location = new Point(15, 56);
            this.labelWhy.Name = "labelWhy";
            this.labelWhy.Size = new Size(51, 13);
            this.labelWhy.TabIndex = 1;
            this.labelWhy.Text = "Why   >";
            this.labelWhy.Click += new EventHandler(this.labelWhy_Click);
            // 
            // labelWhat
            // 
            this.labelWhat.AutoSize = true;
            this.labelWhat.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold,
                                                          GraphicsUnit.Point, ((byte) (0)));
            this.labelWhat.Location = new Point(14, 27);
            this.labelWhat.Name = "labelWhat";
            this.labelWhat.Size = new Size(52, 13);
            this.labelWhat.TabIndex = 0;
            this.labelWhat.Text = "What  >";
            this.labelWhat.Click += new EventHandler(this.labelWhat_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Enabled = false;
            this.buttonPrev.Location = new Point(198, 255);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new Size(75, 23);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Text = "<  &Prev";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new Point(360, 255);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new Size(75, 23);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "&Next  >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new EventHandler(this.buttonNext_Click);
            // 
            // buttonSkip
            // 
            this.buttonSkip.Location = new Point(279, 255);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new Size(75, 23);
            this.buttonSkip.TabIndex = 2;
            this.buttonSkip.Text = "Skip";
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new EventHandler(this.buttonSkip_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "vix";
            this.openFileDialog.Filter = "Vixen event sequence | *.vix";
            // 
            // NewSequenceWizardDialog
            // 
            this.AcceptButton = this.buttonNext;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(447, 501);
            this.Controls.Add(this.buttonSkip);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Name = "NewSequenceWizardDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "New Sequence Wizard";
            this.tabControl.ResumeLayout(false);
            this.tabPageStart.ResumeLayout(false);
            this.tabPageStart.PerformLayout();
            this.tabPageEventPeriod.ResumeLayout(false);
            this.tabPageEventPeriod.PerformLayout();
            this.tabPageProfile.ResumeLayout(false);
            this.tabPageProfile.PerformLayout();
            this.tabPageChannelCount.ResumeLayout(false);
            this.tabPageChannelCount.PerformLayout();
            this.tabPageChannelNames.ResumeLayout(false);
            this.tabPageChannelNames.PerformLayout();
            this.tabPagePlugin.ResumeLayout(false);
            this.tabPagePlugin.PerformLayout();
            this.tabPageAudio.ResumeLayout(false);
            this.tabPageAudio.PerformLayout();
            this.tabPageTime.ResumeLayout(false);
            this.tabPageTime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
