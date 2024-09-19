using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController(ISchedulerService schedulerService, ILogger<SchedulerController> logger) : ControllerBase
    {
        // Get all schedulers, return List<Scheduler>
        [HttpGet(Name = "GetAllSchedulers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<SchedulerVo>> GetAllSchedulers(int page = 1, int pageSize = 10)
        {
            logger.LogInformation($"Query all schedulers with page {page}, pagesize {pageSize}.");
            PageVo<SchedulerVo> schedulers = schedulerService.GetAllSchedulers(page, pageSize);
            logger.LogInformation($"Get {schedulers.TotalCount} schedulers.");
            logger.LogDebug($"Get all schedulers: {JsonConvert.SerializeObject(schedulers)}");
            return Ok(schedulers);
        }

        // Get scheduler by id, return Scheduler
        [HttpGet("{id}", Name = "GetSchedulerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SchedulerVo> GetSchedulerById(int id)
        {
            logger.LogInformation($"Get scheduler by id: {id}");
            var scheduler = schedulerService.GetSchedulerById(id);
            if (scheduler == null)
            {
                logger.LogWarning($"Get scheduler {id} not found.");
                return NotFound();
            }
            
            logger.LogInformation($"Get scheduler {scheduler}");
            return Ok(scheduler);
        }

        // Update scheduler by id, receive Json update, returns updated scheduler
        [HttpPut("{id}", Name = "UpdateSchedulerById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SchedulerVo> UpdateSchedulerById(int id, SchedulerUpdateVo schedulerUpdateVo)
        {
            logger.LogInformation($"Update scheduler {id} to {schedulerUpdateVo}");
            var updatedScheduler = schedulerService.UpdateSchedulerById(id, schedulerUpdateVo);
            if (updatedScheduler == null)
            {
                logger.LogWarning($"can't update scheduler {id} not found.");
                return NotFound();
            }
            
            logger.LogInformation($"Updated scheduler {updatedScheduler}");
            return Ok(updatedScheduler);
        }

        // Create new scheduler, receive Json new, returns new scheduler
        [HttpPost(Name = "CreateScheduler")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<SchedulerVo> CreateScheduler(SchedulerCreationVo schedulerCreationVo)
        {
            logger.LogInformation($"Create new scheduler {schedulerCreationVo}");
            var newScheduler = schedulerService.CreateScheduler(schedulerCreationVo);
            logger.LogInformation($"Created new scheduler {newScheduler}");
            return CreatedAtRoute("GetSchedulerById", new { id = newScheduler.Id }, newScheduler);
        }
        
        // Delete scheduler by id, return NoContent
        [HttpDelete("{id}", Name = "DeleteSchedulerById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteSchedulerById(int id)
        {
            logger.LogInformation($"Delete scheduler by id: {id}");
            var deleted = schedulerService.DeleteSchedulerById(id);
            if (!deleted)
            {
                logger.LogWarning($"Delete scheduler {id} not found.");
                return NotFound();
            }
            
            logger.LogInformation($"Deleted scheduler {id}");
            return NoContent();
        }
    }
}
