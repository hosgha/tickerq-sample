using TickerQ.Utilities.Entities;

namespace TickerqSample.BackgroundJobs.CronJobs;

public abstract class CronBasedJobs
{
    public static CronTickerEntity[] GetJobs()
    {
        return
        [
            new CronTickerEntity {Function = JobSchedulerConstants.CronJobs.CronBasedJobTest, Expression = JobSchedulerConstants.DefaultCron.EveryMinute}
        ];
    }
}
