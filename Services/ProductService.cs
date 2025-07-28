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


    public IList<string> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public double GetPrice(string productName)
    {
        if (_simulatorRedisCache.TryGetValue(productName, out var cachedPrice))
        {
            return cachedPrice;
        }

        var price = _productRepository.GetPrice(productName);
        _simulatorRedisCache[productName] = price;

        return price;
    }
}