using System;
using Microsoft.Win32;

class Program
{
    static void Main()
    {
        // Writing on Local_Machine Registry need and permissions.

        /*
            Modifying the Windows Registry requires administrative privileges.
            Here's how to run your C# application with elevated permissions
            to write to the Local Machine Registry:

            1. Run Visual Studio as Administrator:
               - Right-click on the Visual Studio icon.
               - Select "Run as administrator."
               - This ensures that applications running from Visual Studio
                 inherit administrative privileges.

            2. Require Administrative Privileges in Your Application:
               - Add a manifest file to your C# project.
               - Create a file named "app.manifest" if it doesn't already exist.

            3. Add the following contents to the manifest file:

               <?xml version="1.0" encoding="utf-8"?>
               <assembly manifestVersion="1.0"
                         xmlns="urn:schemas-microsoft-com:asm.v1">
                 <assemblyIdentity version="1.0.0.0"
                                   processorArchitecture="X86"
                                   name="YourAppName"
                                   type="win32" />
                 <trustInfo xmlns="urn:schemas-microsoft-com:asm.v2">
                   <security>
                     <requestedPrivileges>
                       <requestedExecutionLevel
                           level="requireAdministrator"
                           uiAccess="false" />
                     </requestedPrivileges>
                   </security>
                 </trustInfo>
               </assembly>

               Replace "YourAppName" with the actual name of your application.

            4. Embed the Manifest in Your Application:
               - Open Project Properties in Visual Studio.
               - Go to the "Application" tab.
               - Set "Manifest" to the path of your "app.manifest" file.

            Now, whenever you run your application, Windows will request
            administrative privileges through UAC.

            This gives your application the required permissions to write
            to protected locations such as HKEY_LOCAL_MACHINE in the Registry.
*/

        string keyPath = @"HKEY_LOCAL_MACHINE\Software\MySoftware"; //  Error: Access Denied.
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