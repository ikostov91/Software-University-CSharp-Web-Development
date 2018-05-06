using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private List<T> list;

    public CustomList()
    {
        this.list = new List<T>();
    }

    public CustomList(IEnumerable<T> list)
    {
        this.list = new List<T>(list);
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public T Remove(int index)
    {
        T element = this.list[index];
        this.list.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        return this.list.Contains(element);
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        T temp = this.list[firstIndex];
        this.list[firstIndex] = this.list[secondIndex];
        this.list[secondIndex] = temp;
    }

    public int CountGreaterThan(T element)
    {
        return this.list.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.list.Max();
    }

    public T Min()
    {
        return this.list.Min();
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, list);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in this.list)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

