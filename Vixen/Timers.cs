﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

internal class Timers : IQueryable
{
    private Timer[] _timers = new Timer[0];

    public IEnumerable<Timer> TimerArray
    {
        get { return _timers; }
/*
        set { _timers = value; }
*/
    }

    public bool TimersDisabled { get; private set; }

    /*
    public string QueryInstance(int index)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Disabled: " + _isDisabled);
        builder.AppendLine("Timer count: " + _timers.Length);
        if (_timers.Length <= 0) {
            return builder.ToString();
        }
        builder.AppendLine("Timers:");
        foreach (var timer in _timers)
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
        var list = StartingTimers();
        builder.AppendLine("Starting timer count: " + list.Count);
        if (list.Count > 0)
        {
            builder.AppendLine("Timers:");
            foreach (var timer in list)
            {
                builder.AppendLine(string.Format("   {0} at {1}", timer.ProgramName, timer.StartDateTime));
            }
        }
        list = CurrentlyEffectiveTimers();
        builder.AppendLine("Currently-effective timer count: " + list.Count);
        if (list.Count <= 0) {
            return builder.ToString();
        }
        builder.AppendLine("Timers:");
        foreach (var timer in list)
        {
            builder.AppendLine(string.Format("   {0} at {1}", timer.ProgramName, timer.StartDateTime));
        }
        return builder.ToString();
    }
*/

/*
    public int Count
    {
        get { return 1; }
    }
*/

    public IEnumerable<Timer> CurrentlyEffectiveTimers()
    {
        return EffectiveTimers(0x7fffffff);
    }

