using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HashingManager
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
        public static string HashPassword(string password)
        {
            // Rastgele bir salt oluşturun
            string salt = GenerateSalt();

            // Şifre ve salt'ı birleştirin
            string saltedPassword = string.Concat(password, salt);

            // Hash algoritması olarak PBKDF2'yi kullanarak şifreyi hashleyin
            string hashedPassword = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: saltedPassword,
                    salt: System.Text.Encoding.UTF8.GetBytes(salt),
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                )
            );

            return hashedPassword;
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            // Extract the salt from the stored hashed password
            byte[] saltBytes = Convert.FromBase64String(storedHashedPassword.Substring(0, 16));

            // Combine the entered password with the extracted salt
            string saltedPassword = string.Concat(enteredPassword, BitConverter.ToString(saltBytes));

            // Hash the entered password with the extracted salt
            string hashedPassword = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: saltedPassword,
                    salt: saltBytes,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                )
            );

            // Compare the stored hashed password with the newly hashed entered password
            return storedHashedPassword == hashedPassword;
        }



    }
}
