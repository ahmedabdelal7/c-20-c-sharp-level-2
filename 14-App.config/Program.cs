using System;
using System.Configuration;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
            string LogLevel = ConfigurationManager.AppSettings.Get("LogLevel");
            string Koko = ConfigurationManager.AppSettings["Koko"];

            string ConnectionString2 = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            Console.WriteLine(ConnectionString);
            Console.WriteLine(LogLevel);
            Console.WriteLine(Koko);
            Console.WriteLine(ConnectionString2);


            Console.ReadKey();
        }


    }


}
