using Microsoft.EntityFrameworkCore;
using test.Model;

namespace test.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<SocialHouse> SocialHouses { get; set; }
        public DbSet<SocialHouseImages> SocialHouseImages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Flat> Flat { get; set; }
    }
}
