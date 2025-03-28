using System.Security.Cryptography;
using System.Text;

namespace WillPortfolio_Api;

public class Helper
{
    private static readonly string Key = "secret_key";
    
        private static byte[] GetValidKey()
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
            byte[] validKey = new byte[32]; 
            Array.Copy(keyBytes, validKey, Math.Min(keyBytes.Length, validKey.Length));

            return validKey;
        }

        public static string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetValidKey();
                aesAlg.GenerateIV();
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                    
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));

            byte[] fullCipher = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                // Set the key
                aesAlg.Key = GetValidKey();

                // Extract the IV from the beginning of the cipherText
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                byte[] cipher = new byte[fullCipher.Length - iv.Length];
                Array.Copy(fullCipher, iv, iv.Length);
                Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption
                using (var msDecrypt = new MemoryStream(cipher))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read the decrypted bytes from the decrypting stream and return as a string
                    return srDecrypt.ReadToEnd();
                }
            }
        }
        
}