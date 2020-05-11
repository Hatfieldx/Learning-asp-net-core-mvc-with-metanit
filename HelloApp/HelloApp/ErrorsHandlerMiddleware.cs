using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class ErrorsHandlerMiddleware
    {
        RequestDelegate _next;

        public async Task InvokeAsync(HttpContext contex)
        {
            await _next?.Invoke(contex);

            int statuscode = contex.Response.StatusCode;

            if (statuscode == 404)
              await  contex.Response.WriteAsync("page not found");
            else if (statuscode == 403)
              await  contex.Response.WriteAsync("access denied");
        }

        public ErrorsHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
    }
}
