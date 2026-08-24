using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class MyClass
{
    //Serialized Attribute
    public int SerializedAttribute { get; set; }


    //NonSerialized Attribute
    [NonSerialized]
    public int NonSerialized;
}


class Program
{
    static void Main()
    {
        
    }
}


