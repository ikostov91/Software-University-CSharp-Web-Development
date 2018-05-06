using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(Program);

        foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic))
        {
            foreach (var attribute in method.GetCustomAttributes<SoftuniAttribute>())
            {
                Console.WriteLine(attribute.Name);
            }
        }
    }
}

