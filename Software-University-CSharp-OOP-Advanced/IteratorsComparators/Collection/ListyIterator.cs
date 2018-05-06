using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
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

    public void PrintAll()
    {
        if (this.list.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        foreach (var item in this.list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

