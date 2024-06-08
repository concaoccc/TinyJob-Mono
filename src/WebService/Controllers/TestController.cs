using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }

        [Route("/error/test")]
        [HttpGet]
        public IActionResult Test()
        {
            throw new Exception("test");
        }
    }
}
