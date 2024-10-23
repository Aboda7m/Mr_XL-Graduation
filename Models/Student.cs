using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }
    }
}
