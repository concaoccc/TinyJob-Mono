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

[Table("Job")]
public class JobDo
{
    [Key]
    public long Id { get; init; }
    [MaxLength(50)]
    [Required]
    public required string Name { get; init; }
    [ForeignKey("Scheduler")]
    public long SchedulerId { get; init; }
    public long? ExecutorId { get; set; }
    public required JobStatus Status { get; set; }
    public DateTime? ScheduledExecutionTime { get; set; }
    public DateTime? ActualExecutionTime { get; set; }
    public DateTime? FinishTime { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
