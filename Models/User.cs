using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string StudentId { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }
}
