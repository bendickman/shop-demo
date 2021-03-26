using System;
using Microsoft.Extensions.DependencyInjection;
using ShopDemo.Console.Commands;
using ShopDemo.Shared;

namespace ShopDemo.Console
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();

            var scope = _serviceProvider.CreateScope();

            var program = scope.ServiceProvider.GetRequiredService<IProgramRunnable>();
            
            program.Run().Wait();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IProgramRunnable, ShopDemoProgram>();
            services.AddScoped<ICommandProvider, ShopDemoCommandProvider>();

            services.AddScoped<ICommand, CategoriesCommand>();
            services.AddScoped<ICommand, FeaturedProductsCommand>();
            services.AddScoped<ICommand, ProductsByCategoryCommand>();
            services.AddScoped<ICommand, QuitCommand>();
            services.AddScoped<ICommand, NotFoundCommand>();

            services.AddHttpClient(Constants.Data.ShopDemoClientName, x =>
            {
                x.BaseAddress = new Uri(Environment.GetEnvironmentVariable(Constants.Data.EnvironmentVariableApiBaseUrl));
            });

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
