//#define DEBUG
//#define Koko

//We can also define -Symbols- from ->
//( R-Click on project - properties - build - conditional compilation symbols )

using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;


public class MyClass
{
    [Conditional("DEBUG")] //works in debug mode, and works in release if it be defined. 
    public void ConditionalMethod1()
    {
        Console.WriteLine("Conditional method 1 is executed");
    }

    [Conditional("Koko")]
    //Works in all modes only if it be defined.
    public void ConditionalMethod2()
    {
        Console.WriteLine("Conditional method 2 is executed");
    }

    public void NormalMethod()
    {
        Console.WriteLine("Normal method is executed");
    }
}

class Program
{
    static void Main()
    {
        MyClass class1 = new MyClass();

        class1.NormalMethod();
        class1.ConditionalMethod1();
        class1.ConditionalMethod2();

        Console.ReadKey();
    }
}


