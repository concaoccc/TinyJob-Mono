using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyJobApi.Models;

namespace TinyJobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        // Get all packages, return List<Package>
        [HttpGet(Name = "GetAllPackages")]
        public IEnumerable<Package> GetAllPackages()
        {
            int pageSize = Convert.ToInt32(Request.Query["pageSize"]);
            int pageCount = Convert.ToInt32(Request.Query["pageCount"]);

            // Your code to get all packages with pagination logic goes here
            return new List<Package>();
        }

        // Get package by id, return Package
        [HttpGet("{id}", Name = "GetPackageById")]
        public IActionResult GetPackageById(int id)
        {
            // Your code to get package by id goes here

            return Ok();
        }

        // Update package by id, receive Json update, returns updated package
        [HttpPut("{id}", Name = "UpdatePackageById")]
        public IActionResult UpdatePackageById(int id, [FromBody] Package package)
        {
            // Your code to update package by id using the updateModel goes here

            return Ok();
        }

        // Create new package, receive Json new, returns new package
        [HttpPost(Name = "CreatePackage")]
        public IActionResult CreatePackage([FromBody] Package package)
        {
            // Your code to create new package using the newModel goes here

            return Ok();
        }
    }
}
