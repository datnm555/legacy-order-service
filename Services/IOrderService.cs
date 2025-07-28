using LegacyOrderService.Dtos;

namespace LegacyOrderService.Services;

public interface IOrderService
{
    void Add(OrderRequestDto orderRequestDto);
}