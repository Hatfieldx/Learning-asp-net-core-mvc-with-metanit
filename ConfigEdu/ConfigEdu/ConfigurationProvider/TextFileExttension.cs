using Microsoft.Extensions.Configuration;

namespace ConfigEdu.ConfigurationProvider
{
    public static class TextFileExttension
    {
       public static IConfigurationBuilder AddTextFile(this IConfigurationBuilder builder, string path)
        {
            builder.Add(new TextFileSource(path)); 
            
            return builder;
        }
    }
}
