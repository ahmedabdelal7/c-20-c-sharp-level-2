

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;



namespace TypeClass {
    class Program
    {
        static void Main()
        {
            /*
                 The Type class is a central class in reflection, representing a type in C#.
                 You can use it to get information about a type,
                 such as its methods, properties, fields, and events. 
            */

            Type type = typeof(Program);

            Console.WriteLine("\nProgram Class Information:");
            Console.WriteLine($"Is Class: {type.IsClass}");
            Console.WriteLine($"Class Name: {type.Name}");
            Console.WriteLine($"Class Full Name: {type.FullName}");
            Console.WriteLine($"Namespace: {type.Namespace}");

            Type typeStr = typeof(string);

            Console.WriteLine("\nProgram Class Information:");
            Console.WriteLine($"Is Class: {typeStr.IsClass}");
            Console.WriteLine($"Class Name: {typeStr.Name}");
            Console.WriteLine($"Class Full Name: {typeStr.FullName}");
            Console.WriteLine($"Namespace: {typeStr.Namespace}");


            Console.ReadKey();
        }

    }
}




