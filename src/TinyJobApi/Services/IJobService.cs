using System;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public interface IJobService
{
    public JobVo? GetJobById(int id);
    public List<JobVo> GetAllJobs();
    public JobVo? UpdateJobStatusById(int id, JobStatus status);
}
