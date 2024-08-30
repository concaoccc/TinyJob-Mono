using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // Get all jobs, return List<Job>
        [HttpGet(Name = "GetAllJobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<JobVo>>> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            var JobVos = jobs.Select(job => new JobVo(job)).ToList();
            // Your code to get all jobs with pagination logic goes here
            return Ok(JobVos);
        }

        // Get job by id, return Job
        [HttpGet("{id}", Name = "GetJobById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JobVo>> GetJobById(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job is null)
            {
                return NotFound();
            }

            return Ok(new JobVo(job));
        }

        // Update job by id, receive Json update, returns updated job
        [HttpPut("{id}", Name = "UpdateJobById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JobVo>> UpdateJobStatusById(int id, JobUpdateVo job)
        {
            if (job == null || job.Id != id)
            {
                return BadRequest();
            }

            var updatedJob = await _jobService.UpdateJobStatusByIdAsync(id, job.Status);
            if (updatedJob is null)
            {
                return NotFound();
            }

            return Ok(updatedJob.Value);
        }

    }
}
