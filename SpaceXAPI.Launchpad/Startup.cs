using System;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceXAPI.Core.Models;
using SpaceXAPI.Core.Services;
using SpaceXAPI.Data;
using SpaceXAPI.Infrastructure;
using SpaceXAPI.Interfaces;

namespace SpaceXAPI.Launchpad
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOData();

            var spaceXApiData = Configuration.GetSection("SpaceXAPIData").Get<SpaceXAPIData>();

            services.Configure<LoggerData>(Configuration.GetSection("Logging"));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<ILaunchPadService, LaunchpadService>();
            services.AddScoped<ISpaceXRepository, SpaceXAPIRepository>();
            //services.AddScoped<ISpaceXAPIService, SpaceXAPIService>(); // no longer need this, as SpaceXAPIService is registered as a "typed client" https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0#typed-clients
            services.AddSingleton<ILogEvents, RollBarLogger>();

            // Add an HttpClient to the Core HttpClientFactory with the configured URL
            services.AddHttpClient<ISpaceXAPIService, SpaceXAPIService>(c => { c.BaseAddress = new Uri(spaceXApiData.URL); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.EnableDependencyInjection();
                routes.Filter().MaxTop(null);
            });
        }
    }
}
