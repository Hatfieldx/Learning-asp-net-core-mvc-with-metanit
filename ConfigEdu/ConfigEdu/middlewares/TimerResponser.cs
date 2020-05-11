using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ConfigEdu.middlewares
{
    public class TimerResponser
    {
        private readonly RequestDelegate _next;

        public TimerResponser(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ITimer timer, ILogger<Order> logger)
        {
            string currenttime = timer.GetCurrentTime();

            string cfg = timer.GetConfig("id", "age", "color", "name", "city", "person:company:companyname");

            string login = "";

            logger?.LogInformation($"Process info {httpContext.Request.QueryString}");

            if (httpContext.Request.Cookies.TryGetValue("login", out login))
            {
                await httpContext.Response.WriteAsync($"current time is {currenttime} \n config:\n{cfg} \n LOGIN = {login}");
            }
            else
            {
                httpContext.Response.Cookies.Append("login", "login1");
                await httpContext.Response.WriteAsync($"current time is {currenttime} \n config:\n{cfg} \n LOGIN = {login}");
            }

            //await httpContext.Response.WriteAsync($"current time is {currenttime} \n config:\n{cfg}");          
        }
    }

    public static class TimerResponserExtensions
    {
        public static IApplicationBuilder UseTimerResponser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimerResponser>();
        }
    }
}
