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
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainTextPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return new UserPassword(hashed, salt);
        }

        public string ForDatabase()
        {
            return Encoding.UTF8.GetString(this.salt, 0, this.salt.Length) + ":" + this.hashedPassword;
        }
    }
}