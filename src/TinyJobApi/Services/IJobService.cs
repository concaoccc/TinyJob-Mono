using System;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public interface IJobService
{
    public JobVo? GetJobById(int id);
    public PageVo<JobVo> GetAllJobs(int page = 1, int size = 10);
    public JobVo? UpdateJobStatusById(int id, JobStatus status);
}
