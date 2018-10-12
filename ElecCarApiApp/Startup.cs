using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIClass;
using ElecCarApiApp.Helper;
using ElecCarApiApp.Models;
using ElecCarApiApp.Services;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;

namespace ElecCarApiApp
{
    public class Startup
    {
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Car>("Cars");
            builder.EntitySet<Manufacturer>("Manufacturers");
            return builder.GetEdmModel();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddOData();
            services.AddMvc();

            var connection = @"Server=WIN-ZR9DI6E9BS\SQLEXPRESS;Database=ElectricalCars;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ElecCarContext>
                (options => options.UseSqlServer(connection));

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IMyDependency, MyDependency>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc(b =>
            { 
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
            });

        }

      
    }
}
