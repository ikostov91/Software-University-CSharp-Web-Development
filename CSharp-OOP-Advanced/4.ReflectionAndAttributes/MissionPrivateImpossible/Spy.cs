using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string classToInvestigate)
    {
        var type = Type.GetType(classToInvestigate);
        var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"All Private Methods of Class: {classToInvestigate}");
        stringBuilder.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            stringBuilder.AppendLine($"{method.Name}");
        }

        return stringBuilder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string classToInvestigate)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var type = Type.GetType(classToInvestigate);

        // type.GetFields() returns all public fields of the current type
        foreach (FieldInfo field in type.GetFields())
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (PropertyInfo property in properties)
        {
            if (property.GetMethod?.IsPrivate == true)
            {
                stringBuilder.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
        }

        foreach (PropertyInfo property in properties)
        {
            if (property.SetMethod?.IsPublic == true)
            {
                stringBuilder.AppendLine($"{property.SetMethod.Name} have to be private!");
            }
        }

        return stringBuilder.ToString().Trim();
    }

    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        StringBuilder stringBuilder = new StringBuilder($"Class under investigation: {classToInvestigate}" + Environment.NewLine);

        var fields = Type.GetType(classToInvestigate).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var classInstance = Activator.CreateInstance(Type.GetType(classToInvestigate));

        foreach (var field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
        }

        return stringBuilder.ToString().Trim();
    }
}

