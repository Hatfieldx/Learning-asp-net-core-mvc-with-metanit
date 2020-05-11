using Microsoft.Extensions.Configuration;

namespace ConfigEdu.ConfigurationProvider
{
    public class TextFileSource : IConfigurationSource
    {
        public string Path { get; private set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filepath = builder.GetFileProvider().GetFileInfo(Path).PhysicalPath;
            
            return new TextFileProvider(filepath);
        }

        public TextFileSource(string path)
        {
            Path = path;
        }
    }
}
