namespace VixenPlus.Dialogs{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;

    public sealed partial class PluginListDialog{
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code
        private Button buttonCancel;
private Button buttonInput;
private Button buttonOK;
private Button buttonPluginSetup;
private Button buttonRemove;
private Button buttonUse;
private CheckedListBox checkedListBoxSequencePlugins;
private ColumnHeader columnHeaderExpandButton;
private ColumnHeader columnHeaderPluginName;
private ColumnHeader columnHeaderPortTypeIndex;
private ColumnHeader columnHeaderPortTypeName;
private GroupBox groupBox1;
private Label label1;
private Label label2;
private Label label3;
private Label label4;
private ListView listViewOutputPorts;
private ListView listViewPlugins;
private PictureBox pictureBoxMinus;
private PictureBox pictureBoxPlus;
private ColumnHeader pluginName;
private TextBox textBoxChannelFrom;
private TextBox textBoxChannelTo;

        private void InitializeComponent()
        {
            ListViewGroup group = new ListViewGroup("Output", HorizontalAlignment.Left);
            ListViewGroup group2 = new ListViewGroup("Input", HorizontalAlignment.Left);
            this.buttonUse = new Button();
            this.label1 = new Label();
            this.textBoxChannelFrom = new TextBox();
            this.label2 = new Label();
            this.textBoxChannelTo = new TextBox();
            this.buttonPluginSetup = new Button();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.checkedListBoxSequencePlugins = new CheckedListBox();
            this.groupBox1 = new GroupBox();
            this.listViewOutputPorts = new ListView();
            this.columnHeaderPortTypeName = new ColumnHeader();
            this.columnHeaderPortTypeIndex = new ColumnHeader();
            this.columnHeaderExpandButton = new ColumnHeader();
            this.columnHeaderPluginName = new ColumnHeader();
            this.buttonRemove = new Button();
            this.pictureBoxPlus = new PictureBox();
            this.pictureBoxMinus = new PictureBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.buttonInput = new Button();
            this.listViewPlugins = new ListView();
            this.pluginName = new ColumnHeader();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.pictureBoxPlus).BeginInit();
            ((ISupportInitialize) this.pictureBoxMinus).BeginInit();
            base.SuspendLayout();
            this.buttonUse.Enabled = false;
            this.buttonUse.Location = new Point(214, 121);
            this.buttonUse.Name = "buttonUse";
            this.buttonUse.Size = new Size(75, 23);
            this.buttonUse.TabIndex = 2;
            this.buttonUse.Text = "--- Use -->";
            this.buttonUse.UseVisualStyleBackColor = true;
            this.buttonUse.Click += new EventHandler(this.buttonUse_Click);
            this.label1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(513, 32);
            this.label1.Name = "label1";
            this.label1.Size = new Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Channels";
            this.textBoxChannelFrom.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.textBoxChannelFrom.Location = new Point(490, 58);
            this.textBoxChannelFrom.MaxLength = 4;
            this.textBoxChannelFrom.Name = "textBoxChannelFrom";
            this.textBoxChannelFrom.Size = new Size(34, 20);
            this.textBoxChannelFrom.TabIndex = 7;
            this.label2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(530, 61);
            this.label2.Name = "label2";
            this.label2.Size = new Size(16, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "to";
            this.textBoxChannelTo.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.textBoxChannelTo.Location = new Point(552, 58);
            this.textBoxChannelTo.MaxLength = 4;
            this.textBoxChannelTo.Name = "textBoxChannelTo";
            this.textBoxChannelTo.Size = new Size(34, 20);
            this.textBoxChannelTo.TabIndex = 9;
            this.buttonPluginSetup.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonPluginSetup.Enabled = false;
            this.buttonPluginSetup.Location = new Point(502, 84);
            this.buttonPluginSetup.Name = "buttonPluginSetup";
            this.buttonPluginSetup.Size = new Size(75, 23);
            this.buttonPluginSetup.TabIndex = 10;
            this.buttonPluginSetup.Text = "Plugin Setup";
            this.buttonPluginSetup.UseVisualStyleBackColor = true;
            this.buttonPluginSetup.Click += new EventHandler(this.buttonPluginSetup_Click);
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new Point(507, 273);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(75, 23);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "Done";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new Point(507, 244);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.checkedListBoxSequencePlugins.FormattingEnabled = true;
            this.checkedListBoxSequencePlugins.Location = new Point(298, 33);
            this.checkedListBoxSequencePlugins.Name = "checkedListBoxSequencePlugins";
            this.checkedListBoxSequencePlugins.Size = new Size(171, 139);
            this.checkedListBoxSequencePlugins.TabIndex = 5;
            this.checkedListBoxSequencePlugins.SelectedIndexChanged += new EventHandler(this.listBoxSequencePlugins_SelectedIndexChanged);
            this.checkedListBoxSequencePlugins.ItemCheck += new ItemCheckEventHandler(this.checkedListBoxSequencePlugins_ItemCheck);
            this.checkedListBoxSequencePlugins.DoubleClick += new EventHandler(this.checkedListBoxSequencePlugins_DoubleClick);
            this.checkedListBoxSequencePlugins.KeyDown += new KeyEventHandler(this.listBoxSequencePlugins_KeyDown);
            this.groupBox1.Controls.Add(this.listViewOutputPorts);
            this.groupBox1.Location = new Point(12, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(457, 118);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Configurations";
            this.listViewOutputPorts.Columns.AddRange(new ColumnHeader[] { this.columnHeaderPortTypeName, this.columnHeaderPortTypeIndex, this.columnHeaderExpandButton, this.columnHeaderPluginName });
            this.listViewOutputPorts.HeaderStyle = ColumnHeaderStyle.None;
            this.listViewOutputPorts.Location = new Point(6, 19);
            this.listViewOutputPorts.Name = "listViewOutputPorts";
            this.listViewOutputPorts.OwnerDraw = true;
            this.listViewOutputPorts.Size = new Size(445, 93);
            this.listViewOutputPorts.TabIndex = 0;
            this.listViewOutputPorts.UseCompatibleStateImageBehavior = false;
            this.listViewOutputPorts.View = View.Details;
            this.listViewOutputPorts.DrawItem += new DrawListViewItemEventHandler(this.listViewOutputPorts_DrawItem);
            this.listViewOutputPorts.MouseDown += new MouseEventHandler(this.listViewOutputPorts_MouseDown);
            this.listViewOutputPorts.DrawSubItem += new DrawListViewSubItemEventHandler(this.listViewOutputPorts_DrawSubItem);
            this.columnHeaderPortTypeName.Text = "PortTypeName";
            this.columnHeaderPortTypeName.Width = 55;
            this.columnHeaderPortTypeIndex.Text = "PortTypeIndex";
            this.columnHeaderPortTypeIndex.Width = 41;
            this.columnHeaderExpandButton.Text = "";
            this.columnHeaderExpandButton.Width = 41;
            this.columnHeaderPluginName.Text = "PluginName";
            this.columnHeaderPluginName.Width = 251;
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new Point(214, 150);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new EventHandler(this.buttonRemove_Click);
            this.pictureBoxPlus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.pictureBoxPlus.Location = new Point(498, 125);
            this.pictureBoxPlus.Name = "pictureBoxPlus";
            this.pictureBoxPlus.Size = new Size(9, 9);
            this.pictureBoxPlus.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBoxPlus.TabIndex = 12;
            this.pictureBoxPlus.TabStop = false;
            this.pictureBoxPlus.Visible = false;
            this.pictureBoxMinus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.pictureBoxMinus.Location = new Point(513, 125);
            this.pictureBoxMinus.Name = "pictureBoxMinus";
            this.pictureBoxMinus.Size = new Size(9, 9);
            this.pictureBoxMinus.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBoxMinus.TabIndex = 13;
            this.pictureBoxMinus.TabStop = false;
            this.pictureBoxMinus.Visible = false;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Available Plugins";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(295, 12);
            this.label4.Name = "label4";
            this.label4.Size = new Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Plugins in Use";
            this.buttonInput.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.buttonInput.Enabled = false;
            this.buttonInput.Location = new Point(502, 149);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new Size(75, 23);
            this.buttonInput.TabIndex = 11;
            this.buttonInput.Text = "Inputs";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new EventHandler(this.buttonInput_Click);
            this.listViewPlugins.Columns.AddRange(new ColumnHeader[] { this.pluginName });
            group.Header = "Output";
            group.Name = "listViewGroupOutput";
            group2.Header = "Input";
            group2.Name = "listViewGroupInput";
            this.listViewPlugins.Groups.AddRange(new ListViewGroup[] { group, group2 });
            this.listViewPlugins.HeaderStyle = ColumnHeaderStyle.None;
            this.listViewPlugins.HideSelection = false;
            this.listViewPlugins.Location = new Point(12, 32);
            this.listViewPlugins.MultiSelect = false;
            this.listViewPlugins.Name = "listViewPlugins";
            this.listViewPlugins.Size = new Size(196, 139);
            this.listViewPlugins.TabIndex = 15;
            this.listViewPlugins.UseCompatibleStateImageBehavior = false;
            this.listViewPlugins.View = View.Details;
            this.listViewPlugins.SelectedIndexChanged += new EventHandler(this.listViewPlugins_SelectedIndexChanged);
            this.listViewPlugins.DoubleClick += new EventHandler(this.listViewPlugins_DoubleClick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(594, 308);
            base.Controls.Add(this.listViewPlugins);
            base.Controls.Add(this.buttonInput);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.pictureBoxMinus);
            base.Controls.Add(this.pictureBoxPlus);
            base.Controls.Add(this.buttonRemove);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.checkedListBoxSequencePlugins);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.buttonPluginSetup);
            base.Controls.Add(this.textBoxChannelTo);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBoxChannelFrom);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.buttonUse);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "PluginListDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sequence Plugin Mapping";
            base.Load += new EventHandler(this.PluginListDialog_Load);
            base.FormClosing += new FormClosingEventHandler(this.PluginListDialog_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.pictureBoxPlus).EndInit();
            ((ISupportInitialize) this.pictureBoxMinus).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
