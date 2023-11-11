namespace CustomerCare.Repository.Tests;

public class CustomerCareTests 
{

    private static CustomerCare customerCare = new CustomerCare();

    private static IEnumerable<Customer> emptyQueue = new List<Customer>();
    private static IEnumerable<Customer> oneCustomerQueue1 = new List<Customer>() { new Customer(1, "Peter", 1) };
    private static IEnumerable<Customer> customersQueue1Longer = new List<Customer>() { 
            new Customer(1, "Peter", 1), 
            new Customer(2, "John", 2),
            new Customer(3, "Ken", 1),
            new Customer(4, "Tom", 1),
            new Customer(5, "Alan", 2),
            new Customer(6, "George", 1)
    };
    private static IEnumerable<Customer> customersQueue2Longer = new List<Customer>() { 
            new Customer(1, "Peter", 1), 
            new Customer(2, "John", 2),
            new Customer(3, "Ken", 1),
            new Customer(4, "Tom", 1),
            new Customer(5, "Alan", 2),
            new Customer(6, "George", 1),
            new Customer(7, "Charles", 2),
    };

    [Fact]
    public void RegisterClient() 
    {
        // Arrange
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
        var expectedQueueNumber = 1;

        // Act
        var queueNumber = customerCare.CalculateFasterQueue(emptyQueue);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

    [Fact]
    public void CalculateFasterQueue_Queue1HasOneCustomer_ReturnsQueue2()
    {
        // Arrange
        var expectedQueueNumber = 2;

        // Act
        var queueNumber = customerCare.CalculateFasterQueue(oneCustomerQueue1);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

    [Fact]
    public void CalculateFasterQueue_Queue2TakesLonger_ReturnsQueue1()
    {
        // Arrange
        var expectedQueueNumber = 1;

        // Act
        var queueNumber = customerCare.CalculateFasterQueue(customersQueue2Longer);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

    [Fact]
    public void CalculateFasterQueue_Queue1TakesLonger_ReturnsQueue2()
    {
        // Arrange
        var expectedQueueNumber = 2;

        // Act
        var queueNumber = customerCare.CalculateFasterQueue(customersQueue1Longer);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

}