using Microsoft.EntityFrameworkCore;
using Mr_XL_Graduation.Models;

namespace Mr_XL_Graduation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify precision and scale for the Balance property
            modelBuilder.Entity<Student>()
                .Property(s => s.Balance)
                .HasColumnType("decimal(18,2)") // 18 total digits, 2 decimal places
                .IsRequired(); // Ensure Balance cannot be null

            // Additional configurations for User model can be added here
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired(); // Ensure Username cannot be null

            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithMany()
                .HasForeignKey(u => u.StudentId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete behavior
        }
    }
}
