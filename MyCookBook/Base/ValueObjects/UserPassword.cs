using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace mycookbook.cc.MyCookBook.Base.ValueObjects
{
    public class UserPassword
    {
        private string hashedPassword;

        private byte[] salt;

        private UserPassword(string hashedPassword, byte[] salt)
        {
            this.hashedPassword = hashedPassword;
            this.salt = salt;
        }

        public static UserPassword FromPlainText(string plainTextPassword)
        {
            var salt = UserPassword.GenerateSalt();
            var hashed = UserPassword.Hash(plainTextPassword, salt);
            return new UserPassword(hashed, salt);
        }

        public string ForDatabase()
        {
            return Convert.ToBase64String(this.salt, 0, this.salt.Length) + ":" + this.hashedPassword;
        }

        public static bool Compare(string fromDatabase, string plainTextPassword)
        {
            plainTextPassword = plainTextPassword.Trim();
            if (plainTextPassword.Length == 0) return false;

            var salt = Convert.FromBase64String(fromDatabase.Split(":")[0]);
            var hashedPassword = fromDatabase.Split(":")[1];

            var hashToCompare = UserPassword.Hash(plainTextPassword, salt);

            return hashToCompare == hashedPassword;
        }

        public static string RandomToken()
        {
            return Convert.ToBase64String(UserPassword.GenerateSalt());
        }

        // generate a 128-bit salt using a secure PRNG
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
        private static string Hash(string plainTextPassword, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainTextPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}