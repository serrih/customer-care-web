namespace QueuesDispatcherLibrary.Tests;

public class QueuesDispatcherTests
{
    private static readonly IEnumerable<Tuple<short, int>> emptyQueue = new List<Tuple<short, int>>();
    private static readonly IEnumerable<Tuple<short, int>> oneCustomerQueue1 = new List<Tuple<short, int>>() { new(1, 1)};
    private static readonly IEnumerable<Tuple<short, int>> customersQueue1Longer = new List<Tuple<short, int>>() { new(1, 4), new(2, 2) };
    private static readonly IEnumerable<Tuple<short, int>> customersQueue2Longer = new List<Tuple<short, int>>() { new(1, 4), new(2, 3) };

    [Fact]
    public void CalculateFasterQueue_AreEmptyQueues_ReturnsQueue1()
    {
        // Arrange
        var expectedQueueNumber = 1;

        // Act
        var queueNumber = QueuesDispatcher.CalculateFasterQueue(emptyQueue);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

    [Fact]
    public void CalculateFasterQueue_Queue1HasOneCustomer_ReturnsQueue2()
    {
        // Arrange
        var expectedQueueNumber = 2;

        // Act
        var queueNumber = QueuesDispatcher.CalculateFasterQueue(oneCustomerQueue1);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

    [Fact]
    public void CalculateFasterQueue_Queue2TakesLonger_ReturnsQueue1()
    {
        // Arrange
        var expectedQueueNumber = 1;

        // Act
        var queueNumber = QueuesDispatcher.CalculateFasterQueue(customersQueue2Longer);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

    [Fact]
    public void CalculateFasterQueue_Queue1TakesLonger_ReturnsQueue2()
    {
        // Arrange
        var expectedQueueNumber = 2;

        // Act
        var queueNumber = QueuesDispatcher.CalculateFasterQueue(customersQueue1Longer);

        // Assert
        Assert.Equal(expectedQueueNumber, queueNumber);
    }

}