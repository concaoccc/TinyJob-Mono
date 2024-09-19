namespace TinyJobApi.Database.Entity;

public enum SchedulerType
{
    Once = 1,
    Cron = 2,
    Interval = 3
}

public class SchedulerDo
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public SchedulerType Type { get; set; }
    public int PackageId { get; set; }
    public PackageDo? Package { get; set; }
    public required string AssemblyName { get; set; }
    public required string Namespace { get; set; }
    public required string ClassName { get; set; }
    public required string ExecutionPlan { get; set; }
    public string? ExecutionParams { get; set; }
    public DateTimeOffset? NextExecutionTime { get; init; }
    public DateTimeOffset CreateTime { get; init; }
    public DateTimeOffset UpdateTime { get; set; }
    public DateTimeOffset? EndTime { get; init; }
    public ICollection<JobDo> Jobs { get; } = new List<JobDo>();
}
