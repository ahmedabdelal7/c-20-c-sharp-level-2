using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

class Program
{

    static void Main()
    {

        Console.WriteLine("Starting threads...");

        Thread t1 = new Thread(() => DownloadAndPrint("https://cnn.com/"));
        t1.Start();
        Console.WriteLine("Thread 1 started...");

        Thread t2 = new Thread(() => DownloadAndPrint("https://www.amazon.com"));
        t2.Start();
        Console.WriteLine("Thread 2 started...");

        Thread t3 = new Thread(() => DownloadAndPrint("https://www.programmingadvices.com/"));
        t3.Start();
        Console.WriteLine("Thread 3 started...\n");


        t1.Join();
        t2.Join();
        t3.Join();


        Console.WriteLine("\nDone all threads finished execution.");
        Console.ReadKey();

    }

    static void DownloadAndPrint(string url)
    {
        string content;

        using (WebClient client = new WebClient())
        {
            //Fix remote server return error
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            // Simulate some work by adding a delay
            Thread.Sleep(100);
            // Download the content of the web page
            content = client.DownloadString(url);
        }

        Console.WriteLine($"{url}: {content.Length} characters downloaded");


    }
}
