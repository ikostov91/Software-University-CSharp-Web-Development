using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LogFile : ILogFile
{
    private StringBuilder sb;
    private int size;

    public LogFile()
    {
        sb = new StringBuilder();
        size = 0;
    }

    public int Size { get; private set; }

    public void Write(string message)
    {
        this.sb.AppendLine(message);

        this.Size += message
            .Where(c => char.IsLetter(c))
            .Sum(c => c);
    }

    public override string ToString()
    {
        return this.sb.ToString().Trim();
    }
}

