using System;
using System.Net;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Security.Policy;

class Program
{
    static async Task Main()
    {

        Console.WriteLine("Starting tasks...");

        // Start the first task to download and print content length from CNN
        Task task1 = DownloadAndPrintAsync("https://www.cnn.com");
        Console.WriteLine("Task 1 started...");

        // Start the second task to download and print content length from Amazon
        Task task2 = DownloadAndPrintAsync("https://www.google.com");
        Console.WriteLine("Task 2 started...");

        // Start the third task to download and print content length from ProgrammingAdvices
        Task task3 = DownloadAndPrintAsync("https://www.ProgrammingAdvices.com");
        Console.WriteLine("Task 3 started...\n");

        // Wait for all tasks to complete
        await Task.WhenAll(task1, task2, task3);

        // Print a message indicating that all tasks have finished execution
        Console.WriteLine("\nDone, all tasks finished execution.");
        Console.ReadKey();
    }

    static async Task DownloadAndPrintAsync(string url)
    {

        string content;

        // Using statement ensures that the WebClient is disposed of properly
        using (WebClient client = new WebClient())
        {
            // Simulate some work by adding a delay
            await Task.Delay(100);

            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            //client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");

            // Download the content of the web page asynchronously
            content = await client.DownloadStringTaskAsync(url);
            //Invoke delegate.
        }

        // Print the URL and the length of the downloaded content
        Console.WriteLine($"{url}: {content.Length} characters downloaded");
    }
}
