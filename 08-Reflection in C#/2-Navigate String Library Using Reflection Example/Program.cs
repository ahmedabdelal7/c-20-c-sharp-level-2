using System;
using System.Linq;
using System.Reflection;
using System.Web;


class Program
{
    static void Main()
    {
        // Get the assembly containing the System.String type
        Assembly msCorLib = typeof(string).Assembly;


        // Get the System.String type
        Type stringType = msCorLib.GetType("System.String");


        if (stringType != null)
        {
            Console.WriteLine($"Methods of the System.String class:\n");


            // Get all public methods of the System.String class
            var stringMethods = stringType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(method => method.Name);


            foreach (var method in stringMethods)
            {
                Console.WriteLine($"\t{method.ReturnType} {method.Name}({GetParameterList(method.GetParameters())})");
            }
        }
        else
        {
            Console.WriteLine("System.String type not found.");
        }


        Console.ReadKey();


    }


    static string GetParameterList(ParameterInfo[] parameters)
    {
        return string.Join(", ", parameters.Select(parameter => $"{parameter.ParameterType} {parameter.Name}"));
    }


    //
    //  Without using Assembly:
    //

    //static void Main()
    //{
    //    Type type = typeof(string);

    //    if (type != null) { 

    //        var stringMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
    //            .OrderBy(method => method.Name);

    //        foreach(var method in stringMethods)
    //        {
    //            Console.WriteLine($"\t{method.ReflectedType} {method.Name} ({GetParametersList(method.GetParameters())})");
    //        }

    //    }

    //    Console.ReadKey();

    //}

}