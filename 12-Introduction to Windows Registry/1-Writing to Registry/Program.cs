using System;
using Microsoft.Win32;




class Program
{
    static void Main()
    {
        string keyPath = @"HKEY_CURRENT_USER\Software\MySoftware";
        //string keyPath = @"HKEY_LOCAL_MACHINE\Software\MySoftware"; //  Error: Access Denied.
        string valueName = "My_Value";
        string valueData = "My Value Data";

        try
        {
            Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);

            Console.WriteLine($"Value {valueName} successfully written to the Registry.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }

        Console.ReadKey();
    }
}