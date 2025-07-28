using System.ComponentModel.DataAnnotations;

namespace LegacyOrderService.Dtos;

public class OrderRequestDto
{
    [Required]
    public string CustomerName;

    [Required]
    public string ProductName;

    public int Quantity;
    public double Price;

    public double TotalPrice => Math.Round(Quantity * Price, 2);
}