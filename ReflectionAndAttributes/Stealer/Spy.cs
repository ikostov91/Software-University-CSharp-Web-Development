using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
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

