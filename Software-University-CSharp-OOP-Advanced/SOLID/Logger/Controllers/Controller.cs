using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

public class Controller
{
    private AppenderFactory appenderFactory;
    private IList<IAppender> appenders;
    private ILogger logger;

    public Controller()
    {
        appenderFactory = new AppenderFactory();
        appenders = new List<IAppender>();
        logger = null;
    }

    public void GetAppenders()
    {
        int numberOfAppenders = int.Parse(Console.ReadLine());

        while (numberOfAppenders > 0)
        {
            string[] appenderInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None);
            string appenderType = appenderInfo[0];
            string layoutType = appenderInfo[1];

            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layoutType);

            if (appenderInfo.Length > 2)
            {
                string reportLevel = appenderInfo[2].ToUpper();
                SetAppenderTreshold(appender, reportLevel);
            }

            this.appenders.Add(appender);
            numberOfAppenders--;
        }
    }

    public void GetLogger()
    {
        this.logger = new Logger(this.appenders);
    }

    public void ProcessMessages()
    {
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] report = input.Split(new char[] {'|'}, StringSplitOptions.None);
            string reportLevel = report[0];
            string dateTime = report[1];
            string message = report[2];

            logger.Log(reportLevel, dateTime, message);
        }
    }

    public void PrintLoggerInfo()
    {
        Console.WriteLine(this.logger.ToString());
    }

    private void SetAppenderTreshold(IAppender appender, string reportLevelName)
    {
        ReportLevel reportTreshold;
        bool isLevelValid = Enum.TryParse(reportLevelName, out reportTreshold);

        if (isLevelValid)
        {
            appender.ReportLevel = reportTreshold;
        }
    }
}

