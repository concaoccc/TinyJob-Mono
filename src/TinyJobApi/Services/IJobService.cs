using System;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Services;

public interface IJobService
{
    public Task<JobDo?> GetJobByIdAsync(int id);
    public Task<IEnumerable<JobDo>> GetAllJobsAsync();
    public Task<JobDo?> UpdateJobStatusByIdAsync(int id, JobStatus status);
    public Task DeleteJobByIdAsync(int id);
}
