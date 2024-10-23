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

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "Mr_xl",
                    Password = "pass123", // Remember to hash passwords in production!
                    StudentId = "0000000000" // Hardcoded StudentId with all zeros
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = "0000000000", // Hardcoded StudentId with all zeros
                    FullName = "abdulrahman alkayail", // Updated name
                    Email = "mr_XL@example.com", // Updated email
                    Balance = 0, // Initial balance
                    Course = "Computer Science" // Course/major information
                }
            );
        }
    }
}
