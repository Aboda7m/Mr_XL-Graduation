using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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
            // Seed data for the students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = "0000000000", // Regular user student ID
                    FullName = "abdulrahman alkayail",
                    Email = "mr_XL@example.com",
                    Balance = 0,
                    Course = "Computer Science"
                });

            // Temporarily remove the admin user and its student entry
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "Mr_xl",
                    Password = HashPassword("pass123"), // Hash password here
                    StudentId = "0000000000", // Regular user student ID
                    IsAdmin = true
                });
        }

        // Helper method to hash the password without using DI
        private static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<User>(); // Create a new PasswordHasher
            var user = new User(); // Temporary User object for hashing
            return passwordHasher.HashPassword(user, password);
        }
    }
}
