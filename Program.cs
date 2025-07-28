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
            var serviceProvider = Startup();

            Console.WriteLine("Welcome to Order Processor!");
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();

            // Simulating product retrieval
            var productService = serviceProvider.GetRequiredService<IProductService>();
            Console.WriteLine("Available products:");
            foreach (var productName in productService.GetProducts())
            {
                Console.WriteLine("- " + productName);
            }
            
            Console.WriteLine("Enter product name:");
            string product = Console.ReadLine();
            double price = productService.GetPrice(product);


            Console.WriteLine("Enter quantity:");
            int qty = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Processing order...");

            OrderRequestDto orderRequest = new OrderRequestDto();
            orderRequest.CustomerName = name;
            orderRequest.ProductName = product;
            orderRequest.Quantity = qty;
            orderRequest.Price = 10.0;

            double total = orderRequest.Quantity * orderRequest.Price;

            Console.WriteLine("Order complete!");
            Console.WriteLine("Customer: " + orderRequest.CustomerName);
            Console.WriteLine("Product: " + orderRequest.ProductName);
            Console.WriteLine("Quantity: " + orderRequest.Quantity);
            Console.WriteLine("Total: $" + price);

            Console.WriteLine("Saving order to database...");
            var orderService = serviceProvider.GetRequiredService<IOrderService>();
            orderService.Add(orderRequest);
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