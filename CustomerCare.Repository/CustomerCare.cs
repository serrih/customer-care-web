namespace CustomerCare.Repository;

public class CustomerCare 
{
    public Customer RegisterClient(int id, string name)
    {
        return new Customer(id, name);
    }
}