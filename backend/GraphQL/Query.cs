using Npgsql; // https://www.npgsql.org/doc/api/Npgsql.NpgsqlDataReader.html

// Hot Chocolate reads all public methods on this class and exposes them as GraphQL query fields.
public class Query
{
/*
 * [Service] tells Hot Chocolate to resolve Database from ASP.NET Core's DI container.
 * Returns a list of all persons in the databases `people`-table.
 */
    public async Task<List<Person>> GetPeopleAsync([Service] Database db)
    {
        var people = new List<Person>();

        /*
         * Create and open a connection to PostgreSQL.
         * "await using" (similar to try/finally) ensures the connection is disposed (closed)
         * when done, even if an error occurs.
         */
        await using var conn = db.CreateConnection();
        await conn.OpenAsync();

        // Create an instance of NpgsqlCommand, which holds the SQL to run against the open connection.
        // Column order in the query determines the index numbers used in reader.GetX(N) below.
        await using var cmd = new NpgsqlCommand(
            "SELECT id, first_name, last_name, age, gender FROM people", conn);
        
        /*
         * ExecuteReaderAsync (similar to stream in Node.js) is invoked to return a reader
         * which safeguards against memory overload.
         */
        await using var reader = await cmd.ExecuteReaderAsync();

        // Read one row at a time. ReadAsync() returns false when there are no more rows.
        while (await reader.ReadAsync())
        {
            // Map each column to the corresponding Person property by index (0-based).
            // The index matches the column order in the SELECT statement above.
            people.Add(new Person
            {
                Id        = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName  = reader.GetString(2),
                Age       = reader.GetInt32(3),
                Gender    = reader.GetString(4)
            });
        }

        return people;
    }
}