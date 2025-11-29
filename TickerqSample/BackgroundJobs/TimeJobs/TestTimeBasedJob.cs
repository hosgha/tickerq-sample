using System;
using System.Threading;
using System.Threading.Tasks;
using TickerQ.Utilities.Base;
using TickerqSample.BackgroundJobs.Base;

namespace TickerqSample.BackgroundJobs.TimeJobs;

public class TestTimeBasedJob : ITimeTickerJob
{
    [TickerFunction(functionName: nameof(TestTimeBasedJob))]
    [TimeJob(offsetSeconds: 10)]
    public static Task TimeBasedJobTest(TickerFunctionContext context, CancellationToken cancellationToken)
    {
        Console.WriteLine($"TickerQ is working! Job ID: {context.Id}");
        return Task.CompletedTask;
    }
}