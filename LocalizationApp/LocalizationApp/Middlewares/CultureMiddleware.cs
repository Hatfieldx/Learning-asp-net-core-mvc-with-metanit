using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LocalizationApp.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string cultureName = httpContext.Request.Query["lang"];

            if (!string.IsNullOrEmpty(cultureName))
                try
                {
                    CultureInfo.CurrentCulture = new CultureInfo(cultureName);
                    CultureInfo.CurrentUICulture = new CultureInfo(cultureName);
                }
                catch (CultureNotFoundException)
                {

                }

            return _next(httpContext);
        }
    }

    public static class CultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseCultureMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
