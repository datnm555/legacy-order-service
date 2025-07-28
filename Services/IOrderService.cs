using LegacyOrderService.Dtos;

namespace LegacyOrderService.Services;

public interface IOrderService
{
    void Add(OrderRequestDto orderRequestDto);
    void AddOrder(string customerName, string productName, int quantity, double price);
}