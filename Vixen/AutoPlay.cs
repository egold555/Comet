using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;
using CommandLine.Text;
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

        class AutoPlaySequence: IDisposable
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
        [Option('p', "play", HelpText="Play sequences instead of opening them")]
        public bool Play { get; set; }

        [Option("minutes", HelpText="Minutes that the playing go on for", DefaultValue = 10)]
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
}
