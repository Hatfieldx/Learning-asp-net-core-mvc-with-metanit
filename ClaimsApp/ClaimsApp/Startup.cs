using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using ClaimsApp.Models;

namespace ClaimsApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<IAuthorizationHandler, AgeHandler>();

            services.AddDbContext<ApplicationContext>(options =>            
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=claimsstoredb;Trusted_Connection=True"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt => opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Register"));

            services.AddAuthorization(opt=> {
                opt.AddPolicy("OnlyForLondon", policy => policy.RequireClaim(ClaimTypes.Locality, "Лондон", "London"));
                opt.AddPolicy("OnlyForMicrosoft", policy => policy.RequireClaim("company", "Microsoft"));
                opt.AddPolicy("AgeLimit", policy => policy.Requirements.Add(new AgeRequirement(18)));
            });
        }

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

            app.UseRouting();

            app.UseAuthentication();
            
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
