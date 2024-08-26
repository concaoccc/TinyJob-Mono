using System;

namespace TinyJobApi.Models.Vo;

public class SchedulerVo
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string PackageName { get; set; }
    public required string PackageVersion { get; set; }
    public required string AssemblyName { get; set; }
    public required string Namespace { get; set; }
    public required string ClassName { get; set; }
    public required string ExecutionPlan { get; set; }
    public string? ExecutionParams { get; set; }
    public DateTime EndTime { get; set; }
}
