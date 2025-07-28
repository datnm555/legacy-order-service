namespace LegacyOrderService.Services;

public interface IProductService
{
    void GetProducts();

    double GetPrice(string productName);

    string InputProductName();
    int InputQuantity();
}