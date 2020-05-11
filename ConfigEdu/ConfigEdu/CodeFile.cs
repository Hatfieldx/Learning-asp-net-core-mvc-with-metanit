using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System;

public class TextFileLogger : ILogger
{
    string _path;
    static object _lock = new object();


    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (formatter != null)
        {
            lock (_lock)
            {
                File.AppendAllText(_path, formatter(state, exception) + Environment.NewLine);
            }
        }
    }

    public TextFileLogger(string path)
    {
        _path = path;
    }
}

public class FileLoggerProvider : ILoggerProvider
{
    string _path;



    public ILogger CreateLogger(string categoryName)
    {
        return new TextFileLogger(_path);
    }

    public void Dispose()
    {

    }
    public FileLoggerProvider(string path)
    {
        _path = path;
    }
}

public static class FileLoggerExt
{
    public static ILoggerFactory AddFile(this ILoggerFactory factory, string path)
    {
        factory.AddProvider(new FileLoggerProvider(path));

        return factory;

    }
}

public class Startup
{
    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
        var logger = loggerFactory.CreateLogger("FileLogger");

        app.Run(async (context) =>
        {
            logger.LogInformation("Processing request {0}", context.Request.Path);
            await context.Response.WriteAsync("Hello World!");
        });
    }
}