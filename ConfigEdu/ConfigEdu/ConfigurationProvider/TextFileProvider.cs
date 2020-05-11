using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace ConfigEdu.ConfigurationProvider
{
    public class TextFileProvider : Microsoft.Extensions.Configuration.ConfigurationProvider
    {
        public string Path { get; set; }

        //
        // Summary:
        //     Loads (or reloads) the data for this provider.
        public override void Load()
        {
            Dictionary<string, string> data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            
            string line;
            string[] param;
            
            using (StreamReader sr = new StreamReader(Path, Encoding.UTF8))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower().Trim();

                    param = line.Split('=', 2, options: StringSplitOptions.RemoveEmptyEntries);

                    data.Add(param[0], param[1]);
                }
            }

            Data = data;
        }

        public TextFileProvider(string path)
        {
            Path = path;
        }

    }
}
