using Application;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            #region Service Layers
            services.AddApplication();
            services.AddPersistence(Configuration);
            #endregion

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddRazorPages();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "HabitAllowance.WebApi"
                });
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });

            #region Api Versioning
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                // Configure the HTTP request pipeline.
                if (env.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                    //app.UseSwaggerUI(c =>
                    //{
                    //    c.SwaggerEndpoint("swagger/v1/swagger.json", "HabitAllowance");
                    //});
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }
                app.UseHttpsRedirection();

                app.UseRouting();

                //app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllers();
                    endpoints.MapFallbackToFile("index.html");
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
