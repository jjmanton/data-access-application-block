# DATA ACCESS APPLICATION BLOCK (DAAB)

The Data Access Application Block abstracts the actual database you are using, and exposes a collection of methods that
make it easy to access that database and to perform common tasks. The block is designed to simplify the task of calling
stored procedures, but it also provides full support for the use of parameterized SQL statements.

In other words, the Data Access Application Block provides access to the most often used features of ADO.NET in
simple-to-use classes and provides a corresponding boost to developer productivity.

For example, suppose you wanted to query your database using the `SalesByCategory` procedure, and retrieve the results
as a DataTable, keeping your code database-agnostic. In standard ADO.NET, the following code was required:

```csharp
ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["MyConnection"];
String providerName = connectionString.ProviderName;
DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
using (DbConnection connection = factory.CreateConnection())
{
    connection.ConnectionString = connectionString.ConnectionString;
    DbCommand command = connection.CreateCommand();
    command.CommandText = "SalesByCategory";
    command.CommandType = CommandType.StoredProcedure;
    DbParameter parameter = command.CreateParameter();
    parameter.Value = "Beverages";
    parameter.DbType = DbType.String;
    parameter.Direction = ParameterDirection.Input;
    parameter.ParameterName = "@CategoryName";
    command.Parameters.Add(parameter);
    DbDataAdapter adapter = factory.CreateDataAdapter();
    adapter.SelectCommand = command;
    DataTable dt = new DataTable();
    connection.Open();
    adapter.Fill(dt);
}
```
Using the Data Access Application Block, this code becomes:
```csharp
DatabaseProviderFactory factory = new DatabaseProviderFactory();
Database database = factory.Create("MyConnection");
DbCommand command = database.GetStoredProcCommand("SalesByCategory", "Beverages");
DataSet ds = database.ExecuteDataSet(command);
DataTable dt = ds.Tables[0];
```

In addition to the more common approaches familiar to users of ADO.NET, the Data Access block also exposes techniques
for asynchronous data access for databases that support this feature using the Asynchronous Programming Model (TPL
coming in the near future), and provides the ability to return data as a sequence of objects suitable for client-side
querying using techniques such as Language Integrated Query (LINQ).

However, the block is not intended to be an Object/Relational Mapping (O/RM) solution. Although it uses mappings to
relate parameters and relational data with the properties of objects, but does not implement an O/RM modeling solution.
