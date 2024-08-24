using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        // Get all jobs, return List<Job>
        [HttpGet(Name = "GetAllJobs")]
        public IEnumerable<Job> GetAllJobs()
        {
            int pageSize = Convert.ToInt32(Request.Query["pageSize"]);
            int pageCount = Convert.ToInt32(Request.Query["pageCount"]);

            // Your code to get all jobs with pagination logic goes here
            return new List<Job>();
        }

        // Get job by id, return Job
        [HttpGet("{id}", Name = "GetJobById")]
        public IActionResult GetJobById(int id)
        {
            // Your code to get job by id goes here

            return Ok();
        }

        // Update job by id, receive Json update, returns updated job
        [HttpPut("{id}", Name = "UpdateJobById")]
        public IActionResult UpdateJobById(int id, [FromBody] Job job)
        {
            // Your code to update job by id using the updateModel goes here

            return Ok();
        }
        
    }
}
