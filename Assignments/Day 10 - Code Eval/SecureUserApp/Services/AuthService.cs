using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SecureUserApp.Models;

namespace SecureUserApp.Services
{
    public class AuthService
    {
        // In-memory user storage
        private static List<User> users = new List<User>();

        // Hash password using SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Register new user
        public static void Register(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            users.Add(new User(username, hashedPassword));
        }

        // Authenticate user
        public static bool Authenticate(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            var user = users.FirstOrDefault(u => u.Username == username);

            return user != null && user.HashedPassword == hashedPassword;
        }
    }
}