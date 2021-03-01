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
        }

        public DbSet<Gym> Gyms { get; set; } = default!;

        public DbSet<Member> Members { get; set; } = default!;

        public DbSet<Instructor> Instructors { get; set; } = default!;

        public DbSet<Trainer> Trainers { get; set; } = default!;
    }
}
