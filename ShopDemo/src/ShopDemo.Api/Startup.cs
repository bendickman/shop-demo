using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using System;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using ShopDemo.Shared.Data;

namespace ShopDemo.Api
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

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop Demo API", Version = "v1.0" });
            });

            services.AddAutoMapper(typeof(Core.Features.Category.GetCategoriesList.GetCategoriesListHandler).Assembly);

            //ensure Mediatr picks up the handlers in separate assemblies, use any class in the given assembly
            services.AddMediatR(typeof(Core.Features.Category.GetCategoriesList.GetCategoriesListHandler).Assembly);

            services.AddSingleton<ApplicationSettings>();

            services.AddScoped(ConfigureDbConnection);

            services.AddScoped<IDatabaseQueryProvider, DapperDatabaseQueryProvider>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop Demo API v1.0"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IDbConnection ConfigureDbConnection(IServiceProvider serviceProvider)
        {
            var applicationSettings = serviceProvider.GetRequiredService<ApplicationSettings>();

            var sqlConnection = new SqlConnection(applicationSettings.ConnectionString);

            return sqlConnection;
        }
    }
}
