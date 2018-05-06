using System;
using System.Collections.Generic;
using System.Text;

public abstract class Appender : IAppender
{
    protected Appender(ILayout layout)
    {
        this.Layout = layout;
        this.ReportLevel = 0;
        this.MessagesAppended = 0;
    }

    public ILayout Layout { get; private set; }

    public ReportLevel ReportLevel { get; set; }

    public int MessagesAppended { get; protected set; }

    public abstract void Append(string dateTime, string reportLevel, string message);

    public bool IsMessageLevelValid(string messageLevel)
    {
        string upperLetteresMessage = messageLevel.ToUpper();

        return (ReportLevel)Enum.Parse(typeof(ReportLevel), upperLetteresMessage) >= this.ReportLevel;
    }

    public override string ToString()
    { 
        return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}";
    }
}

