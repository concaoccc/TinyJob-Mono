using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController(IPackageService packageService, ISchedulerService schedulerService, ILogger<PackageController> logger) : ControllerBase
    {
        // Get all packages, return List<Package>
        [HttpGet(Name = "GetAllPackages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PackageVo>> GetAllPackages(int page = 1, int pageSize = 10)
        {
            logger.LogInformation($"Query all packages with page {page}, pagesize {pageSize}.");
            var packages = packageService.GetAllPackages(page, pageSize);
            logger.LogDebug($"Get all packages: {JsonConvert.SerializeObject(packages)}");
            return Ok(packages);
        }

        // Get package by id, return Package
        [HttpGet("{id}", Name = "GetPackageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PackageVo> GetPackageById(int id)
        {
            logger.LogInformation($"Get package by id: {id}");
            var package = packageService.GetPackageById(id);
            if (package is null)
            {
                logger.LogWarning($"Get package {id} not found.");
                return NotFound();
            }
            
            logger.LogInformation($"Get package {package}");
            return Ok(package);
        }

        // Update package by id, receive Json update, returns updated package
        [HttpPut("{id}", Name = "UpdatePackageById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PackageVo> UpdatePackageById(int id, PackageUpdateVo packageUpdateVo)
        {
            var updatedPackage = packageService.UpdatePackageById(id, packageUpdateVo);
            if (updatedPackage == null)
            {
                logger.LogWarning($"Update package {id} not found.");
                return NotFound();
            }
            
            logger.LogInformation($"Updated package {updatedPackage}");
            return Ok(updatedPackage);
        }

        // Create new package, receive Json new, returns new package
        [HttpPost(Name = "CreatePackage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<PackageVo> CreatePackage(PackageCreationVo packageCreationVo)
        {
            var newPackage = packageService.CreatePackage(packageCreationVo);
            logger.LogInformation($"Create new package {newPackage}");
            return CreatedAtRoute("GetPackageById", new { id = newPackage.Id }, newPackage);
        }
        
        // Delete package by id
        [HttpDelete("{id}", Name = "DeletePackageById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeletePackageById(int id)
        {
            var package = packageService.GetPackageById(id);
            if (package == null)
            {
                return NotFound();
            }
            
            var relatedSchedulers = schedulerService.FindByPackageId(id);
            if (relatedSchedulers.Count > 0)
            {
                var schedulerNames = relatedSchedulers.Select(s => s.Name).ToList();
                return BadRequest($"Package {id} is used by schedulers: {string.Join(", ", schedulerNames)}");
            }
            
            packageService.DeletePackageById(id);
            return NoContent();
        }
    }
}
