using System;
using Microsoft.Extensions.Logging;

namespace ConfigEdu
{ 
    public static class TextFileFactoryExt
    {

        public static ILoggerFactory AddFileProvider(this ILoggerFactory loggerFactory, string path)
        {
            loggerFactory.AddProvider(new TextLoggerProvider(path));

            return loggerFactory;
        }
    }
}
