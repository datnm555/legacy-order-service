using System.ComponentModel.DataAnnotations;

namespace LegacyOrderService.Models
{
    public class Order
    {
        [Required]
        public string CustomerName;

        [Required]
        public string ProductName;

        public int Quantity;
        public double Price;
    }
}