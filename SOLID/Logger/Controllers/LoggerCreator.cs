using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LoggerCreator
{
    public ILogger CreateLogger()
    {
        int numberOfAppenders = int.Parse(Console.ReadLine());
        AppenderFactory appenderFactory = new AppenderFactory();
        List<IAppender> appenders = new List<IAppender>();

        for (int i = 0; i < numberOfAppenders; i++)
        {
            string[] appenderInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();
            IAppender appender = appenderFactory.CreateAppender(appenderInfo);
            appenders.Add(appender);
        }

        ILogger logger = new Logger(appenders);

        return logger;
    }
}

