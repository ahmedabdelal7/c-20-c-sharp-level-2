using System;
using Microsoft.Win32;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string sourceName = "MyApp";

        //Required Privileges || Permissions
        if (!EventLog.SourceExists(sourceName))
        {
            EventLog.CreateEventSource(sourceName, "Application");
            Console.WriteLine("Event source created.");
        }

        //Write information
        EventLog.WriteEntry(sourceName,"This is my information!",EventLogEntryType.Information);

        //Write warning
        EventLog.WriteEntry(sourceName, "This is my warning!", EventLogEntryType.Warning);

        //Write Error
        EventLog.WriteEntry(sourceName, "This is my Error!", EventLogEntryType.Error);

        Console.ReadKey();
    }
}