using System.Collections.Concurrent;

namespace LegacyOrderService.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<string, double> _productPrices = new()
        {
            ["Widget"] = 12.99,
            ["Gadget"] = 15.49,
            ["Doohickey"] = 8.75
        };

        private readonly ConcurrentDictionary<string, double> _simulatorRedisCache = new();

        public double GetPrice(string productName)
        {
            if (_simulatorRedisCache.TryGetValue(productName, out var cachedPrice))
            {
                return cachedPrice;
            }

            // Simulate an expensive lookup
            Thread.Sleep(500);

            if (_productPrices.TryGetValue(productName, out var price))
            {
                _simulatorRedisCache[productName] = price;
                return price;
            }

            throw new Exception("Product not found");
        }
    }
}