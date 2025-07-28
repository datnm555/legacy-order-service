namespace LegacyOrderService.ConnectionFactory;

public class DbHelper
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbHelper(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public void ExecuteNonQuery(string commandText)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = commandText;
        command.ExecuteNonQuery();
    }

    public void ExecuteNonQuery(string commandText, params object[] parameters)
    {
        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = commandText;

        foreach (var parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }

        command.ExecuteNonQuery();
    }
}