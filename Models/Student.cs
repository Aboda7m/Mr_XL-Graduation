using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Student ID must be a 10-digit number.")]
    public string StudentId { get; set; }

    [Required]
    public string FullName { get; set; }

    public string Email { get; set; }

    public decimal Balance { get; set; }

    // Rename this property if you decide to change it to Major
    public string Course { get; set; } // or public string Major { get; set; }
}
