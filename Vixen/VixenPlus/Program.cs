﻿using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Properties;

namespace VixenPlus {
    internal static class Program {

        private static readonly string LogFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "crash.log");


        [STAThread]
        private static void Main(string[] args) {
            Application.ThreadException += ApplicationOnThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += ApplicationUnhandledException;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VixenPlusForm(args));
        }



        private static void ApplicationUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            var ex = e.ExceptionObject as Exception;
            ProcessException(ex, e.IsTerminating);
        }


        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e) {
            ProcessException(e.Exception, true);
        }


        private static void ProcessException(Exception ex, bool isTerminating) {
            LogException(ex.Message, ex.StackTrace, isTerminating);
            ShowException(ex, isTerminating);
        }



        private static void LogException(string message, string stack, bool isTerminating) {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            using (var crash = new StreamWriter(LogFileName, true)) {
                crash.WriteLine(Resources.FormattedVersion, version);
                crash.WriteLine(DateTime.Now);
                crash.WriteLine("Is Terminating? {0}", isTerminating);
                crash.WriteLine(message);
                crash.WriteLine(stack);
            }
        }


        private static void ShowException(Exception exception, bool isTerminating) {
            var msgFormat = isTerminating ? Resources.CriticalErrorOccurred : Resources.SoftErrorOccured;
            var msg = string.Format(msgFormat, LogFileName, exception.Message, exception.StackTrace, Vendor.ProductName);
            var btns = isTerminating ? MessageBoxButtons.OK : MessageBoxButtons.YesNo;
            var icon = isTerminating ? MessageBoxIcon.Error : MessageBoxIcon.Question;

            var res = MessageBox.Show(msg, Resources.ErrorLogCreated, btns, icon);
            if (res == DialogResult.No || res == DialogResult.OK) {
                Application.Exit();
            }
        }
    }
}
