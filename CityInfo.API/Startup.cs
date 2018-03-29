using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using NLog.Extensions.Logging;
using CityInfo.API.Services;
using Microsoft.Extensions.Configuration;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API
{
    public class Startup
    {
        // So we can use appsettings and environments
        public static IConfiguration Configuration { get; private set; }
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
                    // Without options, returns camcelCase JSON, or you can return case used in class
                    //.AddJsonOptions(o => {
                    //    if (o.SerializerSettings.ContractResolver != null)
                    //    {
                    //        var castedResolver = o.SerializerSettings.ContractResolver
                    //            as DefaultContractResolver;
                    //        castedResolver.NamingStrategy = null;
                    //    }
                    //});

            var connStr = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CityInfoContext>(options => 
                options.UseSqlServer(connStr));

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();

            // More flexible but maybe use environment variable or appsettings? https://bit.ly/2G9B33j
            #if DEBUG
                services.AddTransient<IMailService, LocalMailService>();
            #else
                services.AddTransient<IMailService, CloudMailService>();
            #endif
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug(LogLevel.Information); //LogLevel.Information is default, could leave out
            loggerFactory.AddNLog(); //short way

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            //Automapper init
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Getters
                cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<Entities.City, Models.CityDto>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
                // Setters
                cfg.CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
                cfg.CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();

                cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
            });

            app.UseMvc();
        }
    }
}
