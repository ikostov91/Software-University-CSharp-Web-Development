using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftuniAttribute : Attribute
{
    public string Name { get; private set; }

    public SoftuniAttribute(string name)
    {
        Name = name;
    }
}

