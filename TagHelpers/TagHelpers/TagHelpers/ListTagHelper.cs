using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Models;

namespace TagHelpers.TagHelpers
{
    public class ListTagHelper : TagHelper
    {
        public IEnumerable<Product> ProductList { get; set; }
        public Product SomeProduct { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";

            output.TagMode = TagMode.StartTagAndEndTag;

            string content = $"<tr><th>{nameof(Product.Id)}</th><th>{nameof(Product.Name)}</th><th>{nameof(Product.Price)}</th><tr>";

            foreach (var item in ProductList)
            {
                content = $"{content}<tr>" +
                    $"              <th>{item.Id}</th>" +
                    $"              <th>{item.Name}</th>" +
                    $"              <th>{item.Price}</th>" +
                    $"<tr>";
            }

            string aftercontent = $"<p>Some product: {SomeProduct.Id} - {SomeProduct.Name} - {SomeProduct.Price}</p>";

            output.PostElement.SetHtmlContent(aftercontent);

            output.Content.SetHtmlContent(content);
        }
    }
}
