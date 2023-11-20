using JwtToken2Project.Enums;

namespace JwtToken2Project.Interfaces
{
    public interface ITokenRepository
    {
        public string GenerateToken(string userName,Role role);
    }
}
