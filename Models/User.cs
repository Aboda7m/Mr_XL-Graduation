using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        // You can add common properties for all users here
        public bool IsAdmin { get; set; } // Flag to indicate if the user is an admin
    }

    // Student class inherits from User
    public class Student : User
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Student ID must be a 10-digit number.")]
        public string StudentId { get; set; }

        // Properties for student-specific information
        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }

        public string Course { get; set; } // Use "Course" as a property for clarity
    }

    // Admin class inherits from User
    public class Admin : User
    {
        [Required]
        public string AdminId { get; set; }

        // Additional admin-specific properties can be added here
    }
}
