using System;
using System.Numerics;

public class Utility
{
    public static T Swap<T>(ref T first, ref T second)
    {
        
        T temp =first;
        first = second;
        second = temp;
        return temp;
    }

    public static myType Add<myType> (myType a, myType b)
    {
        return (dynamic)a + (dynamic)b;
    }
}


class Program
{
    static void Main()
    {
        // Usage with integers
        int a = 5, b = 10;
        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        Utility.Swap(ref a, ref b);
        Console.WriteLine($"After swap: a = {a}, b = {b}");
        Console.WriteLine();


        // Usage with strings
        string x = "Hello", y = "World";
        Console.WriteLine($"Before swap: x = {x}, y = {y}");
        Utility.Swap(ref x, ref y);
        Console.WriteLine($"After swap: x = {x}, y = {y}");

        Console.WriteLine($"Add a,b : {Utility.Add<int>(a,b)}");
        Console.WriteLine($"Add x,y : {Utility.Add(x,y)}");


        Console.ReadKey();
    }
}

