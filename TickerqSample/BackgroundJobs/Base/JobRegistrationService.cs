// JobRegistrationService.cs
using System;
using System.Threading.Tasks;
using TickerQ.Utilities.Entities;
using TickerQ.Utilities.Interfaces.Managers;

namespace TickerqSample.BackgroundJobs.Base;

public interface IJobRegistrationService
{
    Task RegisterJobsAsync();
}

public partial class JobRegistrationService(
    ITimeTickerManager<TimeTickerEntity> timeManager,
    ICronTickerManager<CronTickerEntity> cronManager)
    : IJobRegistrationService
{
    public Task RegisterJobsAsync()
    {
        RegisterJobs(timeManager, cronManager);

        Console.WriteLine("Time-based jobs registration triggered.");
        return Task.CompletedTask;
    }
    
    partial void RegisterJobs(ITimeTickerManager<TimeTickerEntity> timeManager, ICronTickerManager<CronTickerEntity> cronManager);
}