using System.ComponentModel.DataAnnotations;

namespace TinyJobApi.Database.Entity;

public enum ExecutorStatus
{
    Online = 1,
    Offline = 2,
}

public class ExecutorDo
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime LastHeartbeat { get; set; }
    public ExecutorStatus Status { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
