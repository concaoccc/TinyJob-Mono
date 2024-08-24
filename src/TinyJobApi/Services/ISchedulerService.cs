using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services;

public interface ISchedulerService
{
    public Task<IEnumerable<Scheduler>> GetAllSchedulersAsync();
    public Task<Scheduler?> GetSchedulerByIdAsync(int id);
    public Task<Scheduler?> UpdateSchedulerByIdAsync(int id, Scheduler scheduler);
    public Task<Scheduler> CreateSchedulerAsync(Scheduler scheduler);
    public Task DeleteSchedulerByIdAsync(int id);
}
