namespace JWT_Authentication
{
    public interface IRefreshTokenGenerator
    {
        public string GenerateToken(string username);
    }
}
