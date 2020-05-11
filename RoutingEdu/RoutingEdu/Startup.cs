using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingEdu
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //RouteHandler routehandler = new RouteHandler(Handler);

            RouteBuilder builder = new RouteBuilder(app);


            //builder.MapRoute("{w=home}/{q=index}/{id?}", Handler);

//            builder.MapRoute();
            
            builder.MapGet("{w}/{q}/{id?}",
                                async (request, response, routeData) =>
                                    {
                                        await response.WriteAsync("Test ROUTE Data");
                                    });
            //builder.MapRoute("custom1", "{w}");
            //builder.MapRoute("custom2", "{w}/{q}/{t}");

            //RouteBuilder builder = new RouteBuilder(app);
            //builder.MapGet("/", async x=> await x.Response.WriteAsync("Route builder"));
            app.UseRouter(builder.Build());


            //app.UseRouting(builder.MapGet("/", Handler).Build());

            app.Run(async context => await context.Response.WriteAsync("Hello World!"));

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }

        private async Task Handler(HttpContext context)
        {
            await context.Response.WriteAsync("Hello World! from custom route");
        }
    }
}
