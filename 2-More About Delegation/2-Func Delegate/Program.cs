using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    //Method 1
    delegate double Square(double x);
    static public double SquareNumber(double x)
    {
        return x * x;
    }




    //Method 2
    //Parameters is up to 16 parameter, and last parameter is the return type.
    public static Func<int, int, double> Divide = DivideNumbers;

    static public double DivideNumbers(int x, int y)
    {
        return x / y;
    }



    static void Main(string[] args)
    {

        //Without Func:
        Square Square = new Square(SquareNumber);
        double Result = Square(2);
        Console.WriteLine("Result = {0}", Result);



        //Using Func:
        Result = Divide(10, 2);
        Console.WriteLine("Result = {0}", Result);



        Console.ReadKey();

    }
}



