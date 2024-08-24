using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services.Mock;

public class MockSchedulerService : ISchedulerService
{
    private static readonly List<Scheduler> Schedulers = new();
    
    public Task<Scheduler> CreateSchedulerAsync(Scheduler scheduler)
    {
        Schedulers.Add(scheduler); 
        return Task.FromResult(scheduler);
    }

    public Task DeleteSchedulerByIdAsync(int id)
    {
        var scheduler = Schedulers.FirstOrDefault(s => s.Id == id);
        if (scheduler != null)
        {
            Schedulers.Remove(scheduler);
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Scheduler>> GetAllSchedulersAsync()
    {
        return Task.FromResult<IEnumerable<Scheduler>>(Schedulers);
    }

    public Task<Scheduler?> GetSchedulerByIdAsync(int id)
    {
        return Task.FromResult(Schedulers.FirstOrDefault(s => s.Id == id));
    }

    public Task<Scheduler?> UpdateSchedulerByIdAsync(int id, Scheduler scheduler)
    {
        var existingScheduler = Schedulers.FirstOrDefault(s => s.Id == id);
        if (existingScheduler != null)
        {
            existingScheduler.Name = scheduler.Name;
            existingScheduler.Description = scheduler.Description;
            existingScheduler.ExecutionPlan = scheduler.ExecutionPlan;
            existingScheduler.AssemblyName = scheduler.AssemblyName;
            existingScheduler.Namespace = scheduler.Namespace;
            existingScheduler.ClassName = scheduler.ClassName;
            existingScheduler.ExecutionParams = scheduler.ExecutionParams;
        }

        return Task.FromResult(existingScheduler);
    }
}