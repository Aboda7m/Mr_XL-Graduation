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

        // Other methods can be added for CRUD operations
    }
}
