using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly ISchedulerService _schedulerService;

        public SchedulerController(ISchedulerService schedulerService)
        {
            _schedulerService = schedulerService;
        }

        // Get all schedulers, return List<Scheduler>
        [HttpGet(Name = "GetAllSchedulers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SchedulerVo>>> GetAllSchedulers()
        {
            // Your code to get all schedulers with pagination logic goes here
            return Ok(await _schedulerService.GetAllSchedulersAsync());
        }

        // Get scheduler by id, return Scheduler
        [HttpGet("{id}", Name = "GetSchedulerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SchedulerVo>> GetSchedulerById(int id)
        {
            var scheduler = await _schedulerService.GetSchedulerByIdAsync(id);
            if (scheduler == null)
            {
                return NotFound();
            }

            return Ok(scheduler);
        }

        // Update scheduler by id, receive Json update, returns updated scheduler
        [HttpPut("{id}", Name = "UpdateSchedulerById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SchedulerVo>> UpdateSchedulerById(int id, Scheduler scheduler)
        {
            if (scheduler == null || scheduler.Id != id)
            {
                return BadRequest();
            }

            var updatedScheduler = await _schedulerService.UpdateSchedulerByIdAsync(id, scheduler);
            if (updatedScheduler == null)
            {
                return NotFound();
            }

            return Ok(updatedScheduler);
        }

        // Create new scheduler, receive Json new, returns new scheduler
        [HttpPost(Name = "CreateScheduler")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<SchedulerVo>> CreateScheduler(SchedulerCreationVo schedulerCreationVo)
        {
            if (schedulerCreationVo == null)
            {
                return BadRequest();
            }

            var newScheduler = await _schedulerService.CreateSchedulerAsync(scheduler);
            return CreatedAtRoute("GetSchedulerById", new { id = newScheduler.Id }, newScheduler);
        }
    }
}
