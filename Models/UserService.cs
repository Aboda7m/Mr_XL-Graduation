using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mr_XL_Graduation.Data;
using Mr_XL_Graduation.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Mr_XL_Graduation.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        // Method to validate user credentials asynchronously
        public async Task<User> ValidateUserAsync(string username, string password, string userType)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
                if (result == PasswordVerificationResult.Success)
                {
                    if ((userType == "Admin" && user.IsAdmin) || (userType == "Student" && !user.IsAdmin))
                    {
                        return user;
                    }
                }
            }

            return null; // Return null for invalid credentials
        }

        // Method to register a new student asynchronously
        public async Task<RegistrationResult> RegisterStudentAsync(string fullName, string email, string username, string password, string studentId, string course)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
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
                Course = course
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return new RegistrationResult { IsSuccess = true };
        }

        public async Task<Student> GetStudentAsync(string username)
        {
            return await _context.Students.SingleOrDefaultAsync(s => s.Username == username);
        }

        private string HashPassword(string password)
        {
            var user = new User(); // Use an empty user object for hashing
            return _passwordHasher.HashPassword(user, password);
        }

        // Method to get all students asynchronously
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        // Method to update the balance of a student asynchronously
        public async Task UpdateStudentBalanceAsync(string username, decimal newBalance)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Username == username);
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

        public async Task UpdateStudentBillsAsync(string username, decimal newBillsAmount)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Username == username);
            if (student != null)
            {
                student.Bills = newBillsAmount;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Student not found.");
            }
        }


        public async Task PayBillsAsync(string username, decimal paymentAmount)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Username == username);
            if (student != null)
            {
                if (paymentAmount <= student.Balance)
                {
                    student.Balance -= paymentAmount;
                    student.Bills -= paymentAmount;

                    if (student.Bills < 0)
                    {
                        student.Bills = 0; // Ensure bills don't go below 0
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Insufficient balance to pay the bills.");
                }
            }
            else
            {
                throw new Exception("Student not found.");
            }
        }

    }

    public class RegistrationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
