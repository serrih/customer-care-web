namespace QueuesDispatcherLibrary;

public class QueuesDispatcher
{
    private const short attentionTimeQueue1 = 2;
    private const short attentionTimeQueue2 = 3;

    public static short CalculateFasterQueue(IEnumerable<(short, int)> customersByQueue)
    {
        if (!customersByQueue.Any())
            return 1;

        var accumulatedMinutesInQueue1 = customersByQueue.FirstOrDefault(x => x.Item1 == 1).Item2 * attentionTimeQueue1;
        var accumulatedMinutesInQueue2 = customersByQueue.FirstOrDefault(x => x.Item1 == 2).Item2 * attentionTimeQueue2;

        if (accumulatedMinutesInQueue1 <= accumulatedMinutesInQueue2)
            return 1;

        return 2;
    }
}