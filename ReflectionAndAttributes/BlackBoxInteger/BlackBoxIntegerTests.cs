using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        Type classType = typeof(BlackBoxInteger);
        var classInstance = Activator.CreateInstance(classType, true);
        var methods = classInstance.GetType().GetMethods();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] methodInfo = input.Split(new char[] {'_'}, StringSplitOptions.None);
            string methodName = methodInfo[0];
            int value = int.Parse(methodInfo[1]);

            MethodInfo method = classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(classInstance, new object[] {value});

            var innerValue = classType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First()
                .GetValue(classInstance);

            Console.WriteLine(innerValue);
        }
    }
}

