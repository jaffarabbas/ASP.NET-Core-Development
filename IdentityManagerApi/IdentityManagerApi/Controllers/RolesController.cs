using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdmin()
        {
            return Ok("Is Admin");
        }

        [HttpGet("User")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetUser()
        {
            return Ok("Is User");
        }
    }
}
