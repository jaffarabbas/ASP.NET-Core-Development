using JWT_Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtAuthentictionContext _context;
        private readonly JWTSetting _setting;
        public UserController(JwtAuthentictionContext context,IOptions<JWTSetting> settings)
        {
            this._context = context;
            this._setting = settings.Value;
        }
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            var _user = this._context.TblUsers.FirstOrDefault(data => data.Userid == user.username && data.Password == user.password);
            if (_user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(this._setting.securitykey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                            new Claim(ClaimTypes.Name, _user.Userid),
                    }
                ),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey
                ), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenHandler.WriteToken(token);
            return Ok(finaltoken);
        }
    }
}
