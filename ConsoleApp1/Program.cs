using ConsoleApp1.Dal;
using ConsoleApp1.Entities;
using ConsoleApp1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDataAccess, DataAccess>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();


            var productService = serviceProvider.GetService<IProductService>();
            
            productService.SaveProduct(new Product
            {
                Id = 2,
                Name = "Computer screen"
            });
        }
    }
}
