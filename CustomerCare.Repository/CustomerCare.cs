using System.Collections;

namespace CustomerCare.Repository;

public class CustomerCare 
{
    public short CalculateFasterQueue(IEnumerable<Customer> emptyQueue)
    {
        return 1;
    }

    public Customer RegisterClient(int id, string name)
    {
        return new Customer(id, name, 1);
    }
}