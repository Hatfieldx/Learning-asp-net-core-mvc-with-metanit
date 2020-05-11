using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloApp2.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloApp2.middlewares
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;
        ITimer _timer;
        
        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }

        public async Task InvokeAsync(HttpContext httpContext, ITimer timer)
        {
            string path = httpContext.Request.Path.Value.ToLower();
            _timer = timer;

            if (path == "/time")
            {
                httpContext.Response.ContentType = "text/html; charset=utf-8";               
               // ITimer timer = httpContext.RequestServices.GetService<ITimer>();

                await httpContext.Response.WriteAsync($"Now time is {_timer?.ToString()}");
            }
            else
                await _next(httpContext);
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeExtensions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
