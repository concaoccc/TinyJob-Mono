using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;
using TinyJobApi.Services;
using TinyJobApi.Services.Mock;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        
        public JobController(IJobService jobService) {
            _jobService = jobService;
        }

        // Get all jobs, return List<Job>
        [HttpGet(Name = "GetAllJobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Job>>> GetAllJobs()
        {
            // Your code to get all jobs with pagination logic goes here
            return Ok(await _jobService.GetAllJobsAsync());
        }

        // Get job by id, return Job
        [HttpGet("{id}", Name = "GetJobById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Job>> GetJobById(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // Update job by id, receive Json update, returns updated job
        [HttpPut("{id}", Name = "UpdateJobById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateJobStatusById(int id, Job job)
        {
            if (job == null || job.Id != id)
            {
                return BadRequest();
            }

            var updatedJob = await _jobService.UpdateJobStatusByIdAsync(id, job.Status);
            if (updatedJob == null)
            {
                return NotFound();
            }

            return Ok(updatedJob);
        }
        
    }
}
