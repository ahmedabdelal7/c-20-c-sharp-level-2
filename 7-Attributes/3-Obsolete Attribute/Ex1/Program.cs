

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
public class Test
{
    [Obsolete("Use NewMethod() instead.")]          //Warring
    //[Obsolete("Use NewMethod() instead.",true)]   //Error
    public void OldMethod()
    {
        Console.WriteLine("This is OldMethod");
    }

    public void NewMethod()
    {
        Console.WriteLine("This is NewMethod");
    }
}

class Program
{

    static void Main()
    {
        Test test = new Test();

        test.OldMethod();

        test.NewMethod();

        Console.ReadKey();
    }
}


