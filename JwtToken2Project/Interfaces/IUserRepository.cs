using JwtToken2Project.DTOs;
using JwtToken2Project.Entities;

namespace JwtToken2Project.Interfaces
{
    public interface IUserRepository
    {
        ValueTask CreateAsync(UserCreateDto model);
        ValueTask<IEnumerable<User>> GetAllAsync();
        ValueTask<User> CheckLogin(string UserName,string Password);
    }
}
