using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController(IPackageService packageService, ILogger<PackageController> logger) : ControllerBase
    {
        // Get all packages, return List<Package>
        [HttpGet(Name = "GetAllPackages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PackageVo>> GetAllPackages()
        {
            var packages = packageService.GetAllPackages();
            logger.LogInformation($"Get {packages.Count()} packages.");
            logger.LogDebug($"Get all packages: {packages}");
            return Ok(packageService.GetAllPackages());
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
    }
}
