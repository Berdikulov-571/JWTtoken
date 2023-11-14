namespace JWTtoken.Services.Auth
{
    public interface IAuthService
    {
        public string GenerateToken(string userName);
    }
}
