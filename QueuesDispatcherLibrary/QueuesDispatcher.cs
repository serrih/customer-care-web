using CustomerCare.Models;

namespace QueuesDispatcherLibrary;

public class QueuesDispatcher
{
    private const short attentionTimeQueue1 = 2;
    private const short attentionTimeQueue2 = 3;

    public static short CalculateFasterQueue(IEnumerable<Customer> customers)
    {
        if (!customers.Any())
            return 1;

        var accumulatedMinutesInQueue1 = customers.Count(x => x.QueueNumber == 1) * attentionTimeQueue1;
        var accumulatedMinutesInQueue2 = customers.Count(x => x.QueueNumber == 2) * attentionTimeQueue2;

        if (accumulatedMinutesInQueue1 <= accumulatedMinutesInQueue2)
            return 1;

        return 2;
    }
}