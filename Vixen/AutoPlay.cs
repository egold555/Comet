using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;
using CommandLine.Text;
using Microsoft.Win32.TaskScheduler;
using VixenPlus.Dialogs;
using VixenPlusCommon;

namespace VixenPlus
{
    static class AutoPlay
    {
        static Timer timer;
        static List<AutoPlaySequence> sequences = new List<AutoPlaySequence>();
        static int currentSequenceIndex;
        static DateTime endTime;
        static AutoPlayStatus statusDialog;

        private static AutoPlaySequence CurrentSequence {
            get {
                if (sequences.Count == 0)
                    return null;
                return sequences[currentSequenceIndex];
            }
        }

        public static CommandLineOptions ParseCommandLine(string[] args)
        {
            CommandLineOptions options = new CommandLineOptions();

            Parser.Default.ParseArguments(args, options);
            return options;
        }

        public static CommandLineOptions ParseCommandLine(string argsString)
        {
            return ParseCommandLine(SplitArgs(argsString));
        }

        /// <summary>
        /// Reads command line arguments from a single string.
        /// </summary>
        /// <param name="argsString">The string that contains the entire command line.</param>
        /// <returns>An array of the parsed arguments.</returns>
        public static string[] SplitArgs(string argsString)
        {
            // Collects the split argument strings
            List<string> args = new List<string>();
            // Builds the current argument
            var currentArg = new StringBuilder();
            // Indicates whether the last character was a backslash escape character
            bool escape = false;
            // Indicates whether we're in a quoted range
            bool inQuote = false;
            // Indicates whether there were quotes in the current arguments
            bool hadQuote = false;
            // Remembers the previous character
            char prevCh = '\0';
            // Iterate all characters from the input string
            for (int i = 0; i < argsString.Length; i++) {
                char ch = argsString[i];
                if (ch == '\\' && !escape) {
                    // Beginning of a backslash-escape sequence
                    escape = true;
                }
                else if (ch == '\\' && escape) {
                    // Double backslash, keep one
                    currentArg.Append(ch);
                    escape = false;
                }
                else if (ch == '"' && !escape) {
                    // Toggle quoted range
                    inQuote = !inQuote;
                    hadQuote = true;
                    if (inQuote && prevCh == '"') {
                        // Doubled quote within a quoted range is like escaping
                        currentArg.Append(ch);
                    }
                }
                else if (ch == '"' && escape) {
                    // Backslash-escaped quote, keep it
                    currentArg.Append(ch);
                    escape = false;
                }
                else if (char.IsWhiteSpace(ch) && !inQuote) {
                    if (escape) {
                        // Add pending escape char
                        currentArg.Append('\\');
                        escape = false;
                    }
                    // Accept empty arguments only if they are quoted
                    if (currentArg.Length > 0 || hadQuote) {
                        args.Add(currentArg.ToString());
                    }
                    // Reset for next argument
                    currentArg.Clear();
                    hadQuote = false;
                }
                else {
                    if (escape) {
                        // Add pending escape char
                        currentArg.Append('\\');
                        escape = false;
                    }
                    // Copy character from input, no special meaning
                    currentArg.Append(ch);
                }
                prevCh = ch;
            }
            // Save last argument
            if (currentArg.Length > 0 || hadQuote) {
                args.Add(currentArg.ToString());
            }
            return args.ToArray();
        }

        public static void Begin(CommandLineOptions options, Form parentForm)
        {
            if (!options.Play)
                return;

            InitializeSequences(options.Sequences);

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

            // subtract 15 seconds due to startup/shutdown time, etc.
            endTime = DateTime.Now.AddMinutes(options.Minutes).AddSeconds(-15);

            statusDialog = new AutoPlayStatus();
            statusDialog.MdiParent = parentForm;
            statusDialog.Show();

            if (CurrentSequence != null) {
                PlayCurrentSequence();
            }
        }

        public static void End()
        {
            if (CurrentSequence != null && CurrentSequence.IsPlaying) {
                CurrentSequence.TurnOffLights();
                CurrentSequence.Stop();
            }

            foreach (AutoPlaySequence seq in sequences) {
                seq.Dispose();
            }

            sequences.Clear();

            Application.Exit();
        }

        private static void PlayCurrentSequence()
        {
            statusDialog.UpdateCurrentSequence(CurrentSequence.Name);
            CurrentSequence.Play();
        }

        private static void InitializeSequences(IList<string> sequenceFileNames)
        {
            foreach (string path in sequenceFileNames) {
                sequences.Add(new AutoPlaySequence(path));
            }

            currentSequenceIndex = 0;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= endTime || statusDialog.StopRequested) {
                End();
            }

            if (CurrentSequence != null) {
                if (!CurrentSequence.IsPlaying) {
                    // Move to the next sequence.
                    currentSequenceIndex += 1;
                    if (currentSequenceIndex >= sequences.Count)
                        currentSequenceIndex = 0;
                    PlayCurrentSequence();
                }
            }
        }

        class AutoPlaySequence : IDisposable
        {
            string path;
            string error;
            IExecution executionInterface;
            int contextHandle;
            int numberOfChannels;

            public AutoPlaySequence(string path)
            {
                this.path = path;
            }

            public string Name {
                get { return Path.GetFileName(path); }
            }

            public string Error {
                get { return error; }
            }

            public bool IsPlaying {
                get {
                    if (executionInterface == null)
                        return false;
                    return (executionInterface.EngineStatus(contextHandle) == Utils.ExecutionRunning);
                }
            }

