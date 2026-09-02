using System;

//Task Parallel Library (TPL).
using System.Threading.Tasks;
using System.IO;

class Program
{
    static async Task Main()
    {
        // Create and run an asynchronous task
        Task<bool> resultTask = PerformAsyncOperation();

        // Do some other work while waiting for the task to complete
        Console.WriteLine("Doing some other work...");


        // Wait for the task to complete and retrieve the result
        bool result = await resultTask;

        // Process the result
        Console.WriteLine($"Result: {result}");
        Console.ReadKey();
    }


    static async Task<bool> PerformAsyncOperation()
    {
        // Simulate an asynchronous operation
        //await Task.Delay(4000);

        Console.WriteLine("Start Writing to file task..... I will do something else while writing task finish.");
        await Task.Run(() => { WriteToFIle();});
        Console.WriteLine("Done Writing to file.");

        // Return a result
        return true;
    }

    static void WriteToFIle()
    {
        File.WriteAllText("file.txt",
            "***************************" +
            "***************************" +
            "***************************");
    }
}