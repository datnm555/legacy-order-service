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
            Price = orderRequestDto.Price,
        };
        
        _orderRepository.Save(order);
    }
}