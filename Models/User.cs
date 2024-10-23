using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class Student : IdentityUser  // Inherit from IdentityUser
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Student ID must be a 10-digit number.")]
        public string StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Course { get; set; }

        public decimal Balance { get; set; }
    }

    public class Admin : IdentityUser  // Inherit from IdentityUser
    {
        [Required]
        public string AdminId { get; set; }

        // Admin-specific properties can be added here
    }
}
