using System.ComponentModel.DataAnnotations;

namespace LegacyOrderService.Dtos;

public class OrderRequestDto
{
    [Required]
    public string CustomerName;

    public double Price;

    [Required]
    public string ProductName;

    public int Quantity;

    public double TotalPrice => Math.Round(Quantity * Price, 2);
}