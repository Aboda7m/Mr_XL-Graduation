using System.Collections.Generic;

namespace Mr_XL_Graduation.Services // Ensure this matches the namespace you are using
{
    public class UserService
    {
        // A dictionary to hold user credentials
        private readonly Dictionary<string, string> users = new()
        {
            { "Mr_xl", "pass123" } // Example user
        };

        // Method to validate the user credentials
        public bool ValidateUser(string username, string password)
        {
            return users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }
    }
}
