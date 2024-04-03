using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtInDotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUnauthorizedHelloWorld()
        {
            return Ok("Hello World");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAuthorizeHelloWorld()
        {
            return Ok("Hello World");
        }
    }
}