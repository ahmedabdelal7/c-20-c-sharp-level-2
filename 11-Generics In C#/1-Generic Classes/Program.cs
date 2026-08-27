using System;
using System.Collections.Generic;

public class Repository<T> where T : class
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public T Get(int index)
    {
        return items[index];
    }

    public int Count
    {
        get { return items.Count; }
    }

    public void PrintAll()
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Product: {Name}";
    }
}

class Program
{
    static void Main()
    {
        Repository<Student> students = new Repository<Student>();

        students.Add(new Student
        {
            Id = 1,
            Name = "Ahmed"
        });

        students.Add(new Student
        {
            Id = 2,
            Name = "Ali"
        });

        students.PrintAll();

        Console.WriteLine("----------------");

        Repository<Product> products = new Repository<Product>();

        products.Add(new Product
        {
            Id = 101,
            Name = "Laptop"
        });

        products.Add(new Product
        {
            Id = 102,
            Name = "Mouse"
        });

        products.PrintAll();

        Console.WriteLine("----------------");
        Console.WriteLine(products.Get(0).ToString()); 

        Console.ReadKey();
    }
}