namespace LegacyOrderService.Data;

public interface IProductRepository
{
    double GetPrice(string productName);
     IList<string> GetProducts();
}