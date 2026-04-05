/*
 * Represents a single row from the `people`-table.
 *
 * Hot Chocolate reads its properties to generate the GraphQL type automatically.
 * The GraphQL field names are the C# property names, camel-cased:
 * ID -> id, FirstName -> firstName, etc. The SQL column (e.g. first_name, last_name) only exist in the raw
 * SQL string in Query.cs (and have no effect on the GraphQL schema).
 */
public class Person
{
    public int Id { get; set; }
    // = string.Empty sets the default value for string properties.
    // Required because C# non-nullable properties must be initialized.
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Gender { get; set; } = string.Empty;
}