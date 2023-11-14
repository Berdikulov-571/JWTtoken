using JWTtoken.Models;

namespace JWTtoken.Services.Auth
{
    public interface IAuthService
    {
        public string GenerateToken(UserCreateDto userModel);
    }
}
