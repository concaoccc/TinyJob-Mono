using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services;

public class MockJobService : IJobService
{
    private static readonly List<Job> Jobs = new();

    public Task DeleteJobByIdAsync(int id)
    {
        var job = Jobs.FirstOrDefault(j => j.Id == id);
        if (job != null)
        {
            Jobs.Remove(job);
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Job>> GetAllJobsAsync()
    {
        return Task.FromResult<IEnumerable<Job>>(Jobs);
    }

    public Task<Job?> GetJobByIdAsync(int id)
    {
        return Task.FromResult(Jobs.FirstOrDefault(j => j.Id == id));
    }

    public Task<Job?> UpdateJobStatusByIdAsync(int id, string status)
    {
        var job = Jobs.FirstOrDefault(j => j.Id == id);
        if (job != null)
        {
            job.Status = status;
        }

        return Task.FromResult(job);
    }
}