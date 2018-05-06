using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Pop()
    {
        string item = string.Empty;

        if (!IsEmpty())
        {
            item = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
        }

        return item;
    }

    public string Peek()
    {
        string item = string.Empty;

        if (!IsEmpty())
        {
            item = data[data.Count - 1];
        }

        return item;
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public string PrintList()
    {
        return string.Join(" ", this.data);
    }
}

