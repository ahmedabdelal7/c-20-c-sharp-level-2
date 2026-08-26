using System;

/// <summary>
/// This class is a simple calculator.
/// </summary>

public class Calculator
{
    /// <summary>
    /// This method to add tow numbers.
    /// </summary>
    /// <param name="num1">first int parameter</param>
    /// <param name="num2">second int parameter</param>
    /// <returns>Sum of tow numbers</returns>
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    /// <summary>
    /// This method to subtract tow numbers.
    /// </summary>
    /// <param name="num1">first int parameter</param>
    /// <param name="num2">second int parameter</param>
    /// <returns>Subtract first parameter from the second.</returns>
    public int Subtract(int num1, int num2)
    {
        return num1 - num2;
    }
}
class Program
{        
    static void Main()
    {
        
        Calculator calculator = new Calculator();
        
        Console.WriteLine("Result = "+ calculator.Add(5, 5));
        Console.WriteLine("Result = "+ calculator.Subtract(8,2));
        
        Console.ReadKey();

    }
}

