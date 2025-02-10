using Microsoft.EntityFrameworkCore;
using test.Model;

namespace test.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Register>? Register { get; set; }
        public DbSet<Flat>? Flat { get; set; }
    }
}
