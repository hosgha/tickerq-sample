using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TickerqSample.BackgroundJobs;
using TickerqSample.BackgroundJobs.Base;

namespace TickerqSample.ServiceExtensions;

public static class TickerQJobExtensions
{
    public static async Task UseTickerQJobsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var jobService = scope.ServiceProvider.GetService<IJobRegistrationService>();
        
        if (jobService != null)
        {
            await jobService.RegisterJobsAsync();
        }
        else
        {
            Console.WriteLine("⚠️ Warning: Job registration service not found");
        }
    }
}