using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TinyJobApi.Database.Entity;

public enum JobStatus
{
    NotStarted = 1,
    Schedulered = 2,
    WaitForExectution = 3,
    Executing = 4,
    Succeed = 5,
    Failed = 6,
    Paused = 7,
    Stopped = 8,
    ReScheduled = 9
}

public class JobDo
{
    [Key]
    public long Id { get; set; }

    [MaxLength(50)]
    [Required]
    public required string Name { get; set; }

    [ForeignKey("Scheduler")]
    public long SchedulerId { get; set; }

    public virtual required SchedulerDo Scheduler { get; set; }

    public long ExecutorId { get; set; }

    [AllowedValues(JobStatus.NotStarted, JobStatus.Schedulered, JobStatus.WaitForExectution, JobStatus.Executing, JobStatus.Succeed, JobStatus.Failed, JobStatus.Paused, JobStatus.Stopped, JobStatus.ReScheduled)]
    public required string Status { get; set; }

    [AllowNull]
    public DateTime? ScheduledExecutionTime { get; set; }

    [AllowNull]
    public DateTime? ActualExecutionTime { get; set; }

    [AllowNull]
    public DateTime? FinishTime { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }
}
