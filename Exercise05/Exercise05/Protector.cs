using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Exercise05
{
    public class Protector
    {
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");
        private static readonly int iterations = 2000;
        public static string Encrypt (string plainText, string password)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            Aes aes = Aes.Create();
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            MemoryStream ms = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
            };

            return Convert.ToBase64String(ms.ToArray());
        }

        public static User SaltAndHashPassword (string password)
        {
            // generate a random salt
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            string saltText = Convert.ToBase64String(saltBytes);
            // generate the salted and hashed password
            SHA256 sha = SHA256.Create();
            string saltedPassword = password + saltText;
            string saltedhashedPassword = Convert.ToBase64String(
            sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            User user = new User
            {
                Salt = saltText,
                SaltedHashedPassword = saltedhashedPassword
            };

            return user;
        }

        public class User
        {
            public string Salt { get; set; }
            public string SaltedHashedPassword { get; set; }
        }
    }
}
