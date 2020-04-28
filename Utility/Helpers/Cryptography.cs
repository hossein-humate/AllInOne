using System;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Helpers
{
    public static class Cryptography
    {
        public static byte[] CreatePasswordHash(string input, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        public static bool CheckValidInput(string input, byte[] existHash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != existHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string GenerateApiKey()
        {
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
}
