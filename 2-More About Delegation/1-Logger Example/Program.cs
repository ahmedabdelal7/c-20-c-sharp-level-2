using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class Logger
{
    public delegate void LogAction(string message);

    private LogAction _LogAction;

    public Logger(LogAction logAction)
    {
        _LogAction = logAction;
    }

    public void Log(string message)
    {
        _LogAction(message);
    }
}


public class Program
{
    public static void LogToScreen(string message)
    {
        //logging to screen
        Console.WriteLine(message);
    }

    public static void LogToFile(string message)
    {
        //logging to file code
        string fileName = "log.text";

       using(StreamWriter streamWriter = new StreamWriter(fileName, true))
       {
           streamWriter.WriteLine(message);
       }

    }


    public static void LogToDataBase(string message)
    {
        //logging to Database code
        Console.WriteLine(message);

    }
    static void Main(string[] args)
    {

        Logger screenLogger = new Logger(LogToScreen);
        screenLogger.Log("Done logging to screen");

        Logger fileLogger = new Logger(LogToFile);
        fileLogger.Log($"Done logging to file, Date: {DateTime.Now}");


        Logger databaseLogger = new Logger(LogToDataBase);  
        databaseLogger.Log("Done logging to Database");

        Console.ReadKey();

    }
}
