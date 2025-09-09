using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem.utils
{
    public static class PasswordHasher
    {
        public static string Hash(string plainText)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert to hex string
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public static bool Verify(string password, string hashedPassword)
        {
            string hashOfInput = Hash(password);
            return hashOfInput == hashedPassword;
        }
    }
}
