﻿using Eventures.Data;
using Microsoft.Extensions.Logging;
using System;

namespace Eventures.Web.Logging
{
    public class DbLogger : ILogger
    {
        private string categoryName;
        private Func<string, LogLevel, bool> filer;
        private EventuresDbContext context;

        public DbLogger(string categoryName, 
            Func<string, LogLevel, bool> filter,
            EventuresDbContext dbContext)
        {
            this.categoryName = categoryName;
            this.filer = filter;
            this.context = dbContext;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            this.context.Logs.Add(new Eventures.Models.CustomLog());
            this.context.SaveChanges();
        }
    }
}
