using JWTtoken.Entities;
using JWTtoken.Models;

namespace JWTtoken.Services.User
{
    public interface IUserService
    {
        public ValueTask<IEnumerable<Users>> GetAllUsersAsync();
        public ValueTask<bool> CreateAsync(UserCreateDto userModel);
    }
}
