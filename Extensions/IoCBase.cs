using LegacyOrderService.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyOrderService.Extensions;

public static class IoCBase
{
    public static IServiceCollection AddLegacyOrderService(this IServiceCollection services)
    {
        // Register the product repository as a singleton
        services.AddSingleton<IProductRepository, ProductRepository>();

        // Register the order repository as a transient service
        services.AddTransient<IOrderRepository, OrderRepository>();

        return services;
    }
}