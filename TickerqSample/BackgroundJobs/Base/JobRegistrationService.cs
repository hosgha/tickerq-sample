using TickerQ.Utilities.Entities;
using TickerQ.Utilities.Interfaces.Managers;
using TickerqSample.BackgroundJobs.CronJobs;
using TickerqSample.BackgroundJobs.TimeJobs;

namespace TickerqSample.BackgroundJobs.Base;
public interface IJobRegistrationService
{
    Task RegisterJobsAsync();
}

public class JobRegistrationService(
    ITimeTickerManager<TimeTickerEntity> timeManager,
    ICronTickerManager<CronTickerEntity> cronManager)
    : IJobRegistrationService
{
    public async Task RegisterJobsAsync()
    {
        try
        {
                await timeManager.AddAsync(new TimeTickerEntity {Function = JobSchedulerConstants.TimeJobs.TimeBasedJobTest, ExecutionTime = DateTime.UtcNow.AddSeconds(5)});
            
                await cronManager.AddAsync(new CronTickerEntity {Function = JobSchedulerConstants.CronJobs.CronBasedJobTest, Expression = JobSchedulerConstants.DefaultCron.EveryMinute});

            Console.WriteLine("✅ TickerQ jobs registered successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error registering TickerQ jobs: {ex.Message}");
            throw;
        }
    }
}