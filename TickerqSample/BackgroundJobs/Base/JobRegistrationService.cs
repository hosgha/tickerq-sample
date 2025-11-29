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
    ITimeTickerManager<TimeTickerEntity> timeManager)
    : IJobRegistrationService
{
    public Task RegisterJobsAsync()
    {
        RegisterJobs(timeManager);

        Console.WriteLine("Time-based jobs registration triggered.");
        return Task.CompletedTask;
    }
    
    partial void RegisterJobs(ITimeTickerManager<TimeTickerEntity> timeManager);
}