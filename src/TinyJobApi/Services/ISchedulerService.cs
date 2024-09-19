using System;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public interface ISchedulerService
{
    public PageVo<SchedulerVo> GetAllSchedulers(int page = 1, int size = 10);
    public SchedulerVo? GetSchedulerById(int id);
    public SchedulerVo? UpdateSchedulerById(int id, SchedulerUpdateVo schedulerUpdateVo);
    public SchedulerVo CreateScheduler(SchedulerCreationVo schedulerCreationVo);
    public bool DeleteSchedulerById(int id);
    public List<SchedulerDo> FindByPackageId(long packageId);
}
