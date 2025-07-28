using LegacyOrderService.Data;
using LegacyOrderService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyOrderService.Extensions;

public static class IoCBase
{
    public static IServiceCollection AddLegacyOrderRepository(this IServiceCollection services)
    {
        // Register the product repository as a singleton
        services.AddSingleton<IProductRepository, ProductRepository>();

        // Register the order repository as a transient service
        services.AddTransient<IOrderRepository, OrderRepository>();

        return services;
    }

    public static IServiceCollection AddLegacyOrderService(this IServiceCollection services)
    {
        // Register the product repository as a singleton
        services.AddScoped<IProductService, ProductService>();

        // Register the order repository as a transient service
        services.AddScoped<IOrderService, OrderService>();

        return services;
    }
    
    public static void InjectLegacyOrderServices(this IServiceCollection services)
    {
        services.AddLegacyOrderRepository();
        services.AddLegacyOrderService();
    }
}