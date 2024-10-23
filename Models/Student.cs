using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class Student
    {
        [Key]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Student ID must be a 10-digit number.")]
        public string StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }
    }
}
