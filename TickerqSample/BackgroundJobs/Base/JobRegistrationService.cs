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
            foreach (var timeTickerEntity in TimeBasedJobs.GetJobs()) 
                await timeManager.AddAsync(timeTickerEntity);
                
            foreach (var cronTickerEntity in CronBasedJobs.GetJobs()) 
                await cronManager.AddAsync(cronTickerEntity);

            Console.WriteLine("✅ TickerQ jobs registered successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error registering TickerQ jobs: {ex.Message}");
            throw;
        }
    }
}