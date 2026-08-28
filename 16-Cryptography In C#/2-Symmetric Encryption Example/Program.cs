using System;
using System.Security.Cryptography;
using System.Text;


class Program
{
    static void Main()
    {
        // Original data
        string originalData = "Sensitive information";

        //8 bit = 1 byte & Character = 1 Byte.
        // Key for AES encryption (128-bit key) -> = (128 / 8) =  16 character
        //AES -> Advanced Encryption Standard
        string key = "1234567890123456"; // should be 16 character


        // Encrypt the original data
        string encryptedData = Encrypt(originalData, key);


        // Decrypt the encrypted data
        string decryptedData = Decrypt(encryptedData, key);


        // Display results
        Console.WriteLine($"Original Data: {originalData}");
        Console.WriteLine($"Encrypted Data: {encryptedData}");
        Console.WriteLine($"Decrypted Data: {decryptedData}");
        Console.ReadKey();
    }


    static string Encrypt(string plainText, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Set the key and IV for AES encryption
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[aesAlg.BlockSize / 8];


            // Create an encryptor
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


            // Encrypt the data
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }


                // Return the encrypted data as a Base64-encoded string
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }


    static string Decrypt(string cipherText, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Set the key and IV for AES decryption
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[aesAlg.BlockSize / 8];


            // Create a decryptor
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


            // Decrypt the data
            using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
            {
                // Read the decrypted data from the StreamReader
                return srDecrypt.ReadToEnd();
            }
        }
    }
}