using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TinyJobApi.Database.Entity;

public enum JobStatus
{
    NotStarted = 1,
    Scheduled = 2,
    WaitForExecution = 3,
    Executing = 4,
    Succeed = 5,
    Failed = 6,
    Paused = 7,
    Stopped = 8,
    ReScheduled = 9
}

public class JobDo
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public int SchedulerId { get; init; }
    public SchedulerDo? Scheduler { get; set; }
    public int? ExecutorId { get; set; }
    public ExecutorDo? Executor { get; set; }
    public required JobStatus Status { get; set; }
    public DateTimeOffset? ScheduledExecutionTime { get; set; }
    public DateTimeOffset? ActualExecutionTime { get; set; }
    public DateTimeOffset? FinishTime { get; set; }
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset UpdateTime { get; set; }
}
