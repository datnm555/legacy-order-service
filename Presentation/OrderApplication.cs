using LegacyOrderService.Services;

namespace LegacyOrderService.Presentation;

public class OrderApplication
{
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    
    public OrderApplication(ICustomerService customerService, IProductService productService, IOrderService orderService)
    {
        _customerService = customerService;
        _productService = productService;
        _orderService = orderService;
    }
    
    public void RunOrderProcess()
    {
        Console.WriteLine("Welcome to Order Processor!");

        var customerName = _customerService.InputCustomerName();

        _productService.GetProducts();

        var productName = _productService.InputProductName();

        var price = _productService.GetPrice(productName);
        var quantity = _productService.InputQuantity();

        _orderService.AddOrder(customerName, productName, quantity, price);

        Console.WriteLine("Done.");
    }
}