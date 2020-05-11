using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HelloApp.Services
{
    
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;
        private int i = 0; // счетчик запросов

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter counter, CounterService counterService)
        {
            i++;
            httpContext.Response.ContentType = "text/html; charset=utf-8";
            await httpContext.Response.WriteAsync($"Запрос {i}; Counter: {counter.Value}; Service: {counterService.Counter.Value}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CounterMiddlewareExtensions
    {
        public static IApplicationBuilder UseCounterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CounterMiddleware>();
        }
    }
}
