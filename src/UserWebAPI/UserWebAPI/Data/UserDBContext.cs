using Microsoft.EntityFrameworkCore;
using UserWebAPI.Data.Configuration;
using UserWebAPI.Models;

namespace UserWebAPI.Data
{
    public class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
