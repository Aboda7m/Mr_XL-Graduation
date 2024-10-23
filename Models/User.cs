using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } // Indicates if the user is an admin
    }

    public class Student : User
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Student ID must be a 10-digit number.")]
        public string StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }

        public string Course { get; set; }
    }

    public class Admin : User
    {
        [Required]
        public string AdminId { get; set; }

        // Additional admin-specific properties can be added here
    }
}
