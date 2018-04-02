using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class FileAppender : Appender
{
    private string FileName = "log.txt";
    private readonly string FilePath;

    public FileAppender(ILayout layout) : base(layout)
    {
        this.FilePath = Path.Combine(Environment.CurrentDirectory, FileName);
        this.File = new LogFile();
    }

    public ILogFile File { get; set; }

    public override void Append(string dateTime, string reportLevel, string message)
    {
        if (this.IsMessageLevelValid(reportLevel))
        {
            string report = string.Format(this.Layout.Format(), dateTime, reportLevel, message);
            File.Write(report);
            System.IO.File.AppendAllText(FilePath, report);
            System.IO.File.AppendAllText(FilePath, Environment.NewLine);
            MessagesAppended += 1;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}, File size: {File.Size}";
    }
}

