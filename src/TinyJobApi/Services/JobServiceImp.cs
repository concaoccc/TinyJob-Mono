using TinyJobApi.Database;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public class JobServiceImp(AppDbContext dbContext, ILogger<JobServiceImp> logger) : IJobService
{
    public PageVo<JobVo> GetAllJobs(int page, int size)
    {
        var jobCount = dbContext.Jobs.Count();
        var jobs = dbContext.Jobs
            .OrderByDescending(j => j.CreateTime)
            .Skip((page -1) * size)
            .Take(size).AsEnumerable()
            .Select(ConvertJobDoToVo)
            .ToList();
        logger.LogInformation($"Total job count {jobCount}, get {jobs.Count} schedulers with page {page}, pagesize {size}.");
        return new PageVo<JobVo>()
        {
            TotalCount = jobCount,
            Page = page,
            PageSize = size,
            Data = jobs
        };
    }

    public JobVo? GetJobById(int id)
    {
        logger.LogInformation($"Query job for {id}");
        JobDo? jobDo = dbContext.Jobs.FirstOrDefault(j => j.Id == id);
        return jobDo != null ? ConvertJobDoToVo(jobDo) : null;
    }

    public JobVo? UpdateJobStatusById(int id, JobStatus status)
    {
        logger.LogInformation($"Try to update job to {status}.");
        var job = dbContext.Jobs.FirstOrDefault(j => j.Id == id);
        if (job == null)
        {
            return null;
        }

        job.Status = status;
        job.UpdateTime = DateTime.Now.ToUniversalTime();
        dbContext.SaveChanges();
        logger.LogInformation($"Updated job {id}, current value: {job}");
        return ConvertJobDoToVo(job);
    }
    
    // convert JobDo to JobVo
    private JobVo ConvertJobDoToVo(JobDo jobDo)
    {
        return new JobVo
        {
            Id = jobDo.Id,
            Name = jobDo.Name,
            SchedulerId = jobDo.SchedulerId,
            Status = jobDo.Status.ToString(),
            ScheduledExecutionTime = jobDo.ScheduledExecutionTime,
            ActualExecutionTime = jobDo.ActualExecutionTime,
            FinishTime = jobDo.FinishTime,
            CreateTime = jobDo.CreateTime,
            UpdateTime = jobDo.UpdateTime,
        };
    }
}
