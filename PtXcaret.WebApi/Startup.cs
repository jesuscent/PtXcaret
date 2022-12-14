using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PtXcaret.Business.Businnes;
using PtXcaret.Business.IBussinnes;
using PtXcaret.Services.Businnes;
using PtXcaret.Services.IBussinnes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PtXcaret.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        internal static ILoggerFactory _log { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "PtXcaret.WebApi",
                    Version = "v1",
                    Description="Prueba Técnica Xcaret",
                    Contact = new OpenApiContact{
                       Name= "Jesús Centeno",
                       Email="jesus.jgcc39@gmail.com"
                    }
                });    
            });

            services.AddTransient<IServiceEntries, ServiceEntries>();
            services.AddTransient<IBusEntries, BusEntries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            _log = log;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PtXcaret.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
