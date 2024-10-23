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
                    Username = "Mr_xl", // Assuming this is the username
                    Password = HashPassword("pass123"), // Store hashed password
                    StudentId = "0000000000", // Regular user student ID
                    FullName = "Abdulrahman Alkayail",
                    Email = "mr_XL@example.com",
                    Balance = 0,
                    Course = "Computer Science",
                    IsAdmin = false // Set IsAdmin flag
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Username = "Admin", // Admin username
                    Password = HashPassword("Admin"), // Store hashed password
                    AdminId = "1999000001", // Admin ID
                    IsAdmin = true // Set IsAdmin flag
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
