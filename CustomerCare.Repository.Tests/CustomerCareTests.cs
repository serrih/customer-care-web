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

}