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

        public bool ValidateUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            // You should hash passwords before checking
            return user.Password == password;
        }

        public Student GetStudentInfo(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return null;

            return _context.Students.FirstOrDefault(s => s.StudentId == user.StudentId);
        }

        // New method for registering a user
        public (bool IsSuccess, string ErrorMessage) RegisterUser(string fullName, string email, string username, string password)
        {
            // Check if the username already exists
            if (_context.Users.Any(u => u.Username == username))
            {
                return (false, "This username is already taken.");
            }

            // Create a new User object
            var newUser = new User
            {
                Username = username,
                Password = password, // Hash this in production
                StudentId = Guid.NewGuid().ToString() // Generate a new StudentId or use an existing logic
            };

            // Create a new Student object
            var newStudent = new Student
            {
                StudentId = newUser.StudentId,
                FullName = fullName,
                Email = email,
                Balance = 0 // Default balance can be set to 0 or any initial value
            };

            // Add the new user to the context
            _context.Users.Add(newUser);
            _context.Students.Add(newStudent);
            _context.SaveChanges(); // Save changes to the database

            return (true, string.Empty);
        }

    }
}
