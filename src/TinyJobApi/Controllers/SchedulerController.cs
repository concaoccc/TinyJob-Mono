using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        // Get all schedulers, return List<Scheduler>
        [HttpGet(Name = "GetAllSchedulers")]
        public IEnumerable<Scheduler> GetAllSchedulers()
        {
            int pageSize = Convert.ToInt32(Request.Query["pageSize"]);
            int pageCount = Convert.ToInt32(Request.Query["pageCount"]);

            // Your code to get all schedulers with pagination logic goes here
            return new List<Scheduler>();
        }

        // Get scheduler by id, return Scheduler
        [HttpGet("{id}", Name = "GetSchedulerById")]
        public IActionResult GetSchedulerById(int id)
        {
            // Your code to get scheduler by id goes here

            return Ok();
        }

        // Update scheduler by id, receive Json update, returns updated scheduler
        [HttpPut("{id}", Name = "UpdateSchedulerById")]
        public IActionResult UpdateSchedulerById(int id, [FromBody] Scheduler scheduler)
        {
            // Your code to update scheduler by id using the updateModel goes here

            return Ok();
        }

        // Create new scheduler, receive Json new, returns new scheduler
        [HttpPost(Name = "CreateScheduler")]
        public IActionResult CreateScheduler([FromBody] Scheduler scheduler)
        {
            // Your code to create new scheduler using the newModel goes here

            return Ok();
        }
    }
}
