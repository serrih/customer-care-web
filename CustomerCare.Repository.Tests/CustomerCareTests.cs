namespace CustomerCare.Repository.Tests;

public class CustomerCareTests 
{

    private static IEnumerable<Customer> emptyQueue = new List<Customer>();
    private static IEnumerable<Customer> queueOneCustomer = new List<Customer>() { new Customer(1, "Peter", 1) };
    private static IEnumerable<Customer> queueTwoCustomers = new List<Customer>() { new Customer(1, "Peter", 1), new Customer(2, "John", 1) };

    [Fact]
    public void RegisterClient() 
    {
        // Arrange
        var customerCare = new CustomerCare();
        var expectedCustomer = new Customer(1, "Pepe", 1);

        // Act
        var customer = customerCare.RegisterClient(1, "Pepe");

        // Assert
        Assert.Equivalent(expectedCustomer, customer);
    }

    [Fact]
    public void CalculateFasterQueue_AreEmptyQueues_ReturnsQueue1()
    {
        // Arrange
        var customerCare = new CustomerCare();
        var expectedQueueNumber = 1;

        // Act
        var queueNumber = customerCare.CalculateFasterQueue(emptyQueue);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

}