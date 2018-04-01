using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

public class AppenderFactory
{
    public IAppender CreateAppender(string[] appenderInfo)
    {
        ILayout layout = null;
        switch (appenderInfo[1])
        {
            case "SimpleLayout":
                layout = new SimpleLayout();
                break;
            case "XmlLayout":
                layout = new XmlLayout();
                break;
            default:
                throw new ArgumentException("Layout type does not exist.");
        }

        ReportLevel reportLevel;
        if (appenderInfo.Length == 3)
        {
            reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), appenderInfo[2]);
        }
        else
        {
            reportLevel = ReportLevel.INFO;
        }

        IAppender appender;
        switch (appenderInfo[0])
        {
            case "ConsoleAppender":
                appender = new ConsoleAppender(layout, reportLevel);
                break;
            case "FileAppender":
                appender = new FileAppender(layout, reportLevel);
                break;
            default:
                throw new ArgumentException("Appender type does not exist.");
        }

        return appender;
    }
}

