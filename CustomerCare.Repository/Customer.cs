namespace CustomerCare.Repository;

public class Customer
{
    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
}