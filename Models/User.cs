using System.ComponentModel.DataAnnotations;

namespace Mr_XL_Graduation.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string StudentId { get; set; }

        // New property to indicate if the user is an admin
        public bool IsAdmin { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }

}
