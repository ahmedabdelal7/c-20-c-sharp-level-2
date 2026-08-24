


using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class MyCustomAttribute : Attribute
{

    public string Description { get; }

    public MyCustomAttribute(string description) 
    {
        Description = description;
    }
}

class Program
{
    [MyCustom("This is my custom attribute.")]
    public static void MyMethod()
    {
    }
    static void Main()
    {
        

        Console.ReadKey();
    }
}


