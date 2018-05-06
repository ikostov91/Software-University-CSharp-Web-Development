using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender
{
    ILayout Layout { get; }

    ReportLevel ReportLevel { get; set; }

    int MessagesAppended { get; }

    void Append(string dateTime, string reportLevel, string message);
}

