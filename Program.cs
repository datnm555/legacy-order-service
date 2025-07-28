using LegacyOrderService.Extensions;
using LegacyOrderService.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyOrderService;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Order Service...");

        var serviceProvider = IoCBase.Startup();
        var app = serviceProvider.GetRequiredService<OrderApplication>();
        app.RunOrderProcess();

        Console.WriteLine("Terminating Order Service...");
    }
}