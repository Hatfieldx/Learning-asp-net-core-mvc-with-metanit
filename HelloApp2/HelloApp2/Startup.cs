using HelloApp2.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HelloApp2.middlewares;
using Microsoft.Extensions.Configuration;


namespace HelloApp2
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(x=>Configuration);
            
            services.AddScoped<ITimer, TimerService>();            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITimer timer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseTimeExtensions();

            app.Run(x=>x.Response.WriteAsync(timer.GetConfigs("name", "age", "city", "color")));

            //app.Run(async x => await x.Response.WriteAsync($" name = {Configuration["name"]} city = {Configuration["city"]} color = {Configuration["color"]}"));

            
        }

        public Startup(IConfiguration configuration)        
        {   
            Configuration = new ConfigurationBuilder()
                                .AddJsonFile("conf.json", true, reloadOnChange:true)
                                .AddCommandLine(new string[] {"name=bob", "age=43"})
                                .AddConfiguration(configuration)                                
                                .Build();

            //Configuration = configuration;       
        }
    }
}
