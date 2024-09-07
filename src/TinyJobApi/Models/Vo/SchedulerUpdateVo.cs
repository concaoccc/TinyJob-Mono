using TinyJobApi.Database.Entity;

namespace TinyJobApi.Models.Vo
{
    public class SchedulerUpdateVo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SchedulerType? Type { get; set; }
        public long?  PackageId { get; set; }
        public string? AssemblyName { get; set; }
        public string? Namespace { get; set; }
        public string? ClassName { get; set; }
        public string? ExecutionPlan { get; set; }
        public string? ExecutionParams { get; set; }
    }
}