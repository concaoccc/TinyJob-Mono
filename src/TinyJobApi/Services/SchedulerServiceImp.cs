using NuGet.Packaging.Signing;
using System;
using TinyJobApi.Data;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Services;

public class SchedulerServiceImp : ISchedulerService
{
    private readonly AppDbContext _dbContext;
    public SchedulerServiceImp(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> CreateSchedulerAsync(SchedulerDo schedulerDo)
    {
        _dbContext.Schedulers.Add(schedulerDo);
        return Task.FromResult(_dbContext.SaveChanges());
    }

    public Task DeleteSchedulerByIdAsync(int id)
    {
        var scheduler = _dbContext.Schedulers.FirstOrDefault(s => s.Id == id);
        if (scheduler != null)
        {
            _dbContext.Schedulers.Remove(scheduler);
            return Task.FromResult(_dbContext.SaveChanges());
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<SchedulerDo>> GetAllSchedulersAsync()
    {
        return Task.FromResult<IEnumerable<SchedulerDo>>(_dbContext.Schedulers);
    }

    public Task<SchedulerDo?> GetSchedulerByIdAsync(int id)
    {
        return Task.FromResult(_dbContext.Schedulers.FirstOrDefault(s => s.Id == id));
    }

    public Task<SchedulerDo?> UpdateSchedulerByIdAsync(int id, SchedulerDo schedulerDo)
    {
        var existingScheduler = _dbContext.Schedulers.FirstOrDefault(s => s.Id == id);
        if (existingScheduler != null)
        {
            existingScheduler.Name = schedulerDo.Name;
            existingScheduler.AssemblyName = schedulerDo.AssemblyName;
            existingScheduler.ClassName = schedulerDo.ClassName;
            existingScheduler.Namespace = schedulerDo.Namespace;
            existingScheduler.ExecutionPlan = schedulerDo.ExecutionPlan;
            existingScheduler.ExecutionParams = schedulerDo.ExecutionParams;
            existingScheduler.UpdateTime = DateTime.Now;
            _dbContext.SaveChanges();
            return Task.FromResult<SchedulerDo?>(existingScheduler);
        }

        return Task.FromResult<SchedulerDo?>(null);
    }
}
