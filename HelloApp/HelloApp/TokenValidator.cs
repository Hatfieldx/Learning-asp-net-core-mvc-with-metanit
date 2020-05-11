using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace HelloApp
{
    public class TokenValidator
    {
        RequestDelegate _next;
        string _message;

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("token") && context.Request.Query["token"] == "12345")
            {
                context.Items["message"] = _message;
                await _next?.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;                
            }
        }

        public TokenValidator(RequestDelegate next, string message)
        {
            this._next = next;
            this._message = message;          
        }    
    }

    static class TokenValidatorExt
    {
        public static IApplicationBuilder UseTokenValidator(this IApplicationBuilder app, string message)
        {
           return app.UseMiddleware<TokenValidator>(message);
        }
    }
}
