using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;
using TinyJobApi.Services;
using TinyJobApi.Services.Mock;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        // Get all packages, return List<Package>
        [HttpGet(Name = "GetAllPackages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Package>>> GetAllPackages()
        {
            return Ok(await _packageService.GetAllPackagesAsync());
        }

        // Get package by id, return Package
        [HttpGet("{id}", Name = "GetPackageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Job>> GetPackageById(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // Update package by id, receive Json update, returns updated package
        [HttpPut("{id}", Name = "UpdatePackageById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Job>> UpdatePackageById(int id, [FromBody] Package package)
        {
            if (package == null || package.Id != id)
            {
                return BadRequest();
            }

            var updatedPackage = await _packageService.UpdatePackageByIdAsync(id, package);
            if (updatedPackage == null)
            {
                return NotFound();
            }

            return Ok(updatedPackage);
        }

        // Create new package, receive Json new, returns new package
        [HttpPost(Name = "CreatePackage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Package>> CreatePackage(Package package)
        {
            if (package == null)
            {
                return BadRequest();
            }

            var newPackage = await _packageService.CreatePackageAsync(package);
            return CreatedAtRoute("GetPackageById", new { id = newPackage.Id }, newPackage);
        }
    }
}
