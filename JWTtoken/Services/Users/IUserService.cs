using JWTtoken.Entities;

namespace JWTtoken.Services.User
{
    public interface IUserService
    {
        public ValueTask<IEnumerable<Users>> GetAllUsersAsync();
    }
}
