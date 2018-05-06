using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

public class AppenderFactory
{
    public IAppender CreateAppender(string appenderType, string layoutType)
    {
        ILayout layout = null;
        switch (layoutType)
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

        IAppender appender;
        switch (appenderType)
        {
            case "ConsoleAppender":
                appender = new ConsoleAppender(layout);
                break;
            case "FileAppender":
                appender = new FileAppender(layout);
                break;
            default:
                throw new ArgumentException("Appender type does not exist.");
        }

        return appender;
    }
}

