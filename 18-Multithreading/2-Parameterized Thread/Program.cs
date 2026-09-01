using System.Threading;
using System;
using System.Runtime.InteropServices;

class Program
{

    //Main Thread:
    static void Main()
    {
        Thread t = new Thread(() => ThreadMethod1("Thread 1"));
        t.Start();//We can also send parameters for Start.

        Thread t2 = new Thread(() => DoWork("Thread 2", 6, 1000));
        t2.Start();

        t.Join();

        // Main thread continues its execution
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Main Thread: " + i);
            Thread.Sleep(1000); // Sleep for 1 second
        }
        Console.ReadKey();
    }


    static void ThreadMethod1(string ThreadName)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{ThreadName} Method1: " + i);
            Thread.Sleep(1000);
        }
    }

    static void DoWork(string threadName, int iterations, int sleepTime)
    {
        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine($"{threadName}: iteration number {i}");
            Thread.Sleep(sleepTime); // Simulate work
        }
    }
}

//Notes: 
/*
    Start(): Begins execution of the thread
    Join(): Blocks the calling thread until this thread terminates
    Sleep(): Suspends the thread for a specified duration
    Abort() (deprecated): Terminates the thread
    IsAlive: Property that indicates if the thread is running
    IsBackground: Property that determines if the thread is a background thread
    Name: Property to assign a name to the thread for debugging purposes
    Priority: Property to set the priority level of the thread
*/
