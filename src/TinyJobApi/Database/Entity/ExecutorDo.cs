namespace TinyJobApi.Database.Entity;

public enum ExecutorStatus
{
    Online = 1,
    Offline = 2,
}

public class ExecutorDo
{ 
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTimeOffset LastHeartbeat { get; set; }
    public ExecutorStatus Status { get; set; }
    public DateTimeOffset CreateTime { get; set; }
    public DateTimeOffset UpdateTime { get; set; }
    public ICollection<JobDo> Jobs { get; } = new List<JobDo>();
}
