using Npgsql;
/*
 * This class is registered in ASP.NET Core's DI container in Program.cs as a Singleton.
 * It is invoked via [Service] Database <var_name>
 */
public class Database
{
    private readonly string _connectionString;

    public Database(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("Postgres")!; // `!` ensures compiler that the value wont be null
    }

    // Method for creating a Npgsql connection object with the stored connection. This does NOT open the connection.
    public NpgsqlConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}