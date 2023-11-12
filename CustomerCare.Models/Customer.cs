namespace CustomerCare.Models;

public class Customer
{
    public Customer(int id, string name, int queueNumber)
    {
        Id = id;
        Name = name;
        QueueNumber = queueNumber;
    }

    public int Id { get; }
    public string Name { get; }
    public int QueueNumber { get; }
}