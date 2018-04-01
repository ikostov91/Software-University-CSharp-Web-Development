using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender
{
    void Append(string dateTime, ReportLevel reportLevel, string message);

    ILayout Layout { get; }

    ReportLevel ReportLevel { get; set; }

    int MessagesAppended { get; }

    string AppenderInfo();
}

