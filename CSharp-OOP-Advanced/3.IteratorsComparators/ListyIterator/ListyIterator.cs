using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T>
{
    private List<T> list;
    private int currentIndex;

    public ListyIterator(params T[] list)
    {
        this.list = new List<T>(list);
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (currentIndex < this.list.Count - 1)
        {
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (this.list.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine($"{this.list[currentIndex]}");
    }
}

