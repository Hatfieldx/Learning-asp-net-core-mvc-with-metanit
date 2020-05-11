using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class HomePage
    {
        RequestDelegate _next;

        public async Task UseHomePage(HttpContext context)
        {
            await context.Response.WriteAsync("<h1>HOME PAGE<h1>");
        }

        public HomePage(RequestDelegate next)
        {
            this._next = next;
        }
    }

    public class AboutPage
    {
        RequestDelegate _next;

        public async Task UseHomePage(HttpContext context)
        {
            await context.Response.WriteAsync("<h1>ABOUT PAGE<h1>");
        }

        public AboutPage(RequestDelegate next)
        {
            this._next = next;
        }
    }
}
