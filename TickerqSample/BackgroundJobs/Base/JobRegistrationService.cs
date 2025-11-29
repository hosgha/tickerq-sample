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

public partial class JobRegistrationService : IJobRegistrationService
{
    private readonly ITimeTickerManager<TimeTickerEntity> _timeManager;

    public JobRegistrationService(
        ITimeTickerManager<TimeTickerEntity> timeManager,
        ICronTickerManager<CronTickerEntity> cronManager)
    {
        _timeManager = timeManager;
    }

    public Task RegisterJobsAsync()
    {
        RegisterTimeJobs(_timeManager);

        Console.WriteLine("Time-based jobs registration triggered.");
        return Task.CompletedTask;
    }
    
    partial void RegisterTimeJobs(ITimeTickerManager<TimeTickerEntity> timeManager);
}