using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout) : base(layout)
    {
    }

    public override void Append(string dateTime, string reportLevel, string message)
    {
        if (this.IsMessageLevelValid(reportLevel))
        {
           this.MessagesAppended += 1;
            Console.WriteLine(string.Format(this.Layout.Format(), dateTime, reportLevel, message));
        }
    }
}

