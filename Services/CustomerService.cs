namespace LegacyOrderService.Services;

public class CustomerService : ICustomerService
{
    public string InputCustomerName()
    {
        while (true)
        {
            Console.WriteLine("Enter customer name:");
            var customerName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(customerName)) return customerName;
            Console.WriteLine("Customer name cannot be empty. Please try again.");
        }
    }
}