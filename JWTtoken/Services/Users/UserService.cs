using JWTtoken.DataAccess;
using JWTtoken.Entities;
using JWTtoken.Enums;
using JWTtoken.Models;
using JWTtoken.Services.Security;
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

        public async ValueTask<bool> CreateAsync(UserCreateDto userModel)
        {
            Users user = new Users();
            user.UserName = userModel.UserName;
            user.PasswordHash = Hash512.ComputeHash512(userModel.Password);
            user.Role = (Role)userModel.Role;

            await _context.Users.AddAsync(user);
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async ValueTask<IEnumerable<Users>> GetAllUsersAsync()
        {
            IEnumerable<Users> users = await _context.Users.ToListAsync();

            return users;
        }
    }
}
