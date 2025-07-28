namespace LegacyOrderService.Services;

public interface IProductService
{
    IList<string> GetProducts();
    
    double GetPrice(string productName);
}