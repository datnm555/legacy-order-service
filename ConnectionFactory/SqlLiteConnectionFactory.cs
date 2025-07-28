using System.Data;
using Microsoft.Data.Sqlite;

namespace LegacyOrderService.ConnectionFactory;

public class SqlLiteConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlLiteConnectionFactory()
    {
        _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "orders.db")}";
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}