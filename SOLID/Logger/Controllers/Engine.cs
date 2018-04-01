using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    public void Run()
    {
        LoggerCreator loggerCreator = new LoggerCreator();
        ILogger logger = loggerCreator.CreateLogger();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] report = input.Split(new char[] { '|' }, StringSplitOptions.None).ToArray();
            ReportLevel reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), report[0]);
            string dateTime = report[1];
            string message = report[2];

            logger.Log(reportLevel, dateTime, message);
        }

        logger.LoggerInfo();
    }
}

