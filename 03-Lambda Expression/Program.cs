using System;


public class Program
{

    //Normal delegate using lambda exp
    delegate double Square(double x);

    //Func delegate using lambda exp
    static Func<int, int, double> Divide = (x, y) => x / y;

    //Action Delegate using lambda Exp
    static Action ParameterlessAction = () =>
    {
        Console.WriteLine("This is parameter less action.");
    };

    static Action<int, string> MultipleParameterAction = (num, str) =>
    {
        Console.WriteLine("This is multiple parameter action.");
    };

    //Predicate delegate using lambda exp
    static Predicate<int> IsEven = (x) => x % 2 == 0;


    //Example:
    //

    public static void ExecuteOperation(int x ,int y, Func<int, int, int> Operation)
    {
        int result = Operation(x, y);
        Console.WriteLine("Result is: "+result);
    }




    static void Main(string[] args)
    {
        //System.Console.Write("asdasda");


        //Normal Delegate:
        Square Square = new Square(x => x*x);

        double Result = Square(2);
        Console.WriteLine("Result = {0}", Result);

        //Func Delegate:
        Result = Divide(10, 2);
        Console.WriteLine("Result = {0}", Result);

        Console.WriteLine();

        //Action Delegate
        ParameterlessAction();

        MultipleParameterAction(80, "Anything");

        Console.WriteLine();

        //Predicate Delegate
        Console.WriteLine("Is Number 5 Even: "+IsEven(5));


        Console.WriteLine();
        //Example
        //
        Func<int, int, int> Add = (x, y) => (x + y); 
        Func<int, int, int> Sub = (x, y) => (x - y);

        ExecuteOperation(10, 5, Add);
        ExecuteOperation(10, 5, Sub);

        Console.ReadKey();

    }
}



