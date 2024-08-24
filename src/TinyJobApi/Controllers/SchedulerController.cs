using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;
using TinyJobApi.Services;
using TinyJobApi.Services.Mock;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly ISchedulerService _schedulerService;

        public SchedulerController()
        {
            _schedulerService = new MockSchedulerService();
        }

        // Get all schedulers, return List<Scheduler>
        [HttpGet(Name = "GetAllSchedulers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Scheduler>>> GetAllSchedulers()
        {
            // Your code to get all schedulers with pagination logic goes here
            return Ok(await _schedulerService.GetAllSchedulersAsync());
        }

        // Get scheduler by id, return Scheduler
        [HttpGet("{id}", Name = "GetSchedulerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Scheduler>> GetSchedulerById(int id)
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
        public Task<ActionResult<Scheduler>> UpdateSchedulerById(int id, Scheduler scheduler)
        {
            if (scheduler == null || scheduler.Id != id)
            {
                return Task.FromResult<ActionResult<Scheduler>>(BadRequest());
            }

            var updatedScheduler = _schedulerService.UpdateSchedulerByIdAsync(id, scheduler);
            if (updatedScheduler == null)
            {
                return Task.FromResult<ActionResult<Scheduler>>(NotFound());
            }

            return Task.FromResult<ActionResult<Scheduler>>(Ok(updatedScheduler));
        }

        // Create new scheduler, receive Json new, returns new scheduler
        [HttpPost(Name = "CreateScheduler")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateScheduler([FromBody] Scheduler scheduler)
        {
            if (scheduler == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
