using System;
using System.Data.SqlClient;

using c = System.Console;
public class Program
{


    static void Main(string[] args)
    {
        //Declare a Nullable int using ( Nullable<T> )
        Nullable<int> nullableInt1 = null;

        //Short-Hand notation using int? 
        int? nullableInt2 = null;

        nullableInt2 = 10;

        if (nullableInt1.HasValue) 
        {
            c.WriteLine("nullableInt1 has a value: {0}",nullableInt1.Value);
        }
        else
        {
            c.WriteLine("nullableInt1 has no value.");

        }
        c.WriteLine();

        if (nullableInt2.HasValue)
        {
            c.WriteLine("nullableInt2 has a value: {0}", nullableInt2.Value);
        }
        else
        {
            c.WriteLine("nullableInt2 has no value.");

        }

        // Using the null-coalescing operator 
        int result = nullableInt2 ?? 0;
        c.WriteLine("Using null-coalescing operator: " + result);


        // Using the null-conditional operator (?.)
        string stringValue = nullableInt2?.ToString();
        Console.WriteLine("String representation: " + (stringValue ?? "null"));

        /****************************************************************/

        DateTime? dateTime1 = DateTime.UtcNow;

        //if datetime = null dont invoke ToString method and else return "No Date"
        string strDate = dateTime1?.ToString() ?? "No Date";

        c.WriteLine(strDate);

        c.ReadKey();

    }
}