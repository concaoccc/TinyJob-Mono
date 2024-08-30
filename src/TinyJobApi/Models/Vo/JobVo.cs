using TinyJobApi.Database.Entity;

namespace TinyJobApi.Models.Vo;

public class JobVo
{
    public JobVo(JobDo jobDo) 
    {
        Id = jobDo.Id;
        Name = jobDo.Name;
        SchedulerId = jobDo.SchedulerId;
        SchedulerName = jobDo.Scheduler.Name;
        Status = (JobStatus)Enum.Parse(typeof(JobStatus), jobDo.Status);
        ScheduledExecutionTime = jobDo.ScheduledExecutionTime;
        ActualExecutionTime = jobDo.ActualExecutionTime;
        FinishTime = jobDo.FinishTime;
        CreateTime = jobDo.CreateTime;
        UpdateTime = jobDo.UpdateTime;
    }
    
    public long Id { get; set; }
    public required string Name { get; set; }
    public long SchedulerId { get; set; }
    public required string SchedulerName { get; set; }
    public required JobStatus Status { get; set; }
    public DateTime? ScheduledExecutionTime { get; set; }
    public DateTime? ActualExecutionTime { get; set; }
    public DateTime? FinishTime { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
