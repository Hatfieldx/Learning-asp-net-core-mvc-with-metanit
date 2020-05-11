using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomViewEngine.Util
{
    public class CustomView : IView
    {
        public string Path {get; set;}

        public async Task RenderAsync(ViewContext context)
        {
            string content = string.Empty;

            using (StreamReader sr = new StreamReader(Path))
            {
                content = await sr.ReadToEndAsync();
            }

            await context.Writer.WriteAsync(content);
        }

        public CustomView(string path)
        {
            Path = path;
        }
    }
}
