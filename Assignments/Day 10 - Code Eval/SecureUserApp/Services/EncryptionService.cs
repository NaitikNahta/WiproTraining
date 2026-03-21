using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureUserApp.Services
{
    public class EncryptionService
    {
        // 16 byte key & IV for AES (for demo purpose only)
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}