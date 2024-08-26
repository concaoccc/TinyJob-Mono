using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models.Vo;
using TinyJobApi.Services;

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
        public async Task<ActionResult<IEnumerable<PackageVo>>> GetAllPackages()
        {
            return Ok(await _packageService.GetAllPackagesAsync());
        }

        // Get package by id, return Package
        [HttpGet("{id}", Name = "GetPackageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PackageVo>> GetPackageById(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package is null)
            {
                return NotFound();
            }

            return Ok(package.Value);
        }

        // Update package by id, receive Json update, returns updated package
        [HttpPut("{id}", Name = "UpdatePackageById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PackageCreationVo>> UpdatePackageById(int id, PackageVo package)
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
        public async Task<ActionResult> CreatePackage(PackageCreationVo packageCreationVo)
        {
            if (packageVo == null)
            {
                return BadRequest();
            }

            var newPackage = await _packageService.CreatePackageAsync(package);
            return CreatedAtRoute("GetPackageById", new { id = newPackage.Id });
        }
    }
}
