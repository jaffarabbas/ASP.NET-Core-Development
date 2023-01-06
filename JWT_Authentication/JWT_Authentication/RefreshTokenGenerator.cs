using JWT_Authentication.Models;
using System.Security.Cryptography;

namespace JWT_Authentication
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private readonly JwtAuthentictionContext _context;
        public RefreshTokenGenerator(JwtAuthentictionContext context) {
            _context = context;
        }

        public string GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create()) { 
                randomnumbergenerator.GetBytes(randomnumber);
                string RefreashToken = Convert.ToBase64String(randomnumber);
                var _user = _context.TblRefreshtokens.FirstOrDefault(data => data.UserId == username);
                if(_user != null)
                {
                    _user.RefreshToken = RefreashToken;
                    _context.SaveChanges();
                }
                else
                {
                    TblRefreshtoken tblRefreshtoken = new TblRefreshtoken()
                    {
                        UserId = username,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken = RefreashToken,
                        IsActive = true
                    };
                }
                return RefreashToken;
            }
        }
    }
}
