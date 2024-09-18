using TinyJobApi.Database;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Services;

public class SchedulerServiceImp(AppDbContext dbContext, ILogger<SchedulerServiceImp> logger)
    : ISchedulerService
{
    public SchedulerVo CreateScheduler(SchedulerCreationVo schedulerCreationVo)
    {
        logger.LogInformation($"Create scheduler {schedulerCreationVo}");
        var schedulerDo = new SchedulerDo
        {
            Name = schedulerCreationVo.Name,
            Description = schedulerCreationVo.Description,
            Type = schedulerCreationVo.Type,
            PackageId = schedulerCreationVo.PackageId,
            AssemblyName = schedulerCreationVo.AssemblyName,
            Namespace = schedulerCreationVo.Namespace,
            ClassName = schedulerCreationVo.ClassName,
            ExecutionPlan = schedulerCreationVo.ExecutionPlan,
            ExecutionParams = schedulerCreationVo.ExecutionParams,
            CreateTime = DateTime.Now.ToUniversalTime(),
            UpdateTime = DateTime.Now.ToUniversalTime(),
            NextExecutionTime = DateTime.Now.ToUniversalTime()
        };
        dbContext.Schedulers.Add(schedulerDo);
        
        dbContext.SaveChanges();
        logger.LogInformation($"Created scheduler {schedulerDo}");
        return ConvertSchedulerDoToVo(schedulerDo);
    }

    public bool DeleteSchedulerById(int id)
    {
        logger.LogInformation($"Try to delete scheduler {id}");
        var scheduler = dbContext.Schedulers.FirstOrDefault(s => s.Id == id);
        if (scheduler != null)
        {
            logger.LogInformation($"Delete scheduler {scheduler}");
            dbContext.Schedulers.Remove(scheduler);
            dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public List<SchedulerVo> GetAllSchedulers()
    {
        logger.LogInformation($"Get all schedules");
        var schedulerVos = dbContext.Schedulers.Select(ConvertSchedulerDoToVo).ToList();
        logger.LogInformation($"Get {schedulerVos.Count} schedules.");
        return schedulerVos;
    }

    public SchedulerVo? GetSchedulerById(int id)
    {
        logger.LogInformation($"Query scheduler for {id}");
        var schedulerDo = dbContext.Schedulers.FirstOrDefault(s => s.Id == id);
        if (schedulerDo == null)
        {
            logger.LogWarning($"cannot find scheduler {id}");
            return null;
        }
        
        return ConvertSchedulerDoToVo(schedulerDo);
    }

    public SchedulerVo? UpdateSchedulerById(int id, SchedulerUpdateVo schedulerUpdateVo)
    {
        logger.LogInformation($"Update scheduler {id} with {schedulerUpdateVo}");
        var existingScheduler = dbContext.Schedulers.FirstOrDefault(s => s.Id == id);
        if (existingScheduler == null)
        {
            logger.LogWarning($"cannot find scheduler {id}");
            return null;
        }
        
        bool needUpdate = false;
        if (!string.IsNullOrEmpty(schedulerUpdateVo.Name) && schedulerUpdateVo.Name != existingScheduler.Name)
        {
            needUpdate = true;
            existingScheduler.Name = schedulerUpdateVo.Name;
        }

        if (!string.IsNullOrEmpty(schedulerUpdateVo.Description) && schedulerUpdateVo.Description != existingScheduler.Description)
        {
            needUpdate = true;
            existingScheduler.Description = schedulerUpdateVo.Description;
        }
        
        if (schedulerUpdateVo.Type != null && schedulerUpdateVo.Type != existingScheduler.Type)
        {
            needUpdate = true;
            existingScheduler.Type = schedulerUpdateVo.Type.Value;
        }

        if (schedulerUpdateVo.PackageId != null && schedulerUpdateVo.PackageId != existingScheduler.PackageId)
        {
            needUpdate = true;
            existingScheduler.PackageId = schedulerUpdateVo.PackageId.Value;
        }
        
        if (!string.IsNullOrEmpty(schedulerUpdateVo.AssemblyName) && schedulerUpdateVo.AssemblyName != existingScheduler.AssemblyName)
        {
            needUpdate = true;
            existingScheduler.AssemblyName = schedulerUpdateVo.AssemblyName;
        }
        
        if (!string.IsNullOrEmpty(schedulerUpdateVo.Namespace) && schedulerUpdateVo.Namespace != existingScheduler.Namespace)
        {
            needUpdate = true;
            existingScheduler.Namespace = schedulerUpdateVo.Namespace;
        }
        
        if (!string.IsNullOrEmpty(schedulerUpdateVo.ClassName) && schedulerUpdateVo.ClassName != existingScheduler.ClassName)
        {
            needUpdate = true;
            existingScheduler.ClassName = schedulerUpdateVo.ClassName;
        }
        
        if (!string.IsNullOrEmpty(schedulerUpdateVo.ExecutionPlan) && schedulerUpdateVo.ExecutionPlan != existingScheduler.ExecutionPlan)
        {
            needUpdate = true;
            existingScheduler.ExecutionPlan = schedulerUpdateVo.ExecutionPlan;
        }
        
        if (!string.IsNullOrEmpty(schedulerUpdateVo.ExecutionParams) && schedulerUpdateVo.ExecutionParams != existingScheduler.ExecutionParams)
        {
            needUpdate = true;
            existingScheduler.ExecutionParams = schedulerUpdateVo.ExecutionParams;
        }
        
        if (!needUpdate)
        {
            logger.LogInformation($"No need to update scheduler {existingScheduler} with {schedulerUpdateVo}");
            existingScheduler.UpdateTime = DateTime.Now.ToUniversalTime();
            return ConvertSchedulerDoToVo(existingScheduler);
        }
        else
        {
            dbContext.SaveChanges();
            return ConvertSchedulerDoToVo(existingScheduler);
        }
    }
    
    public List<SchedulerDo> FindByPackageId(long packageId)
    {
        return dbContext.Schedulers.Where(s => s.PackageId == packageId).ToList();
    }
    
    // convert SchedulerDo to SchedulerVo
    private SchedulerVo ConvertSchedulerDoToVo(SchedulerDo schedulerDo)
    {
        return new SchedulerVo
        {
            Id = schedulerDo.Id,
            Name = schedulerDo.Name,
            Description = schedulerDo.Description,
            Type = schedulerDo.Type,
            AssemblyName = schedulerDo.AssemblyName,
            PackageId = schedulerDo.PackageId,
            ClassName = schedulerDo.ClassName,
            Namespace = schedulerDo.Namespace,
            ExecutionPlan = schedulerDo.ExecutionPlan,
            ExecutionParams = schedulerDo.ExecutionParams,
            CreateTime = schedulerDo.CreateTime,
            UpdateTime = schedulerDo.UpdateTime,
            NextExecutionTime = schedulerDo.NextExecutionTime
        };
    }
}
