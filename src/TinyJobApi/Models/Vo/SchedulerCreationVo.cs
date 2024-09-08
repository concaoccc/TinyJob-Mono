using System;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Models;

public class SchedulerCreationVo
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required SchedulerType Type { get; set; }
    public required long PackageId { get; set; }
    public required string AssemblyName { get; set; }
    public required string Namespace { get; set; }
    public required string ClassName { get; set; }
    public required string ExecutionPlan { get; set; }
    public string? ExecutionParams { get; set; }
}
