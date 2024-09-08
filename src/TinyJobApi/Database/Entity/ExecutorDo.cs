using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyJobApi.Database.Entity;

public enum ExecutorStatus
{
    Online = 1,
    Offline = 2,
}

[Table("Executor")]
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
