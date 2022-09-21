using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Drawing.Diagrams;

[assembly:ApiConventionType(typeof(DefaultApiConventions))]
namespace ResTask
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
            services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyDefaultConnectionString"));
            });
            services.AddRazorPages();

            //  Register the MVC middleware
            // -- Needed for  Swagger Documentation middleware service
            services
                .AddMvc();
            //Reg the swagger documentation Middleware service
            services
                .AddSwaggerGen( config => 
                {
                    config.SwaggerDoc("v1",new OpenApiInfo
                { 
                    Version = "v1",
                    Title =" My RMS",
                    Description = "Restaurant Management System - Api Version 1.0"
                });
        });

        //services.AddDbContext<RestaurantManagementContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("RestaurantManagementContext")));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        


            // Add swagger middleware
            app.UseSwagger();

            app.UseSwaggerUI(congi =>
            {
                congi.SwaggerEndpoint("/swagger/v1/swagger.json", "RMS Web API v1.0");
            });



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                // Register the ASP.NET Routes for Areas
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller}/{action=Index}/{id?}");

                // Register the ASP.NET Routes for the MVC Controllers
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
