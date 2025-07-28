namespace LegacyOrderService.Services;

public class CustomerService : ICustomerService
{
    public string InputCustomerName()
    {
        Console.WriteLine("Enter customer name:");
        var customerName = Console.ReadLine();
        return customerName;
    }
}