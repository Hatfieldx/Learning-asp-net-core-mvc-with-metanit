using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
namespace TagHelpers
{
    public class TimerTagHelper : TagHelper
    {
        IConfiguration _config;
        public bool IsUsed { get; set; } = true;
        public string Message { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!IsUsed)
            {
                output.SuppressOutput();
            } 
            
            output.TagName = "div";

            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetContent($"Current time: {DateTime.Now.ToString("HH:mm:ss")}");
            
            //base.Process(context, output);
        }
        public TimerTagHelper(IConfiguration config)
        {
            _config = config;
        }
    }
}
