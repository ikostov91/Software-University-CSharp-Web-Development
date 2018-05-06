using System;
using System.Collections.Generic;
using System.Text;

public interface ILogger
{
    void Log(string reportLevel, string dateTime, string message);
}

