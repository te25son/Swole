using Microsoft.EntityFrameworkCore;

namespace Swole.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Gym> Employees { get; set; }
    }
}
