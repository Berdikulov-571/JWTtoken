using JwtToken2Project.DataAccess;
using JwtToken2Project.DTOs;
using JwtToken2Project.Entities;
using JwtToken2Project.Enums;
using JwtToken2Project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JwtToken2Project.Services
{
    public class UserService : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async ValueTask<User> CheckLogin(string UserName, string Password)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == UserName && x.PasswordHash == Hash512.ComputeHash512(Password));

            return user;
        }

        public async ValueTask CreateAsync(UserCreateDto model)
        {
            User user = new User();
            user.UserName = model.UserName;
            user.PasswordHash = Hash512.ComputeHash512(model.Password);
            user.Role = (Role)model.Role;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async ValueTask<IEnumerable<User>> GetAllAsync()
        {
            IEnumerable<User> users = await _context.Users.ToListAsync();

            return users;
        }
    }
}
