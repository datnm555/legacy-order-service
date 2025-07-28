using LegacyOrderService.Models;
using LegacyOrderService.Data;
using LegacyOrderService.Dtos;
using LegacyOrderService.Extensions;
using LegacyOrderService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyOrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Order Processor!");

            var serviceProvider = Startup();
            var customerService = serviceProvider.GetRequiredService<ICustomerService>();
            var productService = serviceProvider.GetRequiredService<IProductService>();
            var orderService = serviceProvider.GetRequiredService<IOrderService>();

            var customerName = customerService.InputCustomerName();

            productService.GetProducts();

            var productName = productService.InputProductName();

            var price = productService.GetPrice(productName);
            var quantity = productService.InputQuantity();

            orderService.AddOrder(customerName, productName, quantity, price);

            Console.WriteLine("Done.");
        }

        private static ServiceProvider Startup()
        {
            var services = new ServiceCollection();
            services.AddLegacyOrderRepository();
            services.AddLegacyOrderService();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}