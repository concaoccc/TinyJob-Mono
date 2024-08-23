using System;

namespace TinyJobApi.Models;

public class Job
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public long SchedulerId { get; set; }
    public required string SchedulerName { get; set; }
    public long? ExecutorId { get; set; }
    public required string Status { get; set; }
    public DateTime? ScheduledExecutionTime { get; set; }
    public DateTime? ActualExecutionTime { get; set; }
    public DateTime? FinishTime { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
