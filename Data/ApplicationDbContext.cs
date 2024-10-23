using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mr_XL_Graduation.Models;

namespace Mr_XL_Graduation.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify precision and scale for the Balance property
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Balance)
                      .HasColumnType("decimal(18,2)") // Ensure Balance has decimal precision
                      .HasDefaultValue(0); // Default value to prevent null
            });

            // Specify seeding data for Student
            var hasher = new PasswordHasher<Student>();

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = "1",
                    UserName = "Mr_xl",
                    PasswordHash = hasher.HashPassword(null, "pass123"), // Hash the password
                    StudentId = "0000000000",
                    FullName = "Abdulrahman Alkayail",
                    Email = "mr_XL@example.com",
                    Balance = 0,
                    Course = "Computer Science"
                });

            // Specify seeding data for Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = "2",
                    UserName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "Admin"), // Hash the password
                    AdminId = "1999000001",
                    Email = "admin@example.com"
                });
        }
    }
}
