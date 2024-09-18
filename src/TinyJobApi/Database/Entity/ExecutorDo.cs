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
    public DateTimeOffset LastHeartbeat { get; set; }
    public ExecutorStatus Status { get; set; }
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset UpdateTime { get; set; }
}
