using System;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public interface ISchedulerService
{
    public Task<IEnumerable<SchedulerDo>> GetAllSchedulersAsync();
    public Task<SchedulerDo?> GetSchedulerByIdAsync(int id);
    public Task<SchedulerDo?> UpdateSchedulerByIdAsync(int id, SchedulerDo schedulerDo);
    public Task<int> CreateSchedulerAsync(SchedulerDo schedulerDo);
    public Task DeleteSchedulerByIdAsync(int id);
}
