using Microsoft.AspNetCore.Identity;
using Prexam.Models;

namespace Prexam.Utils
{
    public class PasswordHelper
    {
        private readonly PasswordHasher<User> passwordHasher = new();

        public string HashPassword(User user, string password)
        {
            return passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string password, string hashPassword)
        {
            var result = passwordHasher.VerifyHashedPassword(user, hashPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}