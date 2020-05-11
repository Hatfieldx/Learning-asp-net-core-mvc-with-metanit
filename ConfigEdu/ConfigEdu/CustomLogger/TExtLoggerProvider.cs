using Microsoft.Extensions.Logging;

namespace ConfigEdu
{
    public class TextLoggerProvider : ILoggerProvider
    {
        readonly string _path;
        public ILogger CreateLogger(string categoryName)
        {
            return new TextFileLogger(_path);
        }

        public void Dispose()
        {
            
        }

        public TextLoggerProvider(string path)
        {
            _path = path;
        }
    }
}
