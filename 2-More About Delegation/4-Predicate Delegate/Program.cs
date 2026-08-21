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
    //Predicate Delegate take one parameter and return boolean, has no return type

    static Predicate<int> IsEvenPredicate = IsEven;

    static bool IsEven(int x)
    {
        return x % 2 == 0;
    }
      

    static void Main(string[] args)
    {
        bool result = IsEvenPredicate(10);

        Console.WriteLine("Is Number 10 Even : {0}",result);

        Console.ReadKey();

    }
}



