using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersEdu.Utils
{
    public class HtmlResult : IActionResult
    {
        string _htmpCode;
        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += _htmpCode;
            fullHtmlCode += "</body></html>";

            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }

        public HtmlResult(string html)
        {
            _htmpCode = html;
        }
    }
}
