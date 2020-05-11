using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConfigEdu.services;
using ConfigEdu.middlewares;
using ConfigEdu.ConfigurationProvider;
using Microsoft.Extensions.Logging;

namespace ConfigEdu
{
    public class Startup
    {
       IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddSingleton<IConfiguration>(Configuration);

            services.Configure<Order>(Configuration);

            services.AddTransient<ITimer, Timer>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           var loggerfactory = LoggerFactory.Create(builder => builder.ClearProviders());

            ILogger logger = loggerfactory.AddFileProvider("configs/Log.txt")
                            .CreateLogger<Startup>();

            logger.LogInformation("Error info");
            
            app.UseTimerResponser();
        }

        public Startup(IConfiguration defaultconfiguration)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                                                .AddJsonFile("configs/jsoncfg.json", false, true)
                                                .AddXmlFile("configs/XMLCfg.xml", false, true)
                                                .AddIniFile("configs/inicfg.ini", false, true)
                                                .AddTextFile("configs/TextCfg.txt")
                                                .AddConfiguration(defaultconfiguration);

            Configuration = builder.Build();                                       
        }
    }
}
