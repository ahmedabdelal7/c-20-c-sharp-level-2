using System;
using System.Security.Cryptography;
using System.Text;


class Program
{
    static void Main()
    {
        // Input data
        string data = "1222";


        // Compute the SHA-256 hash of the input data
        string hashedData = ComputeHash(data);



        // Display the original data and its hash
        Console.WriteLine($"Original Data: {data}");
        Console.WriteLine();
        Console.WriteLine($"Hashed Data SHA256: {hashedData} \n--size: {hashedData.Length} bit" );



        // Pause to keep the console window open for viewing the results
        Console.ReadKey();
    }

    static string ComputeHash(string input)
    {
        //  SHA is Secured Hash Algorithm.
        //  Create an instance of the SHA-256 algorithm
        using (SHA256 sha256 = SHA256.Create())
        {
            // Compute the hash value from the UTF-8 encoded input string
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


            // Convert the byte array to a lowercase hexadecimal string
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
   
}
