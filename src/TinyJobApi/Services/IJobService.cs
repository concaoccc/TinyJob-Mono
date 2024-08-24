using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services;

public interface IJobService
{
    public Task<Job?> GetJobByIdAsync(int id);
    public Task<IEnumerable<Job>> GetAllJobsAsync();
    public Task<Job?> UpdateJobStatusByIdAsync(int id, string status);
    public Task DeleteJobByIdAsync(int id);
}
