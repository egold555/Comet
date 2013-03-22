namespace Vixen{
	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.ComponentModel;
	using System.Collections;

	internal  partial class Form1{
		private IContainer components;

		#region Windows Form Designer generated code
		private ToolStripMenuItem aboutToolStripMenuItem1;
private ToolStripMenuItem addInsToolStripMenuItem;
private ToolStripMenuItem cascadeToolStripMenuItem;
private ToolStripMenuItem channelDimmingCurvesToolStripMenuItem;
private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
private ToolStripMenuItem contentsToolStripMenuItem;
private ToolStripMenuItem copyASequenceToolStripMenuItem;
private ToolStripMenuItem copyChannelColorsToolStripMenuItem;
private ToolStripMenuItem copyPluginaddinDataToolStripMenuItem;
private ToolStripMenuItem diagnosticsToolStripMenuItem;
private HelpProvider helpProvider;
private ToolStripMenuItem helpToolStripMenuItem;
private ToolStripMenuItem manageProgramsToolStripMenuItem;
private ToolStripMenuItem manageToolStripMenuItem;
private MenuStrip menuStrip1;
private ToolStripMenuItem musicPlayerToolStripMenuItem;
private ToolStripMenuItem newLightingProgramToolStripMenuItem;
private ToolStripMenuItem onlineSupportForumToolStripMenuItem;
private ToolStripMenuItem openALightingProgramToolStripMenuItem;
private OpenFileDialog openFileDialog1;
private ToolStripMenuItem preferencesToolStripMenuItem;
private ToolStripMenuItem profilesToolStripMenuItem;
private ToolStripMenuItem programsToolStripMenuItem;
private ToolStripMenuItem programToolStripMenuItem;
private ToolStripMenuItem recentToolStripMenuItem;
private ToolStripMenuItem restartCurrentTimerToolStripMenuItem;
private ToolStripMenuItem saveAsToolStripMenuItem;
private SaveFileDialog saveFileDialog1;
private ToolStripMenuItem saveToolStripMenuItem;
private System.Windows.Forms.Timer scheduleTimer;
private ToolStripMenuItem setBackgroundSequenceToolStripMenuItem;
private ToolStripMenuItem setSoundDeviceToolStripMenuItem;
private System.Windows.Forms.Timer shutdownTimer;
private StatusStrip statusStrip;
private ToolStripMenuItem tileToolStripMenuItem;
private ToolStripMenuItem timersToolStripMenuItem;
private ToolStripSeparator toolStripMenuItem1;
private ToolStripSeparator toolStripMenuItem2;
private ToolStripSeparator toolStripMenuItem3;
private ToolStripSeparator toolStripMenuItem4;
private ToolStripSeparator toolStripMenuItem5;
private ToolStripSeparator toolStripMenuItem6;
private ToolStripSeparator toolStripMenuItem7;
private ToolStripSeparator toolStripMenuItem8;
private ToolStripProgressBar toolStripProgressBarBackgroundSequenceRunning;
private ToolStripStatusLabel toolStripStatusLabelMusic;
private ToolStripMenuItem triggersToolStripMenuItem;
private ToolStripMenuItem turnOnQueryServerToolStripMenuItem;
private ToolStripMenuItem utilityToolStripMenuItem;
private ToolStripMenuItem viewRegisteredResponsesToolStripMenuItem;
private ToolStripMenuItem visualChannelLayoutToolStripMenuItem;
private ToolStripMenuItem windowsToolStripMenuItem;

		private void InitializeComponent()
        {
            this.components = new Container();
            this.menuStrip1 = new MenuStrip();
            this.programToolStripMenuItem = new ToolStripMenuItem();
            this.newLightingProgramToolStripMenuItem = new ToolStripMenuItem();
            this.openALightingProgramToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripSeparator();
            this.saveToolStripMenuItem = new ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem8 = new ToolStripSeparator();
            this.setBackgroundSequenceToolStripMenuItem = new ToolStripMenuItem();
            this.channelDimmingCurvesToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem6 = new ToolStripSeparator();
            this.recentToolStripMenuItem = new ToolStripMenuItem();
            this.programsToolStripMenuItem = new ToolStripMenuItem();
            this.manageProgramsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem5 = new ToolStripSeparator();
            this.timersToolStripMenuItem = new ToolStripMenuItem();
            this.restartCurrentTimerToolStripMenuItem = new ToolStripMenuItem();
            this.profilesToolStripMenuItem = new ToolStripMenuItem();
            this.manageToolStripMenuItem = new ToolStripMenuItem();
            this.utilityToolStripMenuItem = new ToolStripMenuItem();
            this.copyASequenceToolStripMenuItem = new ToolStripMenuItem();
            this.copyChannelColorsToolStripMenuItem = new ToolStripMenuItem();
            this.copyPluginaddinDataToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem4 = new ToolStripSeparator();
            this.setSoundDeviceToolStripMenuItem = new ToolStripMenuItem();
            this.musicPlayerToolStripMenuItem = new ToolStripMenuItem();
            this.visualChannelLayoutToolStripMenuItem = new ToolStripMenuItem();
            this.diagnosticsToolStripMenuItem = new ToolStripMenuItem();
            this.turnOnQueryServerToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.preferencesToolStripMenuItem = new ToolStripMenuItem();
            this.addInsToolStripMenuItem = new ToolStripMenuItem();
            this.triggersToolStripMenuItem = new ToolStripMenuItem();
            this.viewRegisteredResponsesToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem7 = new ToolStripSeparator();
            this.windowsToolStripMenuItem = new ToolStripMenuItem();
            this.tileToolStripMenuItem = new ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.contentsToolStripMenuItem = new ToolStripMenuItem();
            this.onlineSupportForumToolStripMenuItem = new ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem3 = new ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new ToolStripMenuItem();
            this.openFileDialog1 = new OpenFileDialog();
            this.scheduleTimer = new System.Windows.Forms.Timer(this.components);
            this.helpProvider = new HelpProvider();
            this.statusStrip = new StatusStrip();
            this.toolStripProgressBarBackgroundSequenceRunning = new ToolStripProgressBar();
            this.toolStripStatusLabelMusic = new ToolStripStatusLabel();
            this.shutdownTimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            base.SuspendLayout();
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.programToolStripMenuItem, this.programsToolStripMenuItem, this.profilesToolStripMenuItem, this.utilityToolStripMenuItem, this.addInsToolStripMenuItem, this.triggersToolStripMenuItem, this.windowsToolStripMenuItem, this.helpToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x308, 0x18);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.programToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.newLightingProgramToolStripMenuItem, this.openALightingProgramToolStripMenuItem, this.toolStripMenuItem2, this.saveToolStripMenuItem, this.saveAsToolStripMenuItem, this.toolStripMenuItem8, this.setBackgroundSequenceToolStripMenuItem, this.channelDimmingCurvesToolStripMenuItem, this.toolStripMenuItem6, this.recentToolStripMenuItem });
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new Size(70, 20);
            this.programToolStripMenuItem.Text = "Sequence";
            this.programToolStripMenuItem.DropDownOpening += new EventHandler(this.programToolStripMenuItem_DropDownOpening);
            this.newLightingProgramToolStripMenuItem.Name = "newLightingProgramToolStripMenuItem";
            this.newLightingProgramToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.newLightingProgramToolStripMenuItem.Text = "New event sequence";
            this.openALightingProgramToolStripMenuItem.Name = "openALightingProgramToolStripMenuItem";
            this.openALightingProgramToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.openALightingProgramToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.openALightingProgramToolStripMenuItem.Text = "Open an event sequence";
            this.openALightingProgramToolStripMenuItem.Click += new EventHandler(this.openALightingProgramToolStripMenuItem_Click);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(0xf4, 6);
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.saveToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new Size(0xf4, 6);
            this.setBackgroundSequenceToolStripMenuItem.Name = "setBackgroundSequenceToolStripMenuItem";
            this.setBackgroundSequenceToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.setBackgroundSequenceToolStripMenuItem.Text = "Set background sequence";
            this.setBackgroundSequenceToolStripMenuItem.Click += new EventHandler(this.setBackgroundSequenceToolStripMenuItem_Click);
            this.channelDimmingCurvesToolStripMenuItem.Name = "channelDimmingCurvesToolStripMenuItem";
            this.channelDimmingCurvesToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.channelDimmingCurvesToolStripMenuItem.Text = "Channel dimming curves";
            this.channelDimmingCurvesToolStripMenuItem.Click += new EventHandler(this.channelDimmingCurvesToolStripMenuItem_Click);
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new Size(0xf4, 6);
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new Size(0xf7, 0x16);
            this.recentToolStripMenuItem.Text = "Recent";
            this.programsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.manageProgramsToolStripMenuItem, this.toolStripMenuItem5, this.timersToolStripMenuItem, this.restartCurrentTimerToolStripMenuItem });
            this.programsToolStripMenuItem.Name = "programsToolStripMenuItem";
            this.programsToolStripMenuItem.Size = new Size(70, 20);
            this.programsToolStripMenuItem.Text = "Programs";
            this.programsToolStripMenuItem.DropDownOpening += new EventHandler(this.programsToolStripMenuItem_DropDownOpening);
            this.manageProgramsToolStripMenuItem.Name = "manageProgramsToolStripMenuItem";
            this.manageProgramsToolStripMenuItem.Size = new Size(0xbb, 0x16);
            this.manageProgramsToolStripMenuItem.Text = "Manage";
            this.manageProgramsToolStripMenuItem.Click += new EventHandler(this.manageProgramsToolStripMenuItem_Click);
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new Size(0xb8, 6);
            this.timersToolStripMenuItem.Name = "timersToolStripMenuItem";
            this.timersToolStripMenuItem.Size = new Size(0xbb, 0x16);
            this.timersToolStripMenuItem.Text = "Schedule";
            this.timersToolStripMenuItem.Click += new EventHandler(this.timersToolStripMenuItem_Click);
            this.restartCurrentTimerToolStripMenuItem.Name = "restartCurrentTimerToolStripMenuItem";
            this.restartCurrentTimerToolStripMenuItem.Size = new Size(0xbb, 0x16);
            this.restartCurrentTimerToolStripMenuItem.Text = "Restart current timers";
            this.restartCurrentTimerToolStripMenuItem.Click += new EventHandler(this.restartCurrentTimerToolStripMenuItem_Click);
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.manageToolStripMenuItem });
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new Size(0x3a, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new EventHandler(this.manageToolStripMenuItem_Click);
            this.utilityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.copyASequenceToolStripMenuItem, this.copyChannelColorsToolStripMenuItem, this.copyPluginaddinDataToolStripMenuItem, this.toolStripMenuItem4, this.setSoundDeviceToolStripMenuItem, this.musicPlayerToolStripMenuItem, this.visualChannelLayoutToolStripMenuItem, this.diagnosticsToolStripMenuItem, this.turnOnQueryServerToolStripMenuItem, this.toolStripMenuItem1, this.preferencesToolStripMenuItem });
            this.utilityToolStripMenuItem.Name = "utilityToolStripMenuItem";
            this.utilityToolStripMenuItem.Size = new Size(0x30, 20);
            this.utilityToolStripMenuItem.Text = "Tools";
            this.copyASequenceToolStripMenuItem.Name = "copyASequenceToolStripMenuItem";
            this.copyASequenceToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.copyASequenceToolStripMenuItem.Text = "Copy sequence event data";
            this.copyASequenceToolStripMenuItem.Click += new EventHandler(this.copyASequenceToolStripMenuItem_Click);
            this.copyChannelColorsToolStripMenuItem.Name = "copyChannelColorsToolStripMenuItem";
            this.copyChannelColorsToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.copyChannelColorsToolStripMenuItem.Text = "Copy channel colors";
            this.copyChannelColorsToolStripMenuItem.Click += new EventHandler(this.copyChannelColorsToolStripMenuItem_Click);
            this.copyPluginaddinDataToolStripMenuItem.Name = "copyPluginaddinDataToolStripMenuItem";
            this.copyPluginaddinDataToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.copyPluginaddinDataToolStripMenuItem.Text = "Copy data";
            this.copyPluginaddinDataToolStripMenuItem.Click += new EventHandler(this.copyPluginaddinDataToolStripMenuItem_Click);
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new Size(0x103, 6);
            this.setSoundDeviceToolStripMenuItem.Name = "setSoundDeviceToolStripMenuItem";
            this.setSoundDeviceToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.setSoundDeviceToolStripMenuItem.Text = "Set application default audio device";
            this.setSoundDeviceToolStripMenuItem.Click += new EventHandler(this.setSoundDeviceToolStripMenuItem_Click);
            this.musicPlayerToolStripMenuItem.Name = "musicPlayerToolStripMenuItem";
            this.musicPlayerToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.musicPlayerToolStripMenuItem.Text = "Music player";
            this.musicPlayerToolStripMenuItem.Click += new EventHandler(this.musicPlayerToolStripMenuItem_Click);
            this.visualChannelLayoutToolStripMenuItem.Name = "visualChannelLayoutToolStripMenuItem";
            this.visualChannelLayoutToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.visualChannelLayoutToolStripMenuItem.Text = "Visual channel layout";
            this.visualChannelLayoutToolStripMenuItem.Visible = false;
            this.visualChannelLayoutToolStripMenuItem.Click += new EventHandler(this.visualChannelLayoutToolStripMenuItem_Click);
            this.diagnosticsToolStripMenuItem.Name = "diagnosticsToolStripMenuItem";
            this.diagnosticsToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.diagnosticsToolStripMenuItem.Text = "Diagnostics";
            this.diagnosticsToolStripMenuItem.Click += new EventHandler(this.diagnosticsToolStripMenuItem_Click);
            this.turnOnQueryServerToolStripMenuItem.Name = "turnOnQueryServerToolStripMenuItem";
            this.turnOnQueryServerToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.turnOnQueryServerToolStripMenuItem.Text = "Query server";
            this.turnOnQueryServerToolStripMenuItem.Visible = false;
            this.turnOnQueryServerToolStripMenuItem.Click += new EventHandler(this.turnOnQueryServerToolStripMenuItem_Click);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(0x103, 6);
            this.preferencesToolStripMenuItem.MergeAction = MergeAction.Insert;
            this.preferencesToolStripMenuItem.MergeIndex = 0x63;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new Size(0x106, 0x16);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new EventHandler(this.preferencesToolStripMenuItem_Click);
            this.addInsToolStripMenuItem.Name = "addInsToolStripMenuItem";
            this.addInsToolStripMenuItem.Size = new Size(0x3d, 20);
            this.addInsToolStripMenuItem.Text = "Add-ins";
            this.addInsToolStripMenuItem.Visible = false;
            this.addInsToolStripMenuItem.DropDownOpening += new EventHandler(this.loadableToolStripMenuItem_DropDownOpening);
            this.triggersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.viewRegisteredResponsesToolStripMenuItem, this.toolStripMenuItem7 });
            this.triggersToolStripMenuItem.Name = "triggersToolStripMenuItem";
            this.triggersToolStripMenuItem.Size = new Size(0x3e, 20);
            this.triggersToolStripMenuItem.Text = "Triggers";
            this.triggersToolStripMenuItem.Visible = false;
            this.triggersToolStripMenuItem.DropDownOpening += new EventHandler(this.loadableToolStripMenuItem_DropDownOpening);
            this.viewRegisteredResponsesToolStripMenuItem.Name = "viewRegisteredResponsesToolStripMenuItem";
            this.viewRegisteredResponsesToolStripMenuItem.Size = new Size(0xd1, 0x16);
            this.viewRegisteredResponsesToolStripMenuItem.Text = "View registered responses";
            this.viewRegisteredResponsesToolStripMenuItem.Click += new EventHandler(this.viewRegisteredResponsesToolStripMenuItem_Click);
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new Size(0xce, 6);
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.tileToolStripMenuItem, this.cascadeToolStripMenuItem });
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new Size(0x44, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new EventHandler(this.tileToolStripMenuItem_Click);
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new EventHandler(this.cascadeToolStripMenuItem_Click);
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.contentsToolStripMenuItem, this.onlineSupportForumToolStripMenuItem, this.checkForUpdatesToolStripMenuItem, this.toolStripMenuItem3, this.aboutToolStripMenuItem1 });
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new Size(0x2c, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.contentsToolStripMenuItem.Size = new Size(0xbd, 0x16);
            this.contentsToolStripMenuItem.Text = "Contents";
            this.contentsToolStripMenuItem.Click += new EventHandler(this.contentsToolStripMenuItem_Click);
            this.onlineSupportForumToolStripMenuItem.Name = "onlineSupportForumToolStripMenuItem";
            this.onlineSupportForumToolStripMenuItem.Size = new Size(0xbd, 0x16);
            this.onlineSupportForumToolStripMenuItem.Text = "Online support forum";
            this.onlineSupportForumToolStripMenuItem.Click += new EventHandler(this.onlineSupportForumToolStripMenuItem_Click);
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new Size(0xbd, 0x16);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(0xba, 6);
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new Size(0xbd, 0x16);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
            this.openFileDialog1.DefaultExt = "vix";
            this.openFileDialog1.Filter = "Vixen event sequence | *.vix";
            this.openFileDialog1.InitialDirectory = "Sequences";
            this.scheduleTimer.Interval = 0x2710;
            this.scheduleTimer.Tick += new EventHandler(this.timer1_Tick);
            this.statusStrip.Items.AddRange(new ToolStripItem[] { this.toolStripProgressBarBackgroundSequenceRunning, this.toolStripStatusLabelMusic });
            this.statusStrip.Location = new Point(0, 0x1d3);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new Size(0x308, 0x16);
            this.statusStrip.TabIndex = 3;
            this.toolStripProgressBarBackgroundSequenceRunning.Enabled = false;
            this.toolStripProgressBarBackgroundSequenceRunning.Name = "toolStripProgressBarBackgroundSequenceRunning";
            this.toolStripProgressBarBackgroundSequenceRunning.Size = new Size(100, 0x10);
            this.toolStripProgressBarBackgroundSequenceRunning.Style = ProgressBarStyle.Marquee;
            this.toolStripProgressBarBackgroundSequenceRunning.Visible = false;
            this.toolStripStatusLabelMusic.ImageTransparentColor = Color.White;
            this.toolStripStatusLabelMusic.Name = "toolStripStatusLabelMusic";
            this.toolStripStatusLabelMusic.Size = new Size(0x20, 0x11);
            this.toolStripStatusLabelMusic.Text = "   ";
            this.toolStripStatusLabelMusic.ToolTipText = "Background music is playing";
            this.toolStripStatusLabelMusic.Visible = false;
            this.shutdownTimer.Interval = 0x2710;
            this.shutdownTimer.Tick += new EventHandler(this.shutdownTimer_Tick);
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x308, 0x1e9);
            base.Controls.Add(this.statusStrip);
            base.Controls.Add(this.menuStrip1);
            this.helpProvider.SetHelpNavigator(this, HelpNavigator.TableOfContents);
            base.IsMdiContainer = true;
            base.KeyPreview = true;
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "Form1";
            this.helpProvider.SetShowHelp(this, true);
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Vixen";
            base.WindowState = FormWindowState.Maximized;
            base.MdiChildActivate += new EventHandler(this.Form1_MdiChildActivate);
            base.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            base.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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