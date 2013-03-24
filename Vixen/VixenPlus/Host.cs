﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace VixenPlus
{
	internal class Host : IQueryable
	{
		public static byte[,] Clipboard = null;
		internal static Dictionary<string, object> Communication = new Dictionary<string, object>();
		private static ulong _lastKey;
		private static readonly Preference2 Preference2 = Preference2.GetInstance();
		private static readonly Dictionary<string, string> Properties = new Dictionary<string, string>();
		private static PlugInRouter _singletonRouter;
		private readonly System.Timers.Timer _backgroundMusicDelayTimer;
		private readonly ToolStripLabel _backgroundMusicLabel;
		private readonly ToolStripProgressBar _backgroundProgressBar;
		private readonly System.Timers.Timer _backgroundSequenceDelayTimer;
		private readonly Form _hostForm;
		private readonly MusicPlayer _musicPlayer;
		private int _backgroundExecutionContextHandle;
		private EventSequence _backgroundSequence;
		private IExecution _executionInterface;

		public Host(Form hostForm)
		{
			_hostForm = hostForm;
			_singletonRouter = PlugInRouter.GetInstance();
			_backgroundSequenceDelayTimer = new System.Timers.Timer();
			_backgroundSequenceDelayTimer.Elapsed += BackgroundSequenceDelayTimerElapsed;
			_backgroundMusicDelayTimer = new System.Timers.Timer();
			_backgroundMusicDelayTimer.Elapsed += BackgroundMusicDelayTimerElapsed;
			var strip = (StatusStrip) _hostForm.Controls.Find("statusStrip", true)[0];
			_backgroundProgressBar =
				(ToolStripProgressBar) strip.Items.Find("toolStripProgressBarBackgroundSequenceRunning", false)[0];
			_backgroundMusicLabel = (ToolStripLabel) strip.Items.Find("toolStripStatusLabelMusic", false)[0];
			_musicPlayer = new MusicPlayer();
			_musicPlayer.SongChange += MusicPlayerSongChange;
		}

		public string BackgroundSequenceName
		{
			get
			{
				if (_backgroundSequence != null)
				{
					return _backgroundSequence.FileName;
				}
				return null;
			}
			set
			{
				StopBackgroundSequence();
				if (string.IsNullOrEmpty(value))
				{
					if (_backgroundSequence != null)
					{
						_backgroundSequence.Dispose();
						_backgroundSequence = null;
					}
				}
				else if (!File.Exists(value))
				{
					if (Preference2.GetBoolean("EnableBackgroundSequence"))
					{
						MessageBox.Show(
							"A background sequence has been specified, but it does not exist.\nThis message will show each time you start the application and this situation exists.",
							Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					_backgroundSequence = new EventSequence(value);
				}
			}
		}

		public static bool InvokeRequired
		{
			get { return Application.OpenForms[0].InvokeRequired; }
		}

		public MusicPlayer MusicPlayer
		{
			get { return _musicPlayer; }
		}

		public static Preference2 Preferences
		{
			get { return Preference2; }
		}

		public static PlugInRouter Router
		{
			get { return _singletonRouter; }
		}

		public string QueryInstance(int index)
		{
			var builder = new StringBuilder();
			if (index == 0)
			{
				builder.AppendLine("(Background Sequence)");
				builder.AppendLine("Execution handle: " + _backgroundExecutionContextHandle);
				builder.AppendLine("Sequence: " + ((_backgroundSequence == null) ? "(null)" : _backgroundSequence.Name));
			}
			else
			{
				builder.AppendLine("(Music Player)");
				builder.AppendLine("Song count: " + _musicPlayer.SongCount);
				builder.AppendLine("Playing: " + _musicPlayer.IsPlaying);
				if (_musicPlayer.IsPlaying)
				{
					builder.AppendLine("Song name: " + _musicPlayer.CurrentSongName);
					builder.AppendLine("Song length: " + _musicPlayer.CurrentSongLength);
				}
			}
			return builder.ToString();
		}

		public int Count
		{
			get { return 2; }
		}

		public static void BeginInvoke(Delegate method, params object[] args)
		{
			Application.OpenForms[0].BeginInvoke(method, args);
		}

		public static void ClearLog(string filePath)
		{
			File.Delete(filePath);
		}

		private void CreateBackgroundContext()
		{
			if (_executionInterface == null)
			{
				_executionInterface = (IExecution) Interfaces.Available["IExecution"];
			}
			if (_backgroundExecutionContextHandle == 0)
			{
				_backgroundExecutionContextHandle = _executionInterface.RequestContext(true, false, null);
				_executionInterface.SetSynchronousContext(_backgroundExecutionContextHandle, _backgroundSequence);
			}
		}

		public void DelegateNullMethod(MethodInvoker method)
		{
			if (_hostForm.InvokeRequired)
			{
				_hostForm.BeginInvoke(method);
			}
			else
			{
				method();
			}
		}

		public static void DumpTimer(StreamWriter writer, Timer timer)
		{
			writer.WriteLine("[Timer for {0}]", Path.GetFileName(timer.ProgramFileName));
			writer.WriteLine("Executing? " + timer.IsExecuting);
			writer.WriteLine("Last execution: " + timer.LastExecution.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Not valid until: " + timer.NotValidUntil.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Object length: " + timer.ObjectLength);
			writer.WriteLine("Recurrence: {0} ({1})", timer.Recurrence, timer.RecurrenceData);
			writer.WriteLine("Recurrence start: " + timer.RecurrenceStart.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Recurrence start date/time: " + timer.RecurrenceStartDateTime.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Recurrence span: " + timer.RecurrenceSpan);
			writer.WriteLine("Recurrence end: " + timer.RecurrenceEnd.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Recurrence end date/time: " + timer.RecurrenceEndDateTime.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Repeat interval: " + timer.RepeatInterval.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Start date: " + timer.StartDate.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Start time: " + timer.StartTime);
			writer.WriteLine("Start date/time: " + timer.StartDateTime.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("Timer length: " + timer.TimerLength);
			writer.WriteLine("End date: " + timer.EndDate.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine("End time: " + timer.EndTime);
			writer.WriteLine("End date/time: " + timer.EndDateTime.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine();
		}

		public void ExecuteBackgroundSequence()
		{
			if ((((_executionInterface != null) && (_backgroundExecutionContextHandle != 0)) && (_backgroundSequence != null)) &&
			    !_executionInterface.ExecutePlay(_backgroundExecutionContextHandle, 0, 0,
			                                      Preference2.GetBoolean("LogAudioScheduled")))
			{
				MessageBox.Show("There was a problem starting the background sequence.", Vendor.ProductName, MessageBoxButtons.OK,
				                MessageBoxIcon.Exclamation);
			}
		}

		public static string GetDebugValue(string name)
		{
			string str;
			Properties.TryGetValue(name, out str);
			return str;
		}

		public static ulong GetUniqueKey()
		{
			ulong num;
			do
			{
				num = BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(), 0);
			} while (num == _lastKey);
			return (_lastKey = num);
		}

		public static void Invoke(Delegate method, params object[] args)
		{
			Application.OpenForms[0].Invoke(method, args);
		}

		public bool IsBackgroundExecutionEngineInstance(Engine8 engine)
		{
			return (((_executionInterface != null) && (_backgroundExecutionContextHandle != 0)) &&
			        (_executionInterface.FindExecutionContextHandle(engine) == _backgroundExecutionContextHandle));
		}

		public static void LogAudio(string source, string sourceNote, string audioFileName, int lengthInMilliseconds)
		{
			string path = ((ISystem) Interfaces.Available["ISystem"]).UserPreferences.GetString("AudioLogFilePath");
			if (path.Trim().Length == 0)
			{
				((ISystem) Interfaces.Available["ISystem"]).UserPreferences.SetBoolean("LogAudioManual", false);
				((ISystem) Interfaces.Available["ISystem"]).UserPreferences.SetBoolean("LogAudioScheduled", false);
				((ISystem) Interfaces.Available["ISystem"]).UserPreferences.SetBoolean("LogAudioMusicPlayer", false);
				MessageBox.Show("Audio logging is enabled but no log file is specified.\n\nAudio logging has been turned off.",
				                Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				try
				{
					string str2;
					var span = new TimeSpan(0, 0, 0, 0, lengthInMilliseconds);
					if (!string.IsNullOrEmpty(sourceNote))
					{
						str2 = string.Format("{0} [{1} - {2}]   {3} ({4})\n",
						                     new object[] {DateTime.Now, source, sourceNote, audioFileName, span});
					}
					else
					{
						str2 = string.Format("{0} [{1}]   {2} ({3})\n", new object[] {DateTime.Now, source, audioFileName, span});
					}
					File.AppendAllText(path, str2);
				}
				catch (Exception exception)
				{
					((ISystem) Interfaces.Available["ISystem"]).UserPreferences.SetBoolean("LogAudioManual", false);
					((ISystem) Interfaces.Available["ISystem"]).UserPreferences.SetBoolean("LogAudioScheduled", false);
					((ISystem) Interfaces.Available["ISystem"]).UserPreferences.SetBoolean("LogAudioMusicPlayer", false);
					MessageBox.Show(
						string.Format(
							"An exception occurred when trying to log the use of an audio file:\n\n{0}\n\nAudio logging has been turned off.",
							exception.Message), Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		public static void LogTo(string filePath, string message)
		{
			File.AppendAllText(filePath, message + "\n");
		}

		private void BackgroundMusicDelayTimerElapsed(object sender, ElapsedEventArgs e)
		{
			_backgroundMusicDelayTimer.Enabled = false;
			_hostForm.BeginInvoke(new MethodInvoker(ShowBackgroundMusicThumbSucker));
			_hostForm.BeginInvoke(new MethodInvoker(_musicPlayer.Start));
		}

		private void BackgroundSequenceDelayTimerElapsed(object sender, ElapsedEventArgs e)
		{
			_backgroundSequenceDelayTimer.Enabled = false;
			_hostForm.BeginInvoke(new MethodInvoker(ShowBackgroundSequenceThumbSucker));
			ExecuteBackgroundSequence();
		}

		private void MusicPlayerSongChange(string songName)
		{
			_backgroundMusicLabel.Text = songName;
		}

		public static void ResetDebugValue(string name)
		{
			if (Properties.ContainsKey(name))
			{
				Properties.Remove(name);
			}
		}

		public static void SetDebugValue(string name)
		{
			Properties[name] = string.Empty;
		}

		public static void SetDebugValue(string name, string value)
		{
			Properties[name] = value;
		}

		private void ShowBackgroundMusicThumbSucker()
		{
			if (!_backgroundMusicLabel.Visible)
			{
				_backgroundMusicLabel.Text = string.Empty;
				_backgroundMusicLabel.Visible = true;
			}
		}

		private void ShowBackgroundSequenceThumbSucker()
		{
			if (!_backgroundProgressBar.Visible)
			{
				_backgroundProgressBar.ToolTipText = _backgroundSequence.Name + " is running";
				_backgroundProgressBar.Visible = true;
				_backgroundProgressBar.Enabled = true;
			}
		}

		public void StartBackgroundMusic()
		{
			if ((_musicPlayer.SongCount != 0) && Preference2.GetBoolean("EnableBackgroundMusic"))
			{
				_backgroundMusicDelayTimer.Interval = Preference2.GetInteger("BackgroundMusicDelay")*0x3e8;
				_backgroundMusicDelayTimer.Enabled = true;
			}
		}

		public void StartBackgroundObjects()
		{
			StartBackgroundSequence();
			StartBackgroundMusic();
		}

		public void StartBackgroundSequence()
		{
			if ((_backgroundSequence != null) && Preference2.GetBoolean("EnableBackgroundSequence"))
			{
				CreateBackgroundContext();
				if (_executionInterface.EngineStatus(_backgroundExecutionContextHandle) == 0)
				{
					_backgroundSequenceDelayTimer.Interval = Preference2.GetInteger("BackgroundSequenceDelay")*0x3e8;
					_backgroundSequenceDelayTimer.Enabled = true;
				}
			}
		}

		public void StopBackgroundMusic()
		{
			_musicPlayer.Stop();
			_backgroundMusicDelayTimer.Enabled = false;
			_backgroundMusicLabel.Visible = false;
		}

		public void StopBackgroundObjects()
		{
			StopBackgroundSequence();
			StopBackgroundMusic();
		}

		public void StopBackgroundSequence()
		{
			StopBackgroundSequenceUI();
			StopBackgroundSequenceExecution();
		}

		public void StopBackgroundSequenceExecution()
		{
			if (_backgroundExecutionContextHandle != 0)
			{
				_executionInterface.ExecuteStop(_backgroundExecutionContextHandle);
				_executionInterface.ReleaseContext(_backgroundExecutionContextHandle);
				_backgroundExecutionContextHandle = 0;
			}
		}

		public void StopBackgroundSequenceUI()
		{
			if (InvokeRequired)
			{
				BeginInvoke(new MethodInvoker(StopBackgroundSequenceUI), new object[0]);
			}
			else
			{
				_backgroundSequenceDelayTimer.Enabled = false;
				_backgroundProgressBar.Visible = false;
				_backgroundProgressBar.Enabled = false;
			}
		}
	}
}