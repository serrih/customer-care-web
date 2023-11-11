using System.Collections;

namespace CustomerCare.Repository;

public class CustomerCare 
{
    public IEnumerable GetQueues()
    {
        return new List<Customer>();
    }

    public Customer RegisterClient(int id, string name)
    {
        return new Customer(id, name);
    }
}