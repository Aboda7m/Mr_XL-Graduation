using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mr_XL_Graduation.Data;
using Mr_XL_Graduation.Models;
using System.Linq;

namespace Mr_XL_Graduation.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to validate user credentials
        public bool ValidateUser(string username, string password, out bool isAdmin)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
                isAdmin = user.IsAdmin;
                return result == PasswordVerificationResult.Success;
            }

            isAdmin = false;
            return false;
        }

        // Method to register a new student
        public RegistrationResult RegisterStudent(string fullName, string email, string username, string password, string studentId, string course)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                return new RegistrationResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Username already exists."
                };
            }

            var student = new Student
            {
                FullName = fullName,
                Email = email,
                Username = username,
                StudentId = studentId,
                Password = HashPassword(password),
                Course = course // Add course
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return new RegistrationResult { IsSuccess = true };
        }

        public Student GetStudent(string username)
        {
            return _context.Students.SingleOrDefault(s => s.Username == username);
        }

        private string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            var user = new User();
            return passwordHasher.HashPassword(user, password);
        }
    }

    public class RegistrationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
