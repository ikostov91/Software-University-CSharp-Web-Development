using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

class Logger : ILogger
{
    private List<IAppender> appenders;

    public Logger(List<IAppender> appenders)
    {
        this.appenders = appenders;
    }

    public void Log(ReportLevel reportLever, string dateTime, string message)
    {
        foreach (var appender in this.appenders)
        {
            appender.Append(dateTime, reportLever, message);
        }
    }

    public void LoggerInfo()
    {
        Console.WriteLine("Logger info");
        foreach (var appender in appenders)
        {
            Console.WriteLine(appender.AppenderInfo());
        }
    }
}

