using System.ComponentModel.DataAnnotations;

namespace LegacyOrderService.Models;

public class Order
{
    [Required]
    public string CustomerName;

    public double Price;

    [Required]
    public string ProductName;

    public int Quantity;
}