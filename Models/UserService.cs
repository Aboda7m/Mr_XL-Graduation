using Microsoft.AspNetCore.Identity;
using Mr_XL_Graduation.Data;
using Mr_XL_Graduation.Models;
using System;
using System.Linq;
using System.Diagnostics; // Import for debugging

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

            // Verify the hashed password
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result == PasswordVerificationResult.Success;
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
            Debug.WriteLine("Starting user registration...");

            // Check if the username already exists
            if (_context.Users.Any(u => u.Username == username))
            {
                Debug.WriteLine($"Registration failed: Username '{username}' already exists.");
                return (false, "This username is already taken.");
            }

            // Generate new StudentId
            string studentId = GenerateStudentId();
            Debug.WriteLine($"Generated StudentId: {studentId}");

            // Create a new User object
            var passwordHasher = new PasswordHasher<User>();
            var newUser = new User
            {
                Username = username,
                Password = passwordHasher.HashPassword(new User(), password), // Hash the password
                StudentId = studentId,
                IsAdmin = false // Default value for IsAdmin, assuming new users are not admins
            };
            Debug.WriteLine($"New User created: Username = {newUser.Username}, StudentId = {newUser.StudentId}");

            // Create a new Student object
            var newStudent = new Student
            {
                StudentId = studentId,
                FullName = fullName,
                Email = email,
                Balance = 0, // Initialize Balance to 0
                Course = "Computer Science" // Set default Course
            };
            Debug.WriteLine($"New Student created: FullName = {newStudent.FullName}, Email = {newStudent.Email}, Course = {newStudent.Course}");

            try
            {
                // Add the new user and student to the context
                _context.Users.Add(newUser);
                _context.Students.Add(newStudent);
                Debug.WriteLine("Attempting to save changes to the database...");
                _context.SaveChanges(); // Save changes to the database
                Debug.WriteLine("User registration successful.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during registration: {ex.Message}");
                return (false, "An error occurred during registration. Please try again later.");
            }

            return (true, string.Empty);
        }


        private string GenerateStudentId()
        {
            // Hardcoding the year to 2024
            string currentYear = "2024";
            Debug.WriteLine($"Generating Student ID for the year: {currentYear}");

            // Get the highest student ID for the current year
            var lastStudentId = _context.Students
                .Where(s => s.StudentId.StartsWith(currentYear))
                .Select(s => s.StudentId)
                .OrderByDescending(id => id)
                .FirstOrDefault();

            // Log the last student ID found (if any)
            if (lastStudentId != null)
            {
                Debug.WriteLine($"Last Student ID found: {lastStudentId}");
            }
            else
            {
                Debug.WriteLine("No existing Student IDs found for the current year.");
            }

            // Extract the increment part and increment it
            int nextIncrement = 1; // Default to 1 if there are no existing IDs
            if (lastStudentId != null)
            {
                // Extract the last 6 digits and increment
                Debug.WriteLine($"Attempting to parse increment from last Student ID: {lastStudentId}");

                if (int.TryParse(lastStudentId.Substring(4), out int lastIncrement))
                {
                    nextIncrement = lastIncrement + 1; // Increment the last ID
                    Debug.WriteLine($"Parsed last increment: {lastIncrement}. Next increment will be: {nextIncrement}");
                }
                else
                {
                    // Handle the case where parsing fails
                    Debug.WriteLine("Failed to parse increment from last Student ID. Resetting next increment to 1.");
                    nextIncrement = 1;
                }
            }

            // Format the new student ID as YYYYXXXXXX (10 digits total)
            string newStudentId = $"{currentYear}{nextIncrement:D6}"; // Generates ID in the format YYYYXXXXXX
            Debug.WriteLine($"Generated new Student ID: {newStudentId}");

            return newStudentId;
        }

    }
}
