using System.Collections.Generic;
using Mr_XL_Graduation.Models;

namespace Mr_XL_Graduation.Services // Ensure this matches the namespace you are using
{
    public class UserService
    {
        // A dictionary to hold user credentials
        private readonly Dictionary<string, User> users = new()
        {
            { "Mr_xl", new User { Username = "Mr_xl", Password = "pass123", StudentId = "12345" } } // Example user
        };

        // A dictionary to hold student information
        private readonly Dictionary<string, Student> students = new()
        {
            { "12345", new Student { StudentId = "12345", FullName = "abdulrahman alkayail", Course = "Computer Science", Email = "mr_XL@example.com" } } // Example student
        };

        // Method to validate the user credentials
        public bool ValidateUser(string username, string password)
        {
            return users.TryGetValue(username, out var user) && user.Password == password;
        }

        // Method to get student info by username
        public Student GetStudentInfo(string username)
        {
            if (users.TryGetValue(username, out var user))
            {
                return students.TryGetValue(user.StudentId, out var student) ? student : null;
            }
            return null;
        }
    }
}
