using JWTtoken.DataAccess;
using JWTtoken.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTtoken.Services.User
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _context;
        public UserService(AuthDbContext context)
        {
            _context = context;
        }
        public async ValueTask<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
