using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyJobApi.Database.Entity;

public enum SchedulerType
{
    Once = 1,
    Cron = 2,
    Interval = 3
}

[Index(nameof(PackageId), nameof(Name), IsUnique = true)]
[Table("Scheduler")]
public class SchedulerDo
{
    [Key]
    public int Id { get; init; }
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(200)]
    public required string Description { get; set; }
    public SchedulerType Type { get; set; }
    [ForeignKey("package")]
    public long PackageId { get; set; }
    [MaxLength(50)]
    public required string AssemblyName { get; set; }
    [MaxLength(50)]
    public required string Namespace { get; set; }
    [MaxLength(50)]
    public required string ClassName { get; set; }
    [MaxLength(50)]
    public required string ExecutionPlan { get; set; }
    [MaxLength(50)]
    public string? ExecutionParams { get; set; }
    public DateTimeOffset? NextExecutionTime { get; init; }
    public DateTimeOffset CreateTime { get; init; }
    public DateTimeOffset UpdateTime { get; set; }
    public DateTimeOffset? EndTime { get; init; }
}
