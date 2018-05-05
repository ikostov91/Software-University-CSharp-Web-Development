using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var bag = new Bag<int>();

        bag.Add(2);
        bag.Add(3);
        bag.Add(4);

        var item = bag.GetElementAt(0);

        Console.WriteLine(item);
    }
}

public class Bag<T>
{
    private List<T> items;

    public Bag()
    {
        this.items = new List<T>();
    }

    public void Add(T item)
    {
        this.items.Add(item);
    }

    public T GetElementAt(int index)
    {
        return items[index];
    }
}

