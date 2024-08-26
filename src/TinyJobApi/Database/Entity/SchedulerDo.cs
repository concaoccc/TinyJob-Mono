using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TinyJobApi.Database.Entity;

public enum SchedulerType
{
    Once = 1,
    Cron = 2,
    Interval = 3
}

[Index(nameof(PackageId), nameof(Name), IsUnique = true)]
public class SchedulerDo
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public SchedulerType Type { get; set; }
    [ForeignKey("package")]
    public long PackageId { get; set; }
    public virtual required PackageDo Package { get; set; }
    public required string AssemblyName { get; set; }
    public required string Namespace { get; set; }
    public required string ClassName { get; set; }
    public required string ExecutionPlan { get; set; }
    [AllowNull]
    public string? ExecutionParams { get; set; }
    [AllowNull]
    public DateTime? NextExecutionTime { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
    public DateTime EndTime { get; set; }
}
