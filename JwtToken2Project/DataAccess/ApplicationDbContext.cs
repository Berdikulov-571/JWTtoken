using JwtToken2Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtToken2Project.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
