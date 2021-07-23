using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CleanArchitectureTemplate.Api.HealthChecks;
using CleanArchitectureTemplate.Application;
using CleanArchitectureTemplate.Infrastructure;
using CleanArchitectureTemplate.Persistence;

namespace CleanArchitectureTemplate.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(_configuration);
            services.AddApplication();
            services.AddGrpcGreeterClient(_configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitectureTemplate.Api", Version = "v1" });
            });

            services.AddHealthCHecks(_configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitectureTemplate.Api v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting()
               .UseEndpoints(config =>
               {
                   config.MapHealthChecks("/healthz", new HealthCheckOptions
                   {
                       Predicate = _ => true,
                       ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                   });

                   
                   config.MapHealthChecksUI(setup =>
                   {
                       setup.UIPath = "/health-ui"; // this is ui path in your browser
                       setup.ApiPath = "/health-ui-api"; // the UI ( spa app )  use this path to get information from the store ( this is NOT the healthz path, is internal ui api )
                   });
                  

                   config.MapDefaultControllerRoute();
               });

            app.UseAuthentication();
        }
    }
}
