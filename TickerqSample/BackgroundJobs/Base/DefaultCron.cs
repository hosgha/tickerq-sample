namespace TickerqSample.BackgroundJobs.Base;

public abstract class DefaultCron
{
    //// Every second
    public const string EverySecond = "*/1 * * * * *";
    
    /// Every 5 seconds
    public const string Every5Seconds = "*/5 * * * * *";
    
    /// Every 10 seconds
    public const string Every10Seconds = "*/10 * * * * *";
    
    /// Every minute
    public const string EveryMinute = "* * * * *";
    
    /// Every 5 minutes
    public const string Every5Minutes = "*/5 * * * *";
    
    /// Every 10 minutes
    public const string Every10Minutes = "*/10 * * * *";
    
    /// Hourly, at minute 0
    public const string EveryHour = "0 * * * *";
    
    /// Daily at midnight
    public const string DailyMidnight = "0 0 0 * * *";
    
    /// Daily at 9:00 AM
    public const string Daily9Am = "0 0 9 * * *";
    
    /// Daily at 6:00 PM
    public const string Daily6Pm = "0 0 18 * * *";
    
    /// Every 6 hours
    public const string Every6Hours = "0 0 */6 * * *";
    
    /// At 9 AM and 5 PM daily
    public const string TwiceDaily = "0 0 9,17 * * *";
    
    /// Every Monday at 2:30 PM
    public const string Monday1430 = "0 30 14 * * 1";
    
    /// Every Friday at 5:45 PM
    public const string Friday1745 = "0 45 17 * * 5";
    
    /// Every Sunday at 11:59 PM
    public const string Sunday2359 = "0 59 23 * * 0";
    
    /// Every weekday at 8:00 AM
    public const string Weekday8Am = "0 0 8 * * 1-5";
    
    /// Every 15 minutes during business hours (9 AM - 5 PM)
    public const string BusinessHoursQuarterHour = "0 */15 9-17 * * *";
    
    /// Every 30 seconds
    public const string Every30Seconds = "*/30 * * * * *";
}
