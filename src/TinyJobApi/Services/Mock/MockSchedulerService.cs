using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services;

public class MockSchedulerService : ISchedulerService
{
    public Task<Scheduler?> CreateSchedulerAsync(Scheduler scheduler)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Scheduler>> GetAllSchedulersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Scheduler?> GetSchedulerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Scheduler?> UpdateSchedulerByIdAsync(int id, Scheduler scheduler)
    {
        throw new NotImplementedException();
    }
}
