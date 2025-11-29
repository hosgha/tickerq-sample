//TickerQ readonly auto-generated file.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TickerQ.Utilities;
using TickerQ.Utilities.Enums;
using TickerqSample;

namespace TickerqSample
{
    public static class TickerQInstanceFactoryExtensions
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        public static void Initialize()
        {
            var tickerFunctionDelegateDict = new Dictionary<string, (string, TickerTaskPriority, TickerFunctionDelegate)>(2);
            tickerFunctionDelegateDict.TryAdd("TestCronTickerBasedJob", ("0 * * * * *", (TickerTaskPriority)2, new TickerFunctionDelegate(async (cancellationToken, serviceProvider, context) =>
            {
                await TickerqSample.BackgroundJobs.CronJobs.TestCronTickerBasedJob.CronJobEveryMinuteTest(context, cancellationToken);
            })));
            tickerFunctionDelegateDict.TryAdd("TestTimeBasedJob", (string.Empty, (TickerTaskPriority)2, new TickerFunctionDelegate(async (cancellationToken, serviceProvider, context) =>
            {
                await TickerqSample.BackgroundJobs.TimeJobs.TestTimeBasedJob.TimeBasedJobTest(context, cancellationToken);
            })));
            TickerFunctionProvider.RegisterFunctions(tickerFunctionDelegateDict, 2);
            RegisterRequestTypes();
        }

        private static TickerqSample.BackgroundJobs.CronJobs.TestCronTickerBasedJob CreateTickerqSampleBackgroundJobsCronJobsTestCronTickerBasedJob(IServiceProvider serviceProvider)
        {
            return new TickerqSample.BackgroundJobs.CronJobs.TestCronTickerBasedJob();
        }

        private static TickerqSample.BackgroundJobs.TimeJobs.TestTimeBasedJob CreateTickerqSampleBackgroundJobsTimeJobsTestTimeBasedJob(IServiceProvider serviceProvider)
        {
            return new TickerqSample.BackgroundJobs.TimeJobs.TestTimeBasedJob();
        }

        private static void RegisterRequestTypes()
        {
        }
    }
}