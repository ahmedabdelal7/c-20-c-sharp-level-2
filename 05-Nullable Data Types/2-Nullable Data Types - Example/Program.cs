using System;
using System.Data.SqlClient;

using c = System.Console;
public class Program
{

    static void Procedure1(string Name, Nullable<int> Age)
    {
        c.WriteLine("Name Is : " + Name);

        if (Age.HasValue)
        {
            c.WriteLine("Age Is: "+Age.Value);
        }
        else
        {
            c.WriteLine("Age Is: Null");
        }
    }
    
    static void Procedure2(string Name, int? Age)
    {
        c.WriteLine("Name Is : " + Name);

        //string age = Age?.ToString();

        c.WriteLine($"Age Is: {Age?.ToString() ?? "Null"}");

        //if (Age.HasValue)
        //{
        //    c.WriteLine("Age Is: " + Age.Value);
        //}
        //else
        //{
        //    c.WriteLine("Age Is: Null");
        //}
    }

    static void Main(string[] args)
    {
        Procedure1("Ahmed Abdelaal",null);
        Procedure1("Ahmed Abdelaal",22);
        c.WriteLine();
        Procedure2("Ahmed Abdelaal", null);
        Procedure2("Ahmed Abdelaal", 22);


        c.ReadKey();

    }
}