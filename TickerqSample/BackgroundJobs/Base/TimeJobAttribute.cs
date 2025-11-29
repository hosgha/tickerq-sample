using System;

namespace TickerqSample.BackgroundJobs.Base;

/// <summary>
/// Defines when a time-based ticker job should run.
/// <para/>
/// You can schedule the job in one of two ways:
/// <para/>
/// • <see cref="OffsetSeconds"/> — Delay execution by a number of seconds.<br/>
/// • <see cref="ExecutionTime"/> — Run at a specific ISO-8601 timestamp
///   (e.g. "2025-12-12T12:00:00Z").
/// <para/>
/// Important: Provide at least one of these values.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class TimeJobAttribute : Attribute
{
    /// <summary>
    /// Defines when a time-based ticker job should run.
    /// <para/>
    /// You can schedule the job in one of two ways:
    /// <para/>
    /// • <see cref="OffsetSeconds"/> — Delay execution by a number of seconds.<br/>
    /// • <see cref="ExecutionTime"/> — Run at a specific ISO-8601 timestamp
    ///   (e.g. "2025-12-12T12:00:00Z").
    /// <para/>
    /// Important: Provide at least one of these values.
    /// </summary>
    public TimeJobAttribute(int offsetSeconds = 0, string? executionTime = null)
    {
        OffsetSeconds = offsetSeconds;
        ExecutionTime = executionTime;
    }

    /// <summary>Delay in seconds from job registration.</summary>
    public int OffsetSeconds { get; }

    /// <summary>Exact execution time in ISO-8601 format (e.g. "2025-12-12T12:00:00Z").</summary>
    public string? ExecutionTime { get; }
}