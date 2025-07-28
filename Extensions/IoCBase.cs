using LegacyOrderService.ConnectionFactory;
using LegacyOrderService.Data;
using LegacyOrderService.Presentation;
using LegacyOrderService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyOrderService.Extensions;

public static class IoCBase
{
    public static IServiceCollection AddLegacyOrderDbService(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, SqlLiteConnectionFactory>();
        services.AddTransient<DbHelper>();

        return services;
    }


    public static IServiceCollection AddLegacyOrderRepositoriesService(this IServiceCollection services)
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
        services.AddLegacyOrderDbService();
        services.AddLegacyOrderRepositoriesService();
        services.AddLegacyOrderService();
        services.AddTransient<OrderApplication>();
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}