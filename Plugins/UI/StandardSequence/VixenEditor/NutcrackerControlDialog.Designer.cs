using System.Windows.Forms;

using NutcrackerEffectsControl;

namespace VixenEditor
{
    partial class NutcrackerControlDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NutcrackerControlDialog));
            this.gbEffect2 = new System.Windows.Forms.GroupBox();
            this.nutcrackerEffectControl2 = new NutcrackerEffectsControl.NutcrackerEffectControl();
            this.gbEffect1 = new System.Windows.Forms.GroupBox();
            this.nutcrackerEffectControl1 = new NutcrackerEffectsControl.NutcrackerEffectControl();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbRenderTo = new System.Windows.Forms.GroupBox();
            this.lblStartEventTime = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lblStartEvent = new System.Windows.Forms.Label();
            this.lblNumEventsTime = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfEvents = new System.Windows.Forms.Label();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.rbSpecificPoint = new System.Windows.Forms.RadioButton();
            this.rbCurrentPointOrRange = new System.Windows.Forms.RadioButton();
            this.rbRoutine = new System.Windows.Forms.RadioButton();
            this.rbClipboard = new System.Windows.Forms.RadioButton();
            this.cbModels = new System.Windows.Forms.ComboBox();
            this.btnPlayStop = new System.Windows.Forms.Button();
            this.btnModels = new System.Windows.Forms.Button();
            this.chkBoxEnableRawPreview = new System.Windows.Forms.CheckBox();
            this.pbRawPreview = new System.Windows.Forms.PictureBox();
            this.btnLightsOff = new System.Windows.Forms.Button();
            this.btnManagePresets = new System.Windows.Forms.Button();
            this.gbLayer = new System.Windows.Forms.GroupBox();
            this.rbAverage = new System.Windows.Forms.RadioButton();
            this.rbLayer = new System.Windows.Forms.RadioButton();
            this.rbUnmask2 = new System.Windows.Forms.RadioButton();
            this.rbUnmask1 = new System.Windows.Forms.RadioButton();
            this.rbMask2 = new System.Windows.Forms.RadioButton();
            this.rbMask1 = new System.Windows.Forms.RadioButton();
            this.rbEffect2 = new System.Windows.Forms.RadioButton();
            this.rbEffect1 = new System.Windows.Forms.RadioButton();
            this.cbRender = new System.Windows.Forms.CheckBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.nudColumns = new System.Windows.Forms.NumericUpDown();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timerRender = new System.Windows.Forms.Timer(this.components);
            this.gbEffect2.SuspendLayout();
            this.gbEffect1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.gbRenderTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRawPreview)).BeginInit();
            this.gbLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEffect2
            // 
            this.gbEffect2.Controls.Add(this.nutcrackerEffectControl2);
            this.gbEffect2.Location = new System.Drawing.Point(788, 304);
            this.gbEffect2.Name = "gbEffect2";
            this.gbEffect2.Size = new System.Drawing.Size(384, 250);
            this.gbEffect2.TabIndex = 0;
            this.gbEffect2.TabStop = false;
            this.gbEffect2.Text = "Effect 2";
            // 
            // nutcrackerEffectControl2
            // 
            this.nutcrackerEffectControl2.Location = new System.Drawing.Point(7, 20);
            this.nutcrackerEffectControl2.Name = "nutcrackerEffectControl2";
            this.nutcrackerEffectControl2.Size = new System.Drawing.Size(371, 225);
            this.nutcrackerEffectControl2.TabIndex = 0;
            // 
            // gbEffect1
            // 
            this.gbEffect1.Controls.Add(this.nutcrackerEffectControl1);
            this.gbEffect1.Location = new System.Drawing.Point(398, 304);
            this.gbEffect1.Name = "gbEffect1";
            this.gbEffect1.Size = new System.Drawing.Size(384, 250);
            this.gbEffect1.TabIndex = 1;
            this.gbEffect1.TabStop = false;
            this.gbEffect1.Text = "Effect 1";
            // 
            // nutcrackerEffectControl1
            // 
            this.nutcrackerEffectControl1.Location = new System.Drawing.Point(7, 20);
            this.nutcrackerEffectControl1.Name = "nutcrackerEffectControl1";
            this.nutcrackerEffectControl1.Size = new System.Drawing.Size(371, 225);
            this.nutcrackerEffectControl1.TabIndex = 0;
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.Black;
            this.pbPreview.Location = new System.Drawing.Point(12, 12);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(380, 538);
            this.pbPreview.TabIndex = 2;
            this.pbPreview.TabStop = false;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblInfo);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.gbRenderTo);
            this.gbSettings.Controls.Add(this.cbModels);
            this.gbSettings.Controls.Add(this.btnPlayStop);
            this.gbSettings.Controls.Add(this.btnModels);
            this.gbSettings.Controls.Add(this.chkBoxEnableRawPreview);
            this.gbSettings.Controls.Add(this.pbRawPreview);
            this.gbSettings.Controls.Add(this.btnLightsOff);
            this.gbSettings.Controls.Add(this.btnManagePresets);
            this.gbSettings.Controls.Add(this.gbLayer);
            this.gbSettings.Controls.Add(this.cbRender);
            this.gbSettings.Controls.Add(this.lblColumns);
            this.gbSettings.Controls.Add(this.lblRows);
            this.gbSettings.Controls.Add(this.nudColumns);
            this.gbSettings.Controls.Add(this.nudRows);
            this.gbSettings.Controls.Add(this.btnOK);
            this.gbSettings.Controls.Add(this.btnCancel);
            this.gbSettings.Location = new System.Drawing.Point(398, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(774, 286);
            this.gbSettings.TabIndex = 3;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Nutcracker Settings  -  Original Concept by: Sean Meighan and Matt Brown";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(7, 120);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(109, 13);
            this.lblInfo.TabIndex = 18;
            this.lblInfo.Text = "0 ms to render, 0 FPS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Performance Information:";
            // 
            // gbRenderTo
            // 
            this.gbRenderTo.Controls.Add(this.lblStartEventTime);
            this.gbRenderTo.Controls.Add(this.numericUpDown2);
            this.gbRenderTo.Controls.Add(this.lblStartEvent);
            this.gbRenderTo.Controls.Add(this.lblNumEventsTime);
            this.gbRenderTo.Controls.Add(this.numericUpDown1);
            this.gbRenderTo.Controls.Add(this.lblNumberOfEvents);
            this.gbRenderTo.Controls.Add(this.cbGroups);
            this.gbRenderTo.Controls.Add(this.rbGroup);
            this.gbRenderTo.Controls.Add(this.rbSpecificPoint);
            this.gbRenderTo.Controls.Add(this.rbCurrentPointOrRange);
            this.gbRenderTo.Controls.Add(this.rbRoutine);
            this.gbRenderTo.Controls.Add(this.rbClipboard);
            this.gbRenderTo.Location = new System.Drawing.Point(214, 19);
            this.gbRenderTo.Name = "gbRenderTo";
            this.gbRenderTo.Size = new System.Drawing.Size(266, 232);
            this.gbRenderTo.TabIndex = 16;
            this.gbRenderTo.TabStop = false;
            this.gbRenderTo.Text = "Render Effects To:";
            // 
            // lblStartEventTime
            // 
            this.lblStartEventTime.AutoSize = true;
            this.lblStartEventTime.Location = new System.Drawing.Point(162, 177);
            this.lblStartEventTime.Name = "lblStartEventTime";
            this.lblStartEventTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartEventTime.TabIndex = 11;
            this.lblStartEventTime.Text = "00:00.000";
            this.lblStartEventTime.Visible = false;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(105, 175);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown2.TabIndex = 10;
            this.numericUpDown2.Visible = false;
            // 
            // lblStartEvent
            // 
            this.lblStartEvent.AutoSize = true;
            this.lblStartEvent.Location = new System.Drawing.Point(39, 177);
            this.lblStartEvent.Name = "lblStartEvent";
            this.lblStartEvent.Size = new System.Drawing.Size(60, 13);
            this.lblStartEvent.TabIndex = 9;
            this.lblStartEvent.Text = "Start Event";
            this.lblStartEvent.Visible = false;
            // 
            // lblNumEventsTime
            // 
            this.lblNumEventsTime.AutoSize = true;
            this.lblNumEventsTime.Location = new System.Drawing.Point(162, 203);
            this.lblNumEventsTime.Name = "lblNumEventsTime";
            this.lblNumEventsTime.Size = new System.Drawing.Size(55, 13);
            this.lblNumEventsTime.TabIndex = 8;
            this.lblNumEventsTime.Text = "00:00.000";
            this.lblNumEventsTime.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(105, 201);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Visible = false;
            // 
            // lblNumberOfEvents
            // 
            this.lblNumberOfEvents.AutoSize = true;
            this.lblNumberOfEvents.Location = new System.Drawing.Point(7, 203);
            this.lblNumberOfEvents.Name = "lblNumberOfEvents";
            this.lblNumberOfEvents.Size = new System.Drawing.Size(92, 13);
            this.lblNumberOfEvents.TabIndex = 6;
            this.lblNumberOfEvents.Text = "Number of Events";
            this.lblNumberOfEvents.Visible = false;
            // 
            // cbGroups
            // 
            this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.Location = new System.Drawing.Point(66, 18);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(194, 21);
            this.cbGroups.TabIndex = 5;
            this.cbGroups.Visible = false;
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Location = new System.Drawing.Point(6, 19);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(54, 17);
            this.rbGroup.TabIndex = 4;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "Group";
            this.rbGroup.UseVisualStyleBackColor = true;
            // 
            // rbSpecificPoint
            // 
            this.rbSpecificPoint.AutoSize = true;
            this.rbSpecificPoint.Location = new System.Drawing.Point(6, 88);
            this.rbSpecificPoint.Name = "rbSpecificPoint";
            this.rbSpecificPoint.Size = new System.Drawing.Size(154, 17);
            this.rbSpecificPoint.TabIndex = 3;
            this.rbSpecificPoint.TabStop = true;
            this.rbSpecificPoint.Text = "Specific Point In Sequence";
            this.rbSpecificPoint.UseVisualStyleBackColor = true;
            // 
            // rbCurrentPointOrRange
            // 
            this.rbCurrentPointOrRange.AutoSize = true;
            this.rbCurrentPointOrRange.Location = new System.Drawing.Point(6, 65);
            this.rbCurrentPointOrRange.Name = "rbCurrentPointOrRange";
            this.rbCurrentPointOrRange.Size = new System.Drawing.Size(150, 17);
            this.rbCurrentPointOrRange.TabIndex = 2;
            this.rbCurrentPointOrRange.TabStop = true;
            this.rbCurrentPointOrRange.Text = "Current Point In Sequence";
            this.rbCurrentPointOrRange.UseVisualStyleBackColor = true;
            // 
            // rbRoutine
            // 
            this.rbRoutine.AutoSize = true;
            this.rbRoutine.Location = new System.Drawing.Point(6, 42);
            this.rbRoutine.Name = "rbRoutine";
            this.rbRoutine.Size = new System.Drawing.Size(136, 17);
            this.rbRoutine.TabIndex = 1;
            this.rbRoutine.TabStop = true;
            this.rbRoutine.Text = "Vixen+ Routine (.vir file)";
            this.rbRoutine.UseVisualStyleBackColor = true;
            // 
            // rbClipboard
            // 
            this.rbClipboard.AutoSize = true;
            this.rbClipboard.Location = new System.Drawing.Point(6, 111);
            this.rbClipboard.Name = "rbClipboard";
            this.rbClipboard.Size = new System.Drawing.Size(69, 17);
            this.rbClipboard.TabIndex = 0;
            this.rbClipboard.TabStop = true;
            this.rbClipboard.Text = "Clipboard";
            this.rbClipboard.UseVisualStyleBackColor = true;
            // 
            // cbModels
            // 
            this.cbModels.FormattingEnabled = true;
            this.cbModels.Location = new System.Drawing.Point(87, 19);
            this.cbModels.Name = "cbModels";
            this.cbModels.Size = new System.Drawing.Size(120, 21);
            this.cbModels.TabIndex = 15;
            // 
            // btnPlayStop
            // 
            this.btnPlayStop.Location = new System.Drawing.Point(511, 175);
            this.btnPlayStop.Name = "btnPlayStop";
            this.btnPlayStop.Size = new System.Drawing.Size(75, 23);
            this.btnPlayStop.TabIndex = 14;
            this.btnPlayStop.Text = "Play";
            this.btnPlayStop.UseVisualStyleBackColor = true;
            this.btnPlayStop.Click += new System.EventHandler(this.btnPlayStop_Click);
            // 
            // btnModels
            // 
            this.btnModels.Location = new System.Drawing.Point(6, 19);
            this.btnModels.Name = "btnModels";
            this.btnModels.Size = new System.Drawing.Size(75, 23);
            this.btnModels.TabIndex = 13;
            this.btnModels.Text = "Models";
            this.btnModels.UseVisualStyleBackColor = true;
            // 
            // chkBoxEnableRawPreview
            // 
            this.chkBoxEnableRawPreview.AutoSize = true;
            this.chkBoxEnableRawPreview.Location = new System.Drawing.Point(486, 152);
            this.chkBoxEnableRawPreview.Name = "chkBoxEnableRawPreview";
            this.chkBoxEnableRawPreview.Size = new System.Drawing.Size(125, 17);
            this.chkBoxEnableRawPreview.TabIndex = 12;
            this.chkBoxEnableRawPreview.Text = "Enable Raw Preview";
            this.chkBoxEnableRawPreview.UseVisualStyleBackColor = true;
            // 
            // pbRawPreview
            // 
            this.pbRawPreview.BackColor = System.Drawing.Color.Black;
            this.pbRawPreview.Location = new System.Drawing.Point(486, 25);
            this.pbRawPreview.Name = "pbRawPreview";
            this.pbRawPreview.Size = new System.Drawing.Size(120, 120);
            this.pbRawPreview.TabIndex = 11;
            this.pbRawPreview.TabStop = false;
            // 
            // btnLightsOff
            // 
            this.btnLightsOff.Enabled = false;
            this.btnLightsOff.Location = new System.Drawing.Point(6, 257);
            this.btnLightsOff.Name = "btnLightsOff";
            this.btnLightsOff.Size = new System.Drawing.Size(75, 23);
            this.btnLightsOff.TabIndex = 10;
            this.btnLightsOff.Text = "Lights Off";
            this.btnLightsOff.UseVisualStyleBackColor = true;
            this.btnLightsOff.Visible = false;
            // 
            // btnManagePresets
            // 
            this.btnManagePresets.Location = new System.Drawing.Point(486, 257);
            this.btnManagePresets.Name = "btnManagePresets";
            this.btnManagePresets.Size = new System.Drawing.Size(100, 23);
            this.btnManagePresets.TabIndex = 9;
            this.btnManagePresets.Text = "Effect Presets";
            this.btnManagePresets.UseVisualStyleBackColor = true;
            // 
            // gbLayer
            // 
            this.gbLayer.Controls.Add(this.rbAverage);
            this.gbLayer.Controls.Add(this.rbLayer);
            this.gbLayer.Controls.Add(this.rbUnmask2);
            this.gbLayer.Controls.Add(this.rbUnmask1);
            this.gbLayer.Controls.Add(this.rbMask2);
            this.gbLayer.Controls.Add(this.rbMask1);
            this.gbLayer.Controls.Add(this.rbEffect2);
            this.gbLayer.Controls.Add(this.rbEffect1);
            this.gbLayer.Location = new System.Drawing.Point(612, 19);
            this.gbLayer.Name = "gbLayer";
            this.gbLayer.Size = new System.Drawing.Size(156, 204);
            this.gbLayer.TabIndex = 8;
            this.gbLayer.TabStop = false;
            this.gbLayer.Text = "Layer Method";
            // 
            // rbAverage
            // 
            this.rbAverage.AutoSize = true;
            this.rbAverage.Location = new System.Drawing.Point(6, 178);
            this.rbAverage.Name = "rbAverage";
            this.rbAverage.Size = new System.Drawing.Size(123, 17);
            this.rbAverage.TabIndex = 7;
            this.rbAverage.Text = "Average Effect 1 && 2";
            this.rbAverage.UseVisualStyleBackColor = true;
            this.rbAverage.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbLayer
            // 
            this.rbLayer.AutoSize = true;
            this.rbLayer.Location = new System.Drawing.Point(6, 155);
            this.rbLayer.Name = "rbLayer";
            this.rbLayer.Size = new System.Drawing.Size(109, 17);
            this.rbLayer.TabIndex = 6;
            this.rbLayer.Text = "Layer Effect 1 && 2";
            this.rbLayer.UseVisualStyleBackColor = true;
            this.rbLayer.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbUnmask2
            // 
            this.rbUnmask2.AutoSize = true;
            this.rbUnmask2.Location = new System.Drawing.Point(6, 132);
            this.rbUnmask2.Name = "rbUnmask2";
            this.rbUnmask2.Size = new System.Drawing.Size(114, 17);
            this.rbUnmask2.TabIndex = 5;
            this.rbUnmask2.Text = "Effect 2 is Unmask";
            this.rbUnmask2.UseVisualStyleBackColor = true;
            this.rbUnmask2.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbUnmask1
            // 
            this.rbUnmask1.AutoSize = true;
            this.rbUnmask1.Location = new System.Drawing.Point(6, 109);
            this.rbUnmask1.Name = "rbUnmask1";
            this.rbUnmask1.Size = new System.Drawing.Size(114, 17);
            this.rbUnmask1.TabIndex = 4;
            this.rbUnmask1.Text = "Effect 1 is Unmask";
            this.rbUnmask1.UseVisualStyleBackColor = true;
            this.rbUnmask1.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbMask2
            // 
            this.rbMask2.AutoSize = true;
            this.rbMask2.Location = new System.Drawing.Point(6, 86);
            this.rbMask2.Name = "rbMask2";
            this.rbMask2.Size = new System.Drawing.Size(101, 17);
            this.rbMask2.TabIndex = 3;
            this.rbMask2.Text = "Effect 2 is Mask";
            this.rbMask2.UseVisualStyleBackColor = true;
            this.rbMask2.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbMask1
            // 
            this.rbMask1.AutoSize = true;
            this.rbMask1.Location = new System.Drawing.Point(6, 65);
            this.rbMask1.Name = "rbMask1";
            this.rbMask1.Size = new System.Drawing.Size(101, 17);
            this.rbMask1.TabIndex = 2;
            this.rbMask1.Text = "Effect 1 is Mask";
            this.rbMask1.UseVisualStyleBackColor = true;
            this.rbMask1.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbEffect2
            // 
            this.rbEffect2.AutoSize = true;
            this.rbEffect2.Location = new System.Drawing.Point(6, 42);
            this.rbEffect2.Name = "rbEffect2";
            this.rbEffect2.Size = new System.Drawing.Size(62, 17);
            this.rbEffect2.TabIndex = 1;
            this.rbEffect2.Text = "Effect 2";
            this.rbEffect2.UseVisualStyleBackColor = true;
            this.rbEffect2.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // rbEffect1
            // 
            this.rbEffect1.AutoSize = true;
            this.rbEffect1.Checked = true;
            this.rbEffect1.Location = new System.Drawing.Point(6, 19);
            this.rbEffect1.Name = "rbEffect1";
            this.rbEffect1.Size = new System.Drawing.Size(62, 17);
            this.rbEffect1.TabIndex = 0;
            this.rbEffect1.TabStop = true;
            this.rbEffect1.Text = "Effect 1";
            this.rbEffect1.UseVisualStyleBackColor = true;
            this.rbEffect1.CheckedChanged += new System.EventHandler(this.EffectLayerChanged);
            // 
            // cbRender
            // 
            this.cbRender.AutoSize = true;
            this.cbRender.Enabled = false;
            this.cbRender.Location = new System.Drawing.Point(87, 261);
            this.cbRender.Name = "cbRender";
            this.cbRender.Size = new System.Drawing.Size(101, 17);
            this.cbRender.TabIndex = 7;
            this.cbRender.Text = "Output to Lights";
            this.cbRender.UseVisualStyleBackColor = true;
            this.cbRender.Visible = false;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(132, 76);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 13);
            this.lblColumns.TabIndex = 6;
            this.lblColumns.Text = "Columns";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(133, 50);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(34, 13);
            this.lblRows.TabIndex = 5;
            this.lblRows.Text = "Rows";
            // 
            // nudColumns
            // 
            this.nudColumns.Location = new System.Drawing.Point(6, 74);
            this.nudColumns.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(120, 20);
            this.nudColumns.TabIndex = 4;
            this.nudColumns.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudColumns.ValueChanged += new System.EventHandler(this.RowOrCol_ValueChanged);
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(7, 48);
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(120, 20);
            this.nudRows.TabIndex = 3;
            this.nudRows.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRows.ValueChanged += new System.EventHandler(this.RowOrCol_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(612, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(693, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // timerRender
            // 
            this.timerRender.Interval = 50;
            this.timerRender.Tick += new System.EventHandler(this.timerRender_Tick);
            // 
            // NutcrackerControlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbEffect1);
            this.Controls.Add(this.gbEffect2);
            this.Controls.Add(this.pbPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NutcrackerControlDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Nutcracker Effect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NutcrackerControlDialog_FormClosing);
            this.gbEffect2.ResumeLayout(false);
            this.gbEffect1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbRenderTo.ResumeLayout(false);
            this.gbRenderTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRawPreview)).EndInit();
            this.gbLayer.ResumeLayout(false);
            this.gbLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEffect2;
        private System.Windows.Forms.GroupBox gbEffect1;
        private System.Windows.Forms.PictureBox pbPreview;
        private GroupBox gbSettings;
        private Button btnOK;
        private Button btnCancel;
        private CheckBox cbRender;
        private Label lblColumns;
        private Label lblRows;
        private NumericUpDown nudColumns;
        private NumericUpDown nudRows;
        private NutcrackerEffectControl nutcrackerEffectControl2;
        private NutcrackerEffectControl nutcrackerEffectControl1;
        private GroupBox gbLayer;
        private RadioButton rbAverage;
        private RadioButton rbLayer;
        private RadioButton rbUnmask2;
        private RadioButton rbUnmask1;
        private RadioButton rbMask2;
        private RadioButton rbMask1;
        private RadioButton rbEffect2;
        private RadioButton rbEffect1;
        private Button btnLightsOff;
        private Button btnManagePresets;
        private Timer timerRender;
        private ComboBox cbModels;
        private Button btnPlayStop;
        private Button btnModels;
        private CheckBox chkBoxEnableRawPreview;
        private PictureBox pbRawPreview;
        private Label lblInfo;
        private Label label3;
        private GroupBox gbRenderTo;
        private Label lblNumEventsTime;
        private NumericUpDown numericUpDown1;
        private Label lblNumberOfEvents;
        private ComboBox cbGroups;
        private RadioButton rbGroup;
        private RadioButton rbSpecificPoint;
        private RadioButton rbCurrentPointOrRange;
        private RadioButton rbRoutine;
        private RadioButton rbClipboard;
        private Label lblStartEventTime;
        private NumericUpDown numericUpDown2;
        private Label lblStartEvent;
    }
}