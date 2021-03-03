using Microsoft.EntityFrameworkCore;

namespace Swole.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<GymEmployee>()
                .HasKey(e => new { e.GymId, e.EmployeeId });

            modelBuilder
                .Entity<GymMember>()
                .HasKey(e => new { e.GymId, e.MemberId });
        }

        public DbSet<Gym> Gyms { get; set; } = default!;

        public DbSet<Member> Members { get; set; } = default!;

        public DbSet<Employee> Employees { get; set; } = default!;
    }
}
