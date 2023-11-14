using JWTtoken.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTtoken.DataAccess
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
    }
}
