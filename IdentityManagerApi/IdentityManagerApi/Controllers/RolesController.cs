using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User,Admin")]
    public class RolesController : ControllerBase
    {
        [HttpGet("Admin")]
        public IActionResult GetAdmin()
        {
            return Ok("Is Admin");
        }

        [HttpGet("User")]
        public IActionResult GetUser()
        {
            return Ok("Is User");
        }
    }
}
