using LegacyOrderService.Data;
using LegacyOrderService.Dtos;
using LegacyOrderService.Models;

namespace LegacyOrderService.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void Add(OrderRequestDto orderRequestDto)
    {
        var order = new Order
        {
            CustomerName = orderRequestDto.CustomerName,
            ProductName = orderRequestDto.ProductName,
            Quantity = orderRequestDto.Quantity,
            Price = orderRequestDto.Price
        };

        _orderRepository.Save(order);
    }

    public void AddOrder(string customerName, string productName, int quantity, double price)
    {
        Console.WriteLine("Processing order...");

        var orderRequest = new OrderRequestDto
        {
            CustomerName = customerName,
            ProductName = productName,
            Quantity = quantity,
            Price = price
        };

        Console.WriteLine("Order complete!");
        Console.WriteLine("Customer: " + orderRequest.CustomerName);
        Console.WriteLine("Product: " + orderRequest.ProductName);
        Console.WriteLine("Quantity: " + orderRequest.Quantity);
        Console.WriteLine("Total: $" + orderRequest.TotalPrice);

        Console.WriteLine("Saving order to database...");
        Add(orderRequest);
    }
}