            public void Dispose()
            {
                if (executionInterface != null) {
                    executionInterface.ReleaseContext(contextHandle);
                    executionInterface = null;
                }
            }

            public bool Play()
            {
                error = null;

                try {
                    if (!File.Exists(path)) {
                        error = string.Format("File '{0}' does not exist.", path);
                        return false;
                    }

                    var fileIOHandler = FileIOHelper.GetByExtension(path);
                    EventSequence sequence = fileIOHandler.OpenSequence(path);
                    numberOfChannels = sequence.OutputChannels.Count;

                    object executionIfaceObj;
                    if (!Interfaces.Available.TryGetValue("IExecution", out executionIfaceObj)) {
                        error = "IExecution interface not available.";
                        return false;
                    }

                    executionInterface = (IExecution)executionIfaceObj;
                    contextHandle = executionInterface.RequestContext(true, false, null);
                    executionInterface.SetSynchronousContext(contextHandle, sequence);

                    executionInterface.ExecutePlay(contextHandle, 0, 0);

                    return true;
                }
                catch (Exception e) {
                    error = e.Message;
                    return false;
                }
            }

            public void Stop()
            {
                if (executionInterface != null) {
                    executionInterface.ExecuteStop(contextHandle);
                }
            }

            public void TurnOffLights()
            {
                if (executionInterface != null) {
                    executionInterface.SetChannelStates(contextHandle, new byte[numberOfChannels]);
                }
            }

        }
    }

    class CommandLineOptions
    {
        [Option('p', "play", HelpText = "Play sequences instead of opening them")]
        public bool Play { get; set; }

        [Option("minutes", HelpText = "Minutes that the playing goes on for", DefaultValue = 10)]
        public int Minutes { get; set; }

        [ValueList(typeof(List<string>))]
        public IList<string> Sequences { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText {
                Heading = new HeadingInfo("Comet", ""),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddOptions(this);
            return help;
        }
    }

    class ScheduledProgram
    {
        public string name;
        public List<string> sequences;
        public TimeSpan startTime, endTime;
        public DateTime firstDate, lastDate;
        public DaysOfTheWeek weekDays;

        public override string ToString()
        {
            string daysText = TextFromDaysOfTheWeek(weekDays);
            DateTime start = DateTime.Now.Date + startTime, end = DateTime.Now.Date + endTime;
            return string.Format("{0} ({1:h:mm tt} - {2:h:mm tt}, {3})", name, start, end, daysText);
        }

        private static string TextFromDaysOfTheWeek(DaysOfTheWeek days)
        {
            if (days == 0)
                return "no days";
            else if (days == DaysOfTheWeek.AllDays)
                return "every day";
            else if (days == (DaysOfTheWeek.Saturday | DaysOfTheWeek.Sunday))
                return "weekends";
            else if (days == (DaysOfTheWeek.Monday | DaysOfTheWeek.Tuesday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Thursday | DaysOfTheWeek.Friday))
                return "weekdays";

            string result = "";
            foreach (DaysOfTheWeek day in new[] { DaysOfTheWeek.Monday, DaysOfTheWeek.Tuesday, DaysOfTheWeek.Wednesday, DaysOfTheWeek.Thursday, DaysOfTheWeek.Friday, DaysOfTheWeek.Saturday , DaysOfTheWeek.Sunday }) {
                if ((days & day) != 0) {
                    if (result != "")
                        result += ", ";
                    result += day.ToString().Substring(0, 3);
                }
            }

            return result;
        }

        public void RegisterTask(TaskService taskService)
        {
            TaskDefinition def = taskService.NewTask();
            string applicationExe = Application.ExecutablePath;

            int minutes;

            if (endTime > startTime)
                minutes = (int)Math.Round((endTime - startTime).TotalMinutes);
            else
                minutes = (int)Math.Round((endTime - startTime + TimeSpan.FromDays(1)).TotalMinutes);
            string arguments = "-p --minutes " + minutes.ToString() + " " + string.Join(" ", sequences.Select(s => "\"" + s + "\""));

            WeeklyTrigger trigger = new WeeklyTrigger(weekDays, 1);
            trigger.StartBoundary = firstDate.Date + startTime;
            if (endTime > startTime)
                trigger.EndBoundary = lastDate.Date + endTime;
            else
                trigger.EndBoundary = lastDate.Date.AddDays(1) + endTime;

            ExecAction action = new ExecAction(applicationExe, arguments, Path.GetDirectoryName(applicationExe));

            def.Triggers.Add(trigger);
            def.Actions.Add(action);
            def.Principal.LogonType = TaskLogonType.InteractiveToken;
            def.RegistrationInfo.Description = "Comet Lighting Program\r\n\r\n" + string.Join("", sequences.Select(s => "    " + Path.GetFileName(s) + "\r\n"));
            def.Settings.WakeToRun = true;
            def.Settings.DisallowStartIfOnBatteries = false;
            def.Settings.StopIfGoingOnBatteries = false;
            def.Settings.RunOnlyIfIdle = false;
            def.Settings.IdleSettings.StopOnIdleEnd = false;
            def.Settings.AllowHardTerminate = true;
            def.Settings.ExecutionTimeLimit = TimeSpan.FromMinutes(minutes) - TimeSpan.FromSeconds(1);
            def.Settings.DeleteExpiredTaskAfter = TimeSpan.FromHours(12);

            taskService.RootFolder.RegisterTaskDefinition("Comet\\" + name, def);
        }

        public void UnregisterTask(TaskService taskService)
        {
            taskService.RootFolder.DeleteTask("Comet\\" + name, false);
        }
    }
}
