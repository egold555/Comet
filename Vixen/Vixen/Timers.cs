﻿namespace Vixen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    internal class Timers : IQueryable
    {
        private bool m_disabled = false;
        private Timer[] m_timers = new Timer[0];

        public List<Timer> CurrentlyEffectiveTimers()
        {
            return this.EffectiveTimers(0x7fffffff);
        }

        private List<Timer> EffectiveTimers(int deviationToleranceInMinutes)
        {
            bool flag = Host.GetDebugValue("TimerTrace") != null;
            if (flag)
            {
                Host.LogTo(Paths.TimerTraceFilePath, string.Format("Determining effective timers at {0}...", DateTime.Now));
            }
            List<Timer> list = new List<Timer>();
            DateTime now = DateTime.Now;
            DateTime today = DateTime.Today;
            foreach (Timer timer in this.m_timers)
            {
                int num;
                if (flag)
                {
                    Host.LogTo(Paths.TimerTraceFilePath, "Timer for: " + timer.ProgramName);
                    Host.LogTo(Paths.TimerTraceFilePath, "Recurrence: " + timer.Recurrence.ToString());
                    if (timer.Recurrence == RecurrenceType.Weekly)
                    {
                        Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} & {1} != 0 ({2})", (int) timer.RecurrenceData, ((int) 1) << now.DayOfWeek, (((int) timer.RecurrenceData) & (((int) 1) << now.DayOfWeek)) != 0));
                    }
                    Host.LogTo(Paths.TimerTraceFilePath, "  Is executing? " + timer.IsExecuting.ToString());
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1} ({2})", timer.RecurrenceStart, today.AddDays(1.0), timer.RecurrenceStart > today.AddDays(1.0)));
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1} ({2})", timer.RecurrenceEnd, today, timer.RecurrenceEnd < today));
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1} ({2})", timer.RecurrenceStartDateTime, now, timer.RecurrenceStartDateTime > now));
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1} ({2})", timer.RecurrenceEndDateTime, now, timer.RecurrenceEndDateTime < now));
                }
                if ((!timer.IsExecuting && ((timer.RecurrenceStart <= today.AddDays(1.0)) && (timer.RecurrenceEnd >= today))) && ((timer.RecurrenceStartDateTime <= now) && (timer.RecurrenceEndDateTime >= now)))
                {
                    if (deviationToleranceInMinutes == 0x7fffffff)
                    {
                        if (!this.RepeatingInstanceIntersects(timer, now))
                        {
                            goto Label_04CB;
                        }
                    }
                    else if (!this.RepeatingInstanceIntersects(timer, now, deviationToleranceInMinutes))
                    {
                        goto Label_04CB;
                    }
                    switch (timer.Recurrence)
                    {
                        case RecurrenceType.None:
                            list.Add(timer);
                            goto Label_04CB;

                        case RecurrenceType.Daily:
                            list.Add(timer);
                            goto Label_04CB;

                        case RecurrenceType.Weekly:
                            if ((((int) timer.RecurrenceData) & (((int) 1) << now.DayOfWeek)) != 0)
                            {
                                list.Add(timer);
                            }
                            goto Label_04CB;

                        case RecurrenceType.Monthly:
                            if (!(timer.RecurrenceData is string))
                            {
                                goto Label_0436;
                            }
                            if (!(((string) timer.RecurrenceData) == "first"))
                            {
                                goto Label_03E2;
                            }
                            if (today.Day == 1)
                            {
                                list.Add(timer);
                            }
                            goto Label_04CB;

                        case RecurrenceType.Yearly:
                        {
                            DateTime recurrenceData = (DateTime) timer.RecurrenceData;
                            if ((today.Month == recurrenceData.Month) && (today.Day == recurrenceData.Day))
                            {
                                list.Add(timer);
                            }
                            goto Label_04CB;
                        }
                    }
                }
                goto Label_04CB;
            Label_03E2:
                if ((((string) timer.RecurrenceData) == "last") && (today.Day == DateTime.DaysInMonth(today.Year, today.Month)))
                {
                    list.Add(timer);
                }
                goto Label_04CB;
            Label_0436:
                num = (int) timer.RecurrenceData;
                num = Math.Min(num, DateTime.DaysInMonth(today.Year, today.Month));
                if (today.Day == num)
                {
                    list.Add(timer);
                }
            Label_04CB:;
            }
            if (flag)
            {
                Host.LogTo(Paths.TimerTraceFilePath, "...done.");
            }
            return list;
        }

        public void LoadFromXml(XmlNode contextNode)
        {
            XmlNode node = contextNode.SelectSingleNode("Timers");
            bool flag = false;
            this.m_disabled = node.Attributes["enabled"].Value == flag.ToString();
            List<Timer> list = new List<Timer>();
            foreach (XmlNode node2 in node.SelectNodes("Timer"))
            {
                Timer item = new Timer(node2);
                if (item.RecurrenceEnd >= DateTime.Today)
                {
                    list.Add(item);
                }
            }
            this.m_timers = list.ToArray();
        }

        public string QueryInstance(int index)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Disabled: " + this.m_disabled);
            builder.AppendLine("Timer count: " + this.m_timers.Length);
            if (this.m_timers.Length > 0)
            {
                builder.AppendLine("Timers:");
                foreach (Timer timer in this.m_timers)
                {
                    builder.AppendLine("   Start date: " + timer.StartDate);
                    builder.AppendLine("   Start time: " + timer.StartTime);
                    builder.AppendLine("   Timer length: " + timer.TimerLength);
                    builder.AppendLine("   Repeat interval: " + timer.RepeatInterval);
                    builder.AppendLine("   Recurrence: " + timer.Recurrence);
                    builder.AppendLine("   Recurrence start: " + timer.RecurrenceStart);
                    builder.AppendLine("   Recurrence end: " + timer.RecurrenceEnd);
                    builder.AppendLine("   Program: " + timer.ProgramName);
                    builder.AppendLine("   Object type: " + timer.ObjectType);
                    builder.AppendLine("   Object length: " + timer.ObjectLength);
                    builder.AppendLine("   Last execution: " + timer.LastExecution);
                    builder.AppendLine("   Not valid until: " + timer.NotValidUntil);
                    builder.AppendLine("   Executing: " + timer.IsExecuting);
                    builder.AppendLine("   End date: " + timer.EndDate);
                    builder.AppendLine("   End time: " + timer.EndTime);
                }
                List<Timer> list = this.StartingTimers();
                builder.AppendLine("Starting timer count: " + list.Count);
                if (list.Count > 0)
                {
                    builder.AppendLine("Timers:");
                    foreach (Timer timer in list)
                    {
                        builder.AppendLine(string.Format("   {0} at {1}", timer.ProgramName, timer.StartDateTime));
                    }
                }
                list = this.CurrentlyEffectiveTimers();
                builder.AppendLine("Currently-effective timer count: " + list.Count);
                if (list.Count > 0)
                {
                    builder.AppendLine("Timers:");
                    foreach (Timer timer in list)
                    {
                        builder.AppendLine(string.Format("   {0} at {1}", timer.ProgramName, timer.StartDateTime));
                    }
                }
            }
            return builder.ToString();
        }

        private bool RepeatingInstanceIntersects(Timer timer, DateTime intersectionDateTime)
        {
            TimeSpan span;
            bool flag = Host.GetDebugValue("TimerTrace") != null;
            if (flag)
            {
                Host.LogTo(Paths.TimerTraceFilePath, "DateTime intersection");
                Host.LogTo(Paths.TimerTraceFilePath, "Interval: " + timer.RepeatInterval.ToString());
            }
            if (timer.RepeatInterval == 0)
            {
                if (flag)
                {
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1} ({2})", timer.StartTime, intersectionDateTime.TimeOfDay, timer.StartTime > intersectionDateTime.TimeOfDay));
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1} ({2})", timer.EndTime, intersectionDateTime.TimeOfDay, timer.EndTime < intersectionDateTime.TimeOfDay));
                }
                return ((timer.StartTime <= intersectionDateTime.TimeOfDay) && (timer.EndTime >= intersectionDateTime.TimeOfDay));
            }
            if (flag)
            {
                object[] args = new object[6];
                args[0] = intersectionDateTime.TimeOfDay;
                args[1] = timer.StartTime;
                span = intersectionDateTime.TimeOfDay - timer.StartTime;
                args[2] = span.TotalMinutes;
                args[3] = timer.RepeatInterval;
                args[4] = timer.TimerLength.TotalMinutes;
                span = intersectionDateTime.TimeOfDay - timer.StartTime;
                args[5] = (span.TotalMinutes % ((double) timer.RepeatInterval)) < timer.TimerLength.TotalMinutes;
                Host.LogTo(Paths.TimerTraceFilePath, string.Format("  ({0} - {1})[{2}] % {3} < {4} ({5})", args));
            }
            span = intersectionDateTime.TimeOfDay - timer.StartTime;
            double totalMinutes = span.TotalMinutes;
            return ((totalMinutes > 0.0) && ((totalMinutes % ((double) timer.RepeatInterval)) < timer.TimerLength.TotalMinutes));
        }

        private bool RepeatingInstanceIntersects(Timer timer, DateTime intersectionDateTime, int deviationTolerance)
        {
            int num;
            double num2;
            TimeSpan span;
            bool flag = Host.GetDebugValue("TimerTrace") != null;
            if (flag)
            {
                Host.LogTo(Paths.TimerTraceFilePath, "DateTime intersection with tolerance of " + deviationTolerance.ToString());
                Host.LogTo(Paths.TimerTraceFilePath, "Interval: " + timer.RepeatInterval.ToString());
            }
            if (timer.RepeatInterval == 0)
            {
                if (flag)
                {
                    span = intersectionDateTime.TimeOfDay - timer.StartTime;
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} - {1}[{2}]", intersectionDateTime.TimeOfDay, timer.StartTime, span.TotalMinutes));
                }
                span = intersectionDateTime.TimeOfDay - timer.StartTime;
                num = (int) (num2 = span.TotalMinutes);
            }
            else
            {
                if (flag)
                {
                    object[] args = new object[4];
                    args[0] = intersectionDateTime.TimeOfDay;
                    args[1] = timer.StartTime;
                    span = intersectionDateTime.TimeOfDay - timer.StartTime;
                    args[2] = span.TotalMinutes;
                    args[3] = timer.RepeatInterval;
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  ({0} - {1})[{2}] % {3}", args));
                }
                span = intersectionDateTime.TimeOfDay - timer.StartTime;
                num = (int) (num2 = span.TotalMinutes % ((double) timer.RepeatInterval));
            }
            if (flag)
            {
                Host.LogTo(Paths.TimerTraceFilePath, "  Deviation: " + num2.ToString());
                Host.LogTo(Paths.TimerTraceFilePath, "  Minutes: " + num.ToString());
            }
            return ((num2 >= 0.0) && (num <= deviationTolerance));
        }

        public void SaveToXml(XmlNode contextNode)
        {
            bool flag;
            XmlDocument document = (contextNode.OwnerDocument == null) ? ((XmlDocument) contextNode) : contextNode.OwnerDocument;
            XmlNode emptyNodeAlways = Xml.GetEmptyNodeAlways(contextNode, "Timers");
            Xml.SetAttribute(emptyNodeAlways, "enabled", this.m_disabled ? (flag = false).ToString() : (flag = true).ToString());
            foreach (Timer timer in this.m_timers)
            {
                timer.SaveToXml(emptyNodeAlways);
            }
        }

        public List<Timer> StartingTimers()
        {
            bool flag = Host.GetDebugValue("TimerTrace") != null;
            List<Timer> list = new List<Timer>();
            foreach (Timer timer in this.EffectiveTimers(0))
            {
                if (timer.NotValidUntil <= DateTime.Now)
                {
                    list.Add(timer);
                }
                else if (flag)
                {
                    Host.LogTo(Paths.TimerTraceFilePath, "Starting timers, timer not yet valid:");
                    Host.LogTo(Paths.TimerTraceFilePath, "  " + timer.ProgramName);
                    Host.LogTo(Paths.TimerTraceFilePath, string.Format("  {0} > {1}", timer.NotValidUntil, DateTime.Now));
                }
            }
            return list;
        }

        public int Count
        {
            get
            {
                return 1;
            }
        }

        public Timer[] TimerArray
        {
            get
            {
                return this.m_timers;
            }
            set
            {
                this.m_timers = value;
            }
        }

        public bool TimersDisabled
        {
            get
            {
                return this.m_disabled;
            }
            set
            {
                this.m_disabled = value;
            }
        }
    }
}

