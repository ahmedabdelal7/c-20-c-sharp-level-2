using System;
using System.Configuration;
using System.Diagnostics;
using System.Text;
namespace ConsoleApp1
{
    internal class Program
    {
        public static string ConcatenatingString(int iterations)
        {
            string myStr = "";
            for (int i = 0; i < iterations; i++)
            {
                myStr += "0";
            }
            return myStr;
        }

        public static string ConcatenatingStringBuilder(int iterations)
        {
            string myStr = "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("0");
            }
            return myStr;
        }
        static void Main(string[] args)
        {
            int iterations = 200000;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ConcatenatingString(iterations);
            Console.WriteLine($"Time for ConcatenatingString: {stopwatch.Elapsed.Milliseconds.ToString()} ms");
            stopwatch.Stop();

            stopwatch.Reset();

            stopwatch.Start();
            ConcatenatingStringBuilder(iterations);
            Console.WriteLine($"Time for ConcatenatingStringBuilder: {stopwatch.Elapsed.Milliseconds.ToString()} ms");
            stopwatch.Stop();



            Console.ReadKey();
        }


    }


}
