namespace CustomerCare.Repository.Tests;

public class CustomerCareTests 
{

    [Fact]
    public void RegisterClient() 
    {
        // Arrange
        var customerCare = new CustomerCare();
        var expectedCustomer = new Customer(1, "Pepe");

        // Act
        var customer = customerCare.RegisterClient(1, "Pepe");

        // Assert
        Assert.Equivalent(expectedCustomer, customer);
    }

    [Fact]
    public void GetQueues_Empty()
    {
        // Arrange
        var customerCare = new CustomerCare();

        // Act
        var queue1 = customerCare.GetQueues();

        // Assert
        Assert.Empty(queue1);
    }

}