using Microsoft.EntityFrameworkCore;
using System;
using TinyJobApi.Data;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Services;

public class JobServiceImp : IJobService
{
    private readonly AppDbContext _dbContext;
    public JobServiceImp(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteJobByIdAsync(int id)
    {
        var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        
        if (job != null)
        {
            _dbContext.Jobs.Remove(job);
            await _dbContext.SaveChangesAsync();
        }
    }

    public Task<IEnumerable<JobDo>> GetAllJobsAsync()
    {
        return Task.FromResult<IEnumerable<JobDo>>(_dbContext.Jobs);
    }

    public Task<JobDo?> GetJobByIdAsync(int id)
    {
        return Task.FromResult(_dbContext.Jobs.FirstOrDefault(j => j.Id == id));
    }

    public Task<JobDo?> UpdateJobStatusByIdAsync(int id, JobStatus status)
    {
        var job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
        if (job != null)
        {
            job.Status = status.ToString();
            return Task.FromResult<JobDo?>(job);
        }

        return Task.FromResult<JobDo?>(null);
    }
}
