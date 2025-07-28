using System.Collections.Concurrent;
using LegacyOrderService.Data;

namespace LegacyOrderService.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ConcurrentDictionary<string, double> _simulatorRedisCache = new();

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void GetProducts()
    {
        Console.WriteLine("Available products:");
        var productNames = _productRepository.GetProducts();
        foreach (var productName in productNames) Console.WriteLine("- " + productName);
    }

    public double GetPrice(string productName)
    {
        if (_simulatorRedisCache.TryGetValue(productName, out var cachedPrice)) return cachedPrice;

        var price = _productRepository.GetPrice(productName);
        _simulatorRedisCache[productName] = price;

        return price;
    }

    public string InputProductName()
    {
        while (true)
        {
            Console.WriteLine("Enter product name:");
            var productName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(productName)) return productName;
            Console.WriteLine("Product name cannot be null. Please try again.");
        }
    }

    public int InputQuantity()
    {
        while (true)
        {
            Console.WriteLine("Enter quantity:");
            var quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity > 0) return quantity;
            Console.WriteLine("Quantity must be greater than zero. Please try again.");
        }
    }
}