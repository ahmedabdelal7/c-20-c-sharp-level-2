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
    //Action Delegate is Procedure, has no return type
    //Func Delegate is Function, has return type

    static Action ParameterlessAction = ParameterLessMethod;
    static Action<int> ActionWithIntParameter = MethodWithIntParameter;
    static Action<int, string> ActionWithMultipleParameters = MethodWithMultipleParameter;


    public static void ParameterLessMethod()
    {
        Console.WriteLine("This is ParameterLess method.");
    }

    public static void MethodWithIntParameter(int x)
    {
        Console.WriteLine("This is MethodWithIntParameter, value is: {0}", x);
    }
    public static void MethodWithMultipleParameter(int x, string y)
    {
        Console.WriteLine("This is MethodWithMultipleParameter, value is 1: {0}, value is 2: {1}", x, y);
    }

    static void Main(string[] args)
    {

        ParameterlessAction();
        ActionWithIntParameter(10);
        ActionWithMultipleParameters(50, "Ahmed");


        Console.ReadKey();

    }
}



