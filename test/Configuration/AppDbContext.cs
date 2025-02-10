using Microsoft.EntityFrameworkCore;
using test.Model;

namespace test.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
<<<<<<< HEAD
        public DbSet<User>? User { get; set; }
        public DbSet<SocialHouse> SocialHouses { get; set; }
        public DbSet<SocialHouseImages> SocialHouseImages { get; set; }
=======
        public DbSet<Register>? Register { get; set; }
        public DbSet<Flat>? Flat { get; set; }
>>>>>>> 109d3edcfd41e74e4c5a283859539bcc0d1e192a
    }
}
