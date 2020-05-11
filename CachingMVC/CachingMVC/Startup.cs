using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CachingMVC.Models;
using CachingMVC.Services;
using Microsoft.AspNetCore.Http;

namespace CachingMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=cacheappdb;Trusted_Connection=True;";

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddTransient<UserService>();

            services.AddMemoryCache();

            services.AddControllersWithViews();

            services.AddResponseCompression(opt => opt.EnableForHttps = true);
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseResponseCompression();

            app.Run(async context =>
            {
                // отправляемый текст
                string loremIpsum = "Lorem Ipsum is simply dummy text ... including versions of Lorem Ipsum.";
                // установка mime-типа отправляемых данных
                context.Response.ContentType = "text/plain";
                // отправка ответа
                await context.Response.WriteAsync(loremIpsum);
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
