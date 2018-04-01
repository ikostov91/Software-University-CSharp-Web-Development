using System;
using System.Collections.Generic;
using System.Text;

public interface ILogger
{
    void Log(ReportLevel reportLevel, string dateTime, string message);

    void LoggerInfo();
}

