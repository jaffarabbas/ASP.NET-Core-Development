using JWT_Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using TRACKIT_BACKEND_API.Dtos;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtAuthentictionContext _context;
        private readonly JWTSetting _setting;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        public UserController(JwtAuthentictionContext context,IOptions<JWTSetting> settings,IRefreshTokenGenerator refreshTokenGenerator)
        {
            this._context = context;
            this._setting = settings.Value;
            this._refreshTokenGenerator = refreshTokenGenerator;
        }

        [NonAction]
        public TokenResponse Authenticate(string username, Claim[] claims)
        {
            TokenResponse tokenResponce = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(_setting.securitykey);
            var tokenHandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256)
                );
            tokenResponce.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenHandler);
            tokenResponce.RefreshToken = _refreshTokenGenerator.GenerateToken(username);
            return tokenResponce;
        }
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            TokenResponse response = new TokenResponse();
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
                            //roles
                            new Claim(ClaimTypes.Role,_user.Role)
                    }
                ),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey
                ), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenHandler.WriteToken(token);
            response.JWTToken = finaltoken;
            response.RefreshToken = _refreshTokenGenerator.GenerateToken(user.username);
            return new ApiHitResponse<TokenResponse>(response,"Success");
        }

        [Route("Refresh")]
        [HttpPost]
        public ActionResult Refresh([FromBody] TokenResponse response)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principle = tokenHandler.ValidateToken(response.JWTToken,new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setting.securitykey)),
                ValidateIssuer = false,
                ValidateAudience = false
            },out securityToken);
            var _token = securityToken as JwtSecurityToken;

            if(_token != null && !_token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return Unauthorized();
            }
            var username = principle.Identity.Name;
            Console.WriteLine("username : "+ username);
            var _reftable = _context.TblRefreshtokens.FirstOrDefault(data => data.UserId == username && data.RefreshToken == response.RefreshToken);
            if (_reftable == null)
            {
                return Unauthorized();
            }
            TokenResponse _result = Authenticate(username, principle.Claims.ToArray());
            Console.WriteLine("result : "+ _result);
            return Ok(_result);
        }
    }
}
