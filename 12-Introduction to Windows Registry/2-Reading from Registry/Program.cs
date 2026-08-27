using System;
using Microsoft.Win32;




class Program
{
    static void Main()
    {
        string keyPath = @"HKEY_CURRENT_USER\Software\MySoftware";
        //string keyPath = @"HKEY_LOCAL_MACHINE\Software\MySoftware"; 
        string valueName = "My_Value";
        
        try
        {
            string valueData = (string)Registry.GetValue(keyPath, valueName, null);
            if (valueData != null)
            {
                Console.WriteLine($"Value of {valueName} is: {valueData}");
            }
            else
            {
                Console.WriteLine($"The value {valueName}  Is not found in the registry!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }

        Console.ReadKey();
    }
}