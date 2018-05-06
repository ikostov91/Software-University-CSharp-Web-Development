using System;
using System.Linq;
using System.Reflection;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        Type type = typeof(HarvestingFields);
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        string input;

        while ((input = Console.ReadLine()) != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    foreach (var field in fields.Where(t => t.IsPrivate))
                    {
                        Console.WriteLine($"{input} {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "protected":
                    foreach (var field in fields.Where(t => t.IsFamily))
                    {
                        Console.WriteLine($"{input} {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "public":
                    foreach (var field in fields.Where(t => t.IsPublic))
                    {
                        Console.WriteLine($"{input} {field.FieldType.Name} {field.Name}");
                    }
                    break;
                case "all":
                    foreach (var field in fields)
                    {
                        string modifier = ReturnAccessModifier(field);
                        Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
                    }
                    break;
            }
        }
    }

    private static string ReturnAccessModifier(FieldInfo field)
    {
        if (field.IsPublic)
        {
            return "public";
        }
        else if (field.IsPrivate)
        {
            return "private";
        }
        else
        {
            return "protected";
        }
    }
}

