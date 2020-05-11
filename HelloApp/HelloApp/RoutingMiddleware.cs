using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HelloApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationBuilder _builder;

        public RoutingMiddleware(RequestDelegate next, IApplicationBuilder builder)
        {
            _next = next;
            _builder = builder;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string path = httpContext.Request.Path.Value.ToLower().Replace("/", "");

            if (path == "" || path == "index")
              _builder.UseMiddleware<HomePage>();
            else if (path == "about")
              _builder.UseMiddleware<AboutPage>();
            else             
                httpContext.Response.StatusCode = 404;

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingMiddleware>();
        }
    }
}
