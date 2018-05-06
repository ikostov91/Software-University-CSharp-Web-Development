using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

class Logger : ILogger
{
    private IList<IAppender> appenders;

    public Logger(IList<IAppender> appenders)
    {
        this.appenders = appenders;
    }

    public void Log(string reportLever, string dateTime, string message)
    {
        foreach (var appender in this.appenders)
        {
            appender.Append(dateTime, reportLever, message);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Logger info");
        foreach (var appender in appenders)
        {
            sb.AppendLine(appender.ToString().Trim());
        }

        return sb.ToString();
    }
}

