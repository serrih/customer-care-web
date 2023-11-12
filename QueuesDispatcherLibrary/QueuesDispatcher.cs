namespace QueuesDispatcherLibrary;

public class QueuesDispatcher
{
    private const short attentionTimeQueue1 = 2;
    private const short attentionTimeQueue2 = 3;

    public static short CalculateFasterQueue(IEnumerable<Tuple<short, int>> customersByQueue)
    {
        var queue1 = customersByQueue.FirstOrDefault(x => x.Item1 == 1);
        var queue2 = customersByQueue.FirstOrDefault(x => x.Item1 == 2);

        if (queue1 == null)
            return 1;

        if (queue2 == null)
            return 2;

        var accumulatedMinutesInQueue1 = queue1.Item2 * attentionTimeQueue1;
        var accumulatedMinutesInQueue2 = queue2.Item2 * attentionTimeQueue2;

        if (accumulatedMinutesInQueue1 <= accumulatedMinutesInQueue2)
            return 1;

        return 2;
    }
}