using JWT_Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtAuthentictionContext _context;
        private readonly JWTSetting _setting;
        public UserController(JwtAuthentictionContext context)
        {
            this._context = context;
        }
        [Route("Authentication")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {

            return Ok();
        }
    }
}
