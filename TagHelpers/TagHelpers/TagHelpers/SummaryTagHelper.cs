using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelpers.TagHelpers
{
    public class SummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {   
            output.TagName = "div";

            var target = await output.GetChildContentAsync();

            var content = $"<h3>Info</h3>{target.GetContent()}";

            output.Content.SetHtmlContent(content);
        }
    }
}
