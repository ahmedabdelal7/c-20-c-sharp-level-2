using System.Threading;
using System;

class Program
{
    static int sharedCounter = 0;
    static object lockObject = new object();


    static void Main()
    {
        // Create two threads that increment a shared counter
        Thread t1 = new Thread(() => IncrementCounter("T1"));
        Thread t2 = new Thread(() => IncrementCounter("T2"));


        t1.Start();
        t2.Start();


        // Wait for both threads to complete
        t1.Join();
        t2.Join();


        Console.WriteLine("Final Counter Value: " + sharedCounter);
        Console.ReadKey();
    }

    /*
     ثريد واحد يعدل عليه ويخلص بعدين يجي الثاني lock  الهدف من 
     يعنى تناوب مو انو لازم الثريد يخلص كلو بعدين يجي الثاني       
     */
    static void IncrementCounter(string ThreadName)
    {
        for (int i = 0; i < 10; i++)
        {
            // Use lock to synchronize access to the shared counter
            lock (lockObject)
            {
                sharedCounter++;

                Console.WriteLine(ThreadName + " : " + sharedCounter);
                Thread.Sleep(500);
            }
        }
    }
}