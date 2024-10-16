using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Shared.Extensions
{
    /*
   using System.Data.SqlClient;
using System.Data.Common;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "Your connection string here";
        DbProviderFactory factory = SqlClientFactory.Instance; // For SQL Server
        var helper = new AdoNetHelper(connectionString, factory);

        // Example 1: Single result set
        var users = await helper.ExecuteReaderAsync<List<User>>(
            "SELECT Id, Name, Email FROM Users",
            CommandType.Text,
            reader =>
            {
                var users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
                return users;
            }
        );

        // Example 2: Multiple result sets
        var (users, orders) = await helper.ExecuteReaderMultipleResultsAsync<List<User>, List<Order>>(
            "SELECT Id, Name, Email FROM Users; SELECT Id, UserId, Total FROM Orders",
            CommandType.Text,
            reader =>
            {
                var users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
                return users;
            },
            reader =>
            {
                var orders = new List<Order>();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        Total = reader.GetDecimal(2)
                    });
                }
                return orders;
            }
        );

        // Example 3: ExecuteScalar
        var userCount = await helper.ExecuteScalarAsync(
            "SELECT COUNT(*) FROM Users",
            CommandType.Text
        );

        // Example 4: ExecuteNonQuery
        int affectedRows = await helper.ExecuteNonQueryAsync(
            "UPDATE Users SET Name = @Name WHERE Id = @Id",
            CommandType.Text,
            new SqlParameter("@Name", "John Doe"),
            new SqlParameter("@Id", 1)
        );
    }
}

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Total { get; set; }
}
     */
    public class AdoNetHelper
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _dbProviderFactory;

        public AdoNetHelper(string connectionString, DbProviderFactory dbProviderFactory)
        {
            _connectionString = connectionString;
            _dbProviderFactory = dbProviderFactory;
        }

        private async Task<(DbConnection, DbCommand)> CreateCommandAsync(string commandText, CommandType commandType, DbParameter[] parameters)
        {
            var connection = _dbProviderFactory.CreateConnection();
            connection.ConnectionString = _connectionString;

            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            return (connection, command);
        }

        public async Task<T> ExecuteReaderAsync<T>(string commandText, CommandType commandType,
            Func<DbDataReader, T> readerFunc, params DbParameter[] parameters)
        {
            var (connection, command) = await CreateCommandAsync(commandText, commandType, parameters);

            using (connection)
            using (command)
            {
                using var reader = await command.ExecuteReaderAsync();
                return readerFunc(reader);
            }
        }

        public async Task<(T1, T2)> ExecuteReaderMultipleResultsAsync<T1, T2>(string commandText, CommandType commandType,
            Func<DbDataReader, T1> readerFunc1, Func<DbDataReader, T2> readerFunc2, params DbParameter[] parameters)
        {
            var (connection, command) = await CreateCommandAsync(commandText, commandType, parameters);

            using (connection)
            using (command)
            {
                using var reader = await command.ExecuteReaderAsync();

                var result1 = readerFunc1(reader);
                reader.NextResult();
                var result2 = readerFunc2(reader);

                return (result1, result2);
            }
        }

        public async Task<object> ExecuteScalarAsync(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            var (connection, command) = await CreateCommandAsync(commandText, commandType, parameters);

            using (connection)
            using (command)
            {
                return await command.ExecuteScalarAsync();
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            var (connection, command) = await CreateCommandAsync(commandText, commandType, parameters);

            using (connection)
            using (command)
            {
                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}
