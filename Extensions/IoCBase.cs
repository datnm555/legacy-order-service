using LegacyOrderService.Data;
using LegacyOrderService.Presentation;
using LegacyOrderService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyOrderService.Extensions;

public static class IoCBase
{
    public static IServiceCollection AddLegacyOrderRepository(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();

        services.AddTransient<IOrderRepository, OrderRepository>();

        return services;
    }

    public static IServiceCollection AddLegacyOrderService(this IServiceCollection services)
    {
        // Register the product repository as a singleton
        services.AddScoped<IProductService, ProductService>();

        // Register the order repository as a transient service
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
    
    public static ServiceProvider Startup()
    {
        var services = new ServiceCollection();
        services.AddLegacyOrderRepository();
        services.AddLegacyOrderService();
        services.AddTransient<OrderApplication>();
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}