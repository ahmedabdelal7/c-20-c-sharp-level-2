using System;
using System.Linq;
using System.Reflection;

namespace MyNameSpace
{

/*
     In C#, a custom attribute is a user-defined metadata that you can apply to elements in your code,
    such as classes, methods, properties, or parameters.
    Attributes provide a way to add declarative information to your code, which can be used by the runtime,
    tools, or other code to perform specific actions or make decisions.
*/

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)] 

    public class MyCustomAttribute : Attribute
    {
        public string Description;

        public MyCustomAttribute(string description)
        {
           this.Description = description;
        }
    }

    [MyCustom("This is MyClass for test attribute")]
    public class MyClass
    {
        [MyCustom("This is Method1 for test attribute")]
        public void Method1()
        {
            Console.WriteLine("This is method 1");
        }

        [MyCustom("This is Method2 for test attribute")]
        public void Method2()
        {
            Console.WriteLine("This is method 2");
        }
    }

    class Program
    {
        static string GetParameterList(ParameterInfo[] parameters)
        {
            return string.Join(", ", parameters.Select(parameter => $"{parameter.ParameterType} {parameter.Name}"));
        }

        static void Main()
        {

            Type myClassType = typeof(MyClass);

            Console.WriteLine("Class information:\n");
            Console.WriteLine($"Type Name: {myClassType.Name}");
            Console.WriteLine($"Full Name: {myClassType.FullName}");

            //  Get custom attributes for class
            //
            Console.WriteLine("\nAttributes on Class-Level:\n");

            object[] classAttributes = myClassType.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach (MyCustomAttribute attribute in classAttributes) {
                Console.WriteLine($"Attribute Description: {attribute.Description}");
            } 

            //  Get custom attribute for all methods
            //
            Console.WriteLine("\nAttributes on Methods-Level:\n");

            MethodInfo[] classMethods = myClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (MethodInfo method in classMethods) {

                object[] methodAttributes = method.GetCustomAttributes(typeof(MyCustomAttribute), false);

                foreach (MyCustomAttribute attribute in methodAttributes) {
                    Console.WriteLine($"\t{method.ReturnType} {method.Name}({GetParameterList(method.GetParameters())})");
                    Console.WriteLine($"\tDescription: {attribute.Description}\n");
                }
            }

            //  Get Attributes for specific method:
            //
            MethodInfo method1 = myClassType.GetMethod("Method1");
            object[] method1Attributes = method1.GetCustomAttributes(typeof(MyCustomAttribute),false);

            Console.WriteLine("\nMethod1 Attributes");

            foreach (MyCustomAttribute attribute in method1Attributes)
            {
                Console.WriteLine($"{method1.Name} : {attribute.Description}");
            }

            Console.ReadKey();

        }
    }

}
