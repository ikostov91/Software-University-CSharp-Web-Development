using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    private List<T> list;

    public CustomList()
    {
        this.list = new List<T>();
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
        //if (this.list.Contains(element))
        //{
        //    return true;
        //}

        //return false;

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
        //int count = 0;

        //foreach (var item in this.list)
        //{
        //    if (item.CompareTo(element) > 0)
        //    {
        //        count++;
        //    }
        //}

        //return count;

        return this.list.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        //T max = default(T);

        //foreach (var item in this.list)
        //{
        //    if (item.CompareTo(max) > 0)
        //    {
        //        max = item;
        //    }
        //}

        //return max;

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
}

