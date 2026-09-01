using System.Threading;
using System;
using System.Runtime.InteropServices;

class Program
{

    //Main Thread:
    static void Main()
    {
        // Note that your program is the main thread.


        // Create a new thread and start it
        Thread t = new Thread(ThreadMethod1);
        t.Start();

        Thread t2 = new Thread(ThreadMethod2);
        t2.Start();

        //t2.Abort();
        
        //Blocks the calling thread until this thread terminates. 
        t.Join();
        t2.Join();


        // Main thread continues its execution
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Main Thread: " + i);
            //Sleep(): Suspends the thread for a specified duration
            Thread.Sleep(1000); // Sleep for 1 second
        }
        Console.ReadKey();
    }


    static void ThreadMethod1()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Thread Method1: " + i);
            Thread.Sleep(1000);
        }
    }

    static void ThreadMethod2()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Thread Method2: " + i);
            Thread.Sleep(1000);
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
