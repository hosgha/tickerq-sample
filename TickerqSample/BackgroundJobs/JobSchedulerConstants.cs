namespace TickerqSample.BackgroundJobs;

public abstract class JobSchedulerConstants
{
    public abstract class TimeJobs
    {
        public const string TimeBasedJobTest =  "TimeBasedJobTest";    
    }
    
    public abstract class CronJobs
    {
        public const string CronBasedJobTest =  "CronBasedJobTest";
    }
    
    public abstract class DefaultCron
    {
        public const string EveryMinute =  "* * * * *";
        
        // Example =>
        // "0 0 0 * * *" - Daily at midnight (00:00:00)
        // "0 0 9 * * *" - Daily at 9:00 AM
        // "30 0 0 * * *" - Daily at 00:00:30 (30 seconds past midnight)
        // "0 0 */6 * * *" - Every 6 hours on the hour
        // "*/10 * * * * *" - Every 10 seconds
        // "0 */5 * * * *" - Every 5 minutes
        // "0 0 9,17 * * *" - At 9 AM and 5 PM daily
        // "0 30 14 * * 1" - Every Monday at 2:30 PM
    }
}