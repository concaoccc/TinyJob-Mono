using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TinyJobApi.Database.Entity;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController(IJobService jobService, ILogger<JobController> logger) : ControllerBase
    {
        // Get all jobs, return List<Job>
        [HttpGet(Name = "GetAllJobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<JobVo>> GetAllJobs(int page = 1, int pageSize = 10)
        {
            logger.LogInformation($"Query all jobs with page {page}, pagesize {pageSize}.");
            var jobs = jobService.GetAllJobs(page, pageSize);
            logger.LogDebug($"Get all jobs: {JsonConvert.SerializeObject(jobs)}");
            return Ok(jobs);
        }

        // Get job by id, return Job
        [HttpGet("{id}", Name = "GetJobById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JobVo> GetJobById(int id)
        {
            logger.LogInformation($"Get job by id: {id}");
            var job = jobService.GetJobById(id);
            if (job is null)
            {
                logger.LogWarning($"Get job {id} not found.");
                return NotFound();
            }
            
            logger.LogInformation($"Get job {job}");
            return Ok(job);
        }

        // Update job by id, receive Json update, returns updated job
        [HttpPut("{id}", Name = "UpdateJobById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JobVo> UpdateJobStatusById(int id, JobStatus jobStatus)
        {
            logger.LogInformation($"update job {id} to {jobStatus}");
            var updatedJob = jobService.UpdateJobStatusById(id, jobStatus);
            if (updatedJob is null)
            {
                logger.LogWarning($"Update job {id} not found.");
                return NotFound();
            }

            logger.LogInformation($"Updated job {updatedJob}");
            return Ok(updatedJob);
        }
    }
}
