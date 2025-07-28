using LegacyOrderService.ConnectionFactory;
using LegacyOrderService.Models;
using Microsoft.Data.Sqlite;

namespace LegacyOrderService.Data;

public class OrderRepository : IOrderRepository
{
    private readonly DbHelper _dbHelper;

    public OrderRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Save(Order order)
    {
        var commandText = @"
                INSERT INTO Orders (CustomerName, ProductName, Quantity, Price)
                VALUES (@CustomerName, @ProductName, @Quantity, @Price)";
        _dbHelper.ExecuteNonQuery(commandText,
            new SqliteParameter("@CustomerName", order.CustomerName),
            new SqliteParameter("@ProductName", order.ProductName),
            new SqliteParameter("@Quantity", order.Quantity),
            new SqliteParameter("@Price", order.Price));
    }
}