using System.Data;

namespace LegacyOrderService.ConnectionFactory;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}