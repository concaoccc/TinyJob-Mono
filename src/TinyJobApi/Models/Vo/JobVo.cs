using TinyJobApi.Database.Entity;

namespace TinyJobApi.Models.Vo;

public class JobVo
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public long SchedulerId { get; set; }
    public required string Status { get; set; }
    public DateTimeOffset? ScheduledExecutionTime { get; set; }
    public DateTimeOffset? ActualExecutionTime { get; set; }
    public DateTimeOffset? FinishTime { get; set; }
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset UpdateTime { get; set; }
}
