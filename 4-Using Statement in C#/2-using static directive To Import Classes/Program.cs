using System;

//using System.Console; Error

//using directive static instead when we use classes
using static System.Console;
using static System.Math;

public class Program
{

    //Using to create an alias  

    static void Main(string[] args)
    {
        WriteLine("Hello World");

        double result =  Sqrt(10);

        WriteLine(result);

        ReadKey();

    }
}