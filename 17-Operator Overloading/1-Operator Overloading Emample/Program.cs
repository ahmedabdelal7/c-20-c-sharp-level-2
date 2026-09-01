using System;
using System.Security.Cryptography;
using System.Text;



public class Point
{
    public int X { get; set; }
    public int Y { get; set; }


    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public static Point operator +(Point p1, Point p2) 
    {
        return new Point(p1.X + p2.X,p1.Y + p2.Y);

    }

    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.X- p2.X, p2.X- p2.Y);

    } 

    public static bool operator ==(Point p1, Point p2)
    {
        return (p1.X == p2.X && p1.Y == p2.Y);
    }

    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }

    //Should overload >= also.
    public static bool operator <=(Point p1, Point p2)
    {
        return (p1.X <= p2.X && p1.Y <= p2.Y);
    }

    public static bool operator >=(Point p1, Point p2)
    {
        return (p1.X >= p2.X && p1.Y >= p2.Y);
    }

    public static Point operator *(Point p1, Point p2)
    {
        return new Point(p1.X * p2.X, p1.Y * p2.Y);
    }

    public static Point operator /(Point p1, Point p2)
    {
        return new Point(p1.X / p2.X, p1.Y / p2.Y);
    }

    public override string ToString()
    {
        // return base.ToString();

        return $"({X},{Y})";
    
    }

    //public static Point operator =(Point p1, Point p2)
    //{
    //    // ❌ Not allowed
    //}



}

class Program
{
    static void Main()
    {
        
        Point p1 = new Point(1,2);
        Point p2 = new Point(2,3);

        Point res = p1 + p2;

        Console.WriteLine($"Sum: X = {res.X}, Y = {res.Y}");

        res = p1 - p2;
        Console.WriteLine($"Sub: X = {res.X}, Y = {res.Y}");

        bool IsEqual = false;

        p1.X = 1;p1.Y = 2;
        p2.X = 1; p2.Y = 2;

        Console.WriteLine("\np1 = (1,2) , p2 = (1,2)");

        Console.WriteLine("\nIs p1 == p2?");
        if(p1 == p2)
            Console.WriteLine("Yes p1 is equal p2.");
        else Console.WriteLine("No p1 is not equal p2.");


        Console.WriteLine("\nIs p1 != p2?");
        if (p1 != p2)
            Console.WriteLine("Yes p1 is not equal p2.");

        else Console.WriteLine("No p1 is equal p2.");


        Console.ReadKey();
    }

  
   
}
