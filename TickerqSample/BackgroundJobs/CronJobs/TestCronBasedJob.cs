using TickerQ.Utilities.Base;
using TickerqSample.BackgroundJobs.Base;

namespace TickerqSample.BackgroundJobs.CronJobs;

public class TestCronBasedJob : ICronJob
{
    [TickerFunction(JobSchedulerConstants.CronJobs.CronBasedJobTest, cronExpression: JobSchedulerConstants.DefaultCron.EveryMinute)]
    public static Task CronJobEveryMinuteTest(TickerFunctionContext context, CancellationToken cancellationToken)
    {
        Console.WriteLine($"context id is : {context.Id} and [CRON] test tick – {DateTime.Now:HH:mm:ss}");
        return Task.CompletedTask;
    }
}