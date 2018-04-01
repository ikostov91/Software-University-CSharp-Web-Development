﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class FileAppender : IAppender
{
    public FileAppender(ILayout layout, ReportLevel reportLevel)
    {
        this.Layout = layout;
        this.ReportLevel = reportLevel;
        this.MessagesAppended = 0;
    }

    public ILayout Layout { get; private set; }

    public ReportLevel ReportLevel { get; set; }

    public int MessagesAppended { get; private set; }

    public void Append(string dateTime, ReportLevel reportLevel, string message)
    {
        if (this.ReportLevel <= reportLevel)
        {
            MessagesAppended += 1;
            File.AppendAllText("log.txt", string.Format(this.Layout.Format(), dateTime, reportLevel, message));
        }
    }

    private int FileSize()
    {
        int size = 0;
        string allText = File.ReadAllText("log.txt");
        foreach (char c in allText) size += (int)c;

        return size;
    }

    public string AppenderInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Appender type: {this.GetType().Name}, " +
                  $"Layout type: {this.Layout.GetType().Name}, " +
                  $"Report level: {this.ReportLevel.ToString()}, " +
                  $"Messages appended: {this.MessagesAppended}, " + 
                  $"File size: {this.FileSize()}");

        return sb.ToString();
    }
}

