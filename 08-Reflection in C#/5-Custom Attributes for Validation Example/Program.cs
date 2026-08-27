using System;
using System.Linq;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
public class RangeAttribute : Attribute
{
    public int Min { get; set; }
    public int Max { get; set; }
    public string ErrorMessage { get; set; }

    public RangeAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

public class Person
{
    [Range(18,99 , ErrorMessage ="Age must be between 18 and 99")]
    public int Age { get; set; }
    public string Name { get; set; }
    [Range(20, 99, ErrorMessage = "Experience must be more  than 20 year.")]
    public int Experience { get; set; }


}

class Program
{        
    public static bool ValidatePerson(Person person)
    {
        Type type = typeof(Person);

        PropertyInfo[] properties =  type.GetProperties();

        foreach(var property in properties)
        {
            if (Attribute.IsDefined(property, typeof(RangeAttribute)))
            {
                var rangeAttribute =  (RangeAttribute)property.GetCustomAttribute(typeof(RangeAttribute), false);
                //var rangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                int value = (int)property.GetValue(person);

                if(value > rangeAttribute.Max || value < rangeAttribute.Min)
                {
                    Console.WriteLine($"Error: '{property.Name}' : {rangeAttribute.ErrorMessage}.");
                    return false; 
                }
            }
        }
        return true; 

    }
    static void Main()
    {
        Person person = new Person { Age = 12, Name = "Ahmed Abdel-Aal", Experience = 20 };

        if (ValidatePerson(person))
        {
            Console.WriteLine("Person is valid.");
        }
        else
        {
            Console.WriteLine("Validation failed.");
        }

        Console.ReadKey();

    }
}

