using TickerQ.Utilities.Base;

namespace TickerqSample.BackgroundJobs.TimeJobs;

public class TestTimeBasedJob
{
    [TickerFunction(JobSchedulerConstants.TimeJobs.TimeBasedJobTest)]
    public static Task TimeBasedJobTest(TickerFunctionContext context, CancellationToken cancellationToken)
    {
        Console.WriteLine($"TickerQ is working! Job ID: {context.Id}");
        return Task.CompletedTask;
    }
}