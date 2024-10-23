using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mr_XL_Graduation.Data;
using Mr_XL_Graduation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mr_XL_Graduation.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<Student> _passwordHasher;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Student>();
        }

        public async Task<Student> ValidateUserAsync(string username, string password)
        {
            var student = await _context.Students.SingleOrDefaultAsync(u => u.UserName == username);
            if (student != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(student, student.PasswordHash, password);
                if (result == PasswordVerificationResult.Success)
                {
                    return student;
                }
            }
            return null; // Return null for invalid credentials
        }

        public async Task<RegistrationResult> RegisterStudentAsync(string fullName, string email, string username, string password, string studentId, string course)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == username))
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
                UserName = username,
                StudentId = studentId,
                Course = course
            };

            student.PasswordHash = HashPassword(password);

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new RegistrationResult { IsSuccess = true };
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task UpdateStudentBalanceAsync(string username, decimal newBalance)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.UserName == username);
            if (student != null)
            {
                student.Balance = newBalance;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Student not found.");
            }
        }

        private string HashPassword(string password)
        {
            var student = new Student();
            return _passwordHasher.HashPassword(student, password);
        }
    }

    public class RegistrationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
