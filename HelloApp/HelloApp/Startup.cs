using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HelloApp.Services;

namespace HelloApp
{
    public class Startup
    {
        IWebHostEnvironment env = null;
        IServiceCollection _services;


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            services.AddSingleton<ICounter, RandomCounter>();
            services.AddSingleton<CounterService>();
            services.AddMvc(opt=>opt.EnableEndpointRouting = false);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.Map("/error", app => app.Run(async x => await x.Response.WriteAsync("DIVIZION_BY_ZERO!!!")));

            app.UseRouting();

            //app.UseCounterMiddleware();

            app.UseEndpoints(
                endpoint => endpoint.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
                ); 
        }

        private void Archive()
        {

            //app.UseTokenValidator("Tratatatata");

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        string message = (context.Items.ContainsKey("message")) ? (string)context.Items["message"] : "";

            //        await context.Response.WriteAsync($"GOOD JOB!! ------>>>>>> {message}");
            //    });
            //});




            //app.Map("/home", home =>
            //{
            //    home.Map("/index", Index);
            //    home.Map("/about", About);
            //} );

            //app.Map("/index", Index);
            //app.Map("/about", About);



            //app.MapWhen(context => context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5", 
            //            context => app.Run(async contex => await contex.Response.WriteAsync("id = 5")));



            // app.Run(async contex => await contex.Response.WriteAsync("<h1>PAGE NOT FOUND</h1>"));


            //int x = 0;

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync($"-->{env.ApplicationName} \n -->{env.EnvironmentName}\n Hello World! {++x}");
            //    });
            //});

            var sb = new StringBuilder();
            sb.Append("<head><meta charset = \"utf-8\"></head><html><body>");
            sb.Append("<h1>Все сервисы</h1>");
            sb.Append("<table>");
            sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
            foreach (var svc in _services)
            {
                sb.Append("<tr>");
                sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                sb.Append($"<td>{svc.Lifetime}</td>");
                sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("</html></body>");
        }

        private static void About(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("<h1>About</h1>"));
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("<h1>Index</h1>"));
        }

        public Startup(IWebHostEnvironment env, IConfiguration conf)
        {
            this.env = env;
        }



    }
}
