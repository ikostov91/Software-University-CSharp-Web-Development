using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleAppender : IAppender
{
    public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
    {
        this.Layout = layout;
        this.ReportLevel = reportLevel;
        this.MessagesAppended = 0;
    }

    public ILayout Layout { get; private set; }

    public ReportLevel ReportLevel { get; set; }

    public int MessagesAppended { get; private set; }

    public void Append(string dateTime, ReportLevel reportLevel, string message)
    {
        if (this.ReportLevel <= reportLevel)
        {
            MessagesAppended += 1;
            Console.WriteLine(string.Format(this.Layout.Format(), dateTime, reportLevel, message));
        }
    }

    public string AppenderInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Appender type: {this.GetType().Name}, " +
                  $"Layout type: {this.Layout.GetType().Name}, " +
                  $"Report level: {this.ReportLevel.ToString()}, " +
                  $"Messages appended: {this.MessagesAppended}");

        return sb.ToString();
    }
}