    private IEnumerable<Timer> EffectiveTimers(int deviationToleranceInMinutes)
    {
        var flag = Host.GetDebugValue("TimerTrace") != null;
        if (flag)
        {
            Host.LogTo(Paths.TimerTraceFilePath, string.Format("Determining effective timers at {0}...", DateTime.Now));
        }
        var list = new List<Timer>();
        var now = DateTime.Now;
        var today = DateTime.Today;
        foreach (var timer in _timers)
        {
            if (flag)
            {
                Host.LogTo(Paths.TimerTraceFilePath, "Timer for: " + timer.ProgramName);
                Host.LogTo(Paths.TimerTraceFilePath, "Recurrence: " + timer.Recurrence);
                if (timer.Recurrence == RecurrenceType.Weekly)
                {
                    Host.LogTo(Paths.TimerTraceFilePath,
                        string.Format("  {0} & {1} != 0 ({2})", (int) timer.RecurrenceData, (1) << (int) now.DayOfWeek,
                            (((int) timer.RecurrenceData) & ((1) << (int) now.DayOfWeek)) != 0));
                }
                Host.LogTo(Paths.TimerTraceFilePath, "  Is executing? " + timer.IsExecuting);
                Host.LogTo(Paths.TimerTraceFilePath,
                    string.Format("  {0} > {1} ({2})", timer.RecurrenceStart, today.AddDays(1.0),
                        timer.RecurrenceStart > today.AddDays(1.0)));
                Host.LogTo(Paths.TimerTraceFilePath,
                    string.Format("  {0} > {1} ({2})", timer.RecurrenceEnd, today, timer.RecurrenceEnd < today));
                Host.LogTo(Paths.TimerTraceFilePath,
                    string.Format("  {0} > {1} ({2})", timer.RecurrenceStartDateTime, now,
                        timer.RecurrenceStartDateTime > now));
                Host.LogTo(Paths.TimerTraceFilePath,
                    string.Format("  {0} > {1} ({2})", timer.RecurrenceEndDateTime, now, timer.RecurrenceEndDateTime < now));
            }
            if ((!timer.IsExecuting && ((timer.RecurrenceStart <= today.AddDays(1.0)) && (timer.RecurrenceEnd >= today))) &&
                ((timer.RecurrenceStartDateTime <= now) && (timer.RecurrenceEndDateTime >= now)))
            {
                if (deviationToleranceInMinutes == 0x7fffffff)
                {
                    if (!RepeatingInstanceIntersects(timer, now))
                    {
                        goto Label_04CB;
                    }
                }
                else if (!RepeatingInstanceIntersects(timer, now, deviationToleranceInMinutes))
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
                        if ((((int) timer.RecurrenceData) & ((1) << (int) now.DayOfWeek)) != 0)
                        {
                            list.Add(timer);
                        }
                        goto Label_04CB;

                    case RecurrenceType.Monthly:
                        if (!(timer.RecurrenceData is string))
                        {
                            goto Label_0436;
                        }
                        if (((string) timer.RecurrenceData) != "first")
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
                        var recurrenceData = (DateTime) timer.RecurrenceData;
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
            var num = (int) timer.RecurrenceData;
            num = Math.Min(num, DateTime.DaysInMonth(today.Year, today.Month));
            if (today.Day == num)
            {
                list.Add(timer);
            }
            Label_04CB:
            ;
        }
        if (flag)
        {
            Host.LogTo(Paths.TimerTraceFilePath, "...done.");
        }
        return list;
    }

    public void LoadFromXml(XmlNode contextNode)
    {
        var node = contextNode.SelectSingleNode("Timers");
        const bool flag = false;
        if (node != null && node.Attributes != null)
        {
            TimersDisabled = node.Attributes["enabled"].Value == flag.ToString();
        }
        var list = new List<Timer>();
        if (node != null)
        {
            var timerNode = node.SelectNodes("Timer");
            if (timerNode != null)
            {
                list.AddRange(timerNode.Cast<XmlNode>().Select(node2 => new Timer(node2)).Where(item => item.RecurrenceEnd >= DateTime.Today));
            }
        }
        _timers = list.ToArray();
    }

    private bool RepeatingInstanceIntersects(Timer timer, DateTime intersectionDateTime)
    {
        TimeSpan span;
        var flag = Host.GetDebugValue("TimerTrace") != null;
        if (flag)
        {
            Host.LogTo(Paths.TimerTraceFilePath, "DateTime intersection");
            Host.LogTo(Paths.TimerTraceFilePath, "Interval: " + timer.RepeatInterval.ToString(CultureInfo.InvariantCulture));
        }
        if (timer.RepeatInterval == 0)
        {
            if (!flag) {
                return ((timer.StartTime <= intersectionDateTime.TimeOfDay) && (timer.EndTime >= intersectionDateTime.TimeOfDay));
            }
            Host.LogTo(Paths.TimerTraceFilePath,
                string.Format("  {0} > {1} ({2})", timer.StartTime, intersectionDateTime.TimeOfDay,
                    timer.StartTime > intersectionDateTime.TimeOfDay));
            Host.LogTo(Paths.TimerTraceFilePath,
                string.Format("  {0} > {1} ({2})", timer.EndTime, intersectionDateTime.TimeOfDay,
                    timer.EndTime < intersectionDateTime.TimeOfDay));
            return ((timer.StartTime <= intersectionDateTime.TimeOfDay) && (timer.EndTime >= intersectionDateTime.TimeOfDay));
        }
        if (flag)
        {
            var args = new object[6];
            args[0] = intersectionDateTime.TimeOfDay;
            args[1] = timer.StartTime;
            span = intersectionDateTime.TimeOfDay - timer.StartTime;
            args[2] = span.TotalMinutes;
            args[3] = timer.RepeatInterval;
            args[4] = timer.TimerLength.TotalMinutes;
            span = intersectionDateTime.TimeOfDay - timer.StartTime;
            args[5] = (span.TotalMinutes%(timer.RepeatInterval)) < timer.TimerLength.TotalMinutes;
            Host.LogTo(Paths.TimerTraceFilePath, string.Format("  ({0} - {1})[{2}] % {3} < {4} ({5})", args));
        }
        span = intersectionDateTime.TimeOfDay - timer.StartTime;
        var totalMinutes = span.TotalMinutes;
        return ((totalMinutes > 0.0) && ((totalMinutes%(timer.RepeatInterval)) < timer.TimerLength.TotalMinutes));
    }

    private bool RepeatingInstanceIntersects(Timer timer, DateTime intersectionDateTime, int deviationTolerance)
    {
        int num;
        double num2;
        TimeSpan span;
        var flag = Host.GetDebugValue("TimerTrace") != null;
        if (flag)
        {
            Host.LogTo(Paths.TimerTraceFilePath,
                "DateTime intersection with tolerance of " + deviationTolerance.ToString(CultureInfo.InvariantCulture));
            Host.LogTo(Paths.TimerTraceFilePath, "Interval: " + timer.RepeatInterval.ToString(CultureInfo.InvariantCulture));
        }
        if (timer.RepeatInterval == 0)
        {
            if (flag)
            {
                span = intersectionDateTime.TimeOfDay - timer.StartTime;
                Host.LogTo(Paths.TimerTraceFilePath,
                    string.Format("  {0} - {1}[{2}]", intersectionDateTime.TimeOfDay, timer.StartTime, span.TotalMinutes));
            }
            span = intersectionDateTime.TimeOfDay - timer.StartTime;
            num = (int) (num2 = span.TotalMinutes);
        }
        else
        {
            if (flag)
            {
                var args = new object[4];
                args[0] = intersectionDateTime.TimeOfDay;
                args[1] = timer.StartTime;
                span = intersectionDateTime.TimeOfDay - timer.StartTime;
                args[2] = span.TotalMinutes;
                args[3] = timer.RepeatInterval;
                Host.LogTo(Paths.TimerTraceFilePath, string.Format("  ({0} - {1})[{2}] % {3}", args));
            }
            span = intersectionDateTime.TimeOfDay - timer.StartTime;
            num = (int) (num2 = span.TotalMinutes%(timer.RepeatInterval));
        }
        if (!flag) {
            return ((num2 >= 0.0) && (num <= deviationTolerance));
        }
        Host.LogTo(Paths.TimerTraceFilePath, "  Deviation: " + num2.ToString(CultureInfo.InvariantCulture));
        Host.LogTo(Paths.TimerTraceFilePath, "  Minutes: " + num.ToString(CultureInfo.InvariantCulture));
        return ((num2 >= 0.0) && (num <= deviationTolerance));
    }

/*
    public void SaveToXml(XmlNode contextNode)
    {
        //XmlDocument document = contextNode.OwnerDocument ?? ((XmlDocument) contextNode);
        var emptyNodeAlways = Xml.GetEmptyNodeAlways(contextNode, "Timers");
        Xml.SetAttribute(emptyNodeAlways, "enabled", _isDisabled ? false.ToString() : true.ToString());
        foreach (var timer in _timers)
        {
            timer.SaveToXml(emptyNodeAlways);
        }
    }
*/

    public IEnumerable<Timer> StartingTimers()
    {
        var flag = Host.GetDebugValue("TimerTrace") != null;
        var list = new List<Timer>();
        foreach (var timer in EffectiveTimers(0))
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
}