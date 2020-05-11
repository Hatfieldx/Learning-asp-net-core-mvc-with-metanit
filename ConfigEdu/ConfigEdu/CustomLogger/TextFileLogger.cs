using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ConfigEdu
{
    public class TextFileLogger : ILogger
    {
        readonly string _path;
        static object _lock = new object();

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(_path, formatter(state, exception));
                }
            }            
        }

        public TextFileLogger(string path)
        {
            _path = path;
        }
    }
}
