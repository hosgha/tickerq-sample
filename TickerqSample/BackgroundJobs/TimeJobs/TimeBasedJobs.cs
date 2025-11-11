using TickerQ.Utilities.Entities;

namespace TickerqSample.BackgroundJobs.TimeJobs;

public abstract class TimeBasedJobs
{
    public static TimeTickerEntity[] GetJobs()
    {
        return
        [
            new TimeTickerEntity {Function = JobSchedulerConstants.TimeJobs.TimeBasedJobTest, ExecutionTime = DateTime.UtcNow.AddSeconds(5)}
        ];
    }
}