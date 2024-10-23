using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class StudentInfo
    {
        [Key]
        public string StudentId { get; set; } // This ties the info back to the student

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal Balance { get; set; }

        // Course (or Major) details
        public string Course { get; set; }
    }
}
