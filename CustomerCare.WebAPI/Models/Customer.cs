namespace CustomerCare.WebAPI.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime Date { get; set; }
    public short QueueNumber { get; set; }
}