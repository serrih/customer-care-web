using CustomerCare.Models;
using Microsoft.Data.Sqlite;

namespace CustomerCare.Repository;

public class CustomerCare 
{
    private const string connectionString = "Data Source=../../../../CustomerCare.Repository/CustomerCare.db";

    public static void RegisterClient(int id, string name, short queueNumber)
    {
        using var connection = new SqliteConnection(connectionString);
        
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Customers (Id, Name, Queue_number) VALUES (@id, @name, @queueNumber)";

        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@queueNumber", queueNumber);

        command.ExecuteNonQuery(); 
    }

    public static IEnumerable<Customer> GetCustomers()
    {
        var customers = new List<Customer>();
        using var connection = new SqliteConnection(connectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name, Queue_number FROM Customers";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var name = reader.GetString(1);
            var queueNumber = reader.GetInt16(2);

            customers.Add(new Customer(id, name, queueNumber));
        }

        return customers;
    }
}