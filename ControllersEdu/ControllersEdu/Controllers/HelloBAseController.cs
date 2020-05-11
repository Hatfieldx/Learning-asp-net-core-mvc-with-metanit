using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllersEdu.Controllers
{
    public abstract class HelloBAseController : Controller
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            if (headers.ContainsKey("User-Agent"))
            {
                var userAgent = headers["User-Agent"].FirstOrDefault();

                if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
                {
                    context.Result = Content("Internet Explorer не поддерживается");
                }
            }            
            
            base.OnActionExecuting(context);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
