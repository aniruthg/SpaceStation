using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SpaceStation.DataAccess.Interfaces;
using SpaceStation.DataAccess.Sql_Mapping_Models;
using SpaceStation.Repository.Interfaces;
using SpaceStation.Repository.Repository;

namespace SpaceStation.WebApi
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
            services.AddControllers();
            InitRepo(services);
            services.AddTransient<IShuttleSpecifications, ShuttleSpecifications>();
            services.AddTransient<ILabSpecification, LabSpecification>();
        }


        private void InitRepo(IServiceCollection services)
        {
            var connectionString = "";
            services.AddDbContext<SpaceContext>(options => options.UseInMemoryDatabase("SpaceStation"));
            services.AddScoped<IDockRepository, DockRepository>();
            services.AddScoped<IDimensionRepository, DimensionRepository>();
            services.AddScoped<ILabRepository, LabRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
