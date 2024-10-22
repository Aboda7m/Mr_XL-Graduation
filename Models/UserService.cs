// Models/UserService.cs
using Mr_XL_Graduation.Models;

namespace Mr_XL_Graduation.Services
{
    public class UserService
    {
        private readonly User _user;

        public UserService()
        {
            // Initialize with a single user for demonstration purposes
            _user = new User
            {
                Username = "Mr_xl",
                Password = "pass123"
            };
        }

        public bool Authenticate(string username, string password)
        {
            return _user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                   _user.Password == password;
        }
    }
}
