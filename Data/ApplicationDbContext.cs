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

        // Define DbSets for your models (tables)
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        // Add other DbSets for new models like Schedule, Payments, etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and database constraints if necessary
        }
    }
}
