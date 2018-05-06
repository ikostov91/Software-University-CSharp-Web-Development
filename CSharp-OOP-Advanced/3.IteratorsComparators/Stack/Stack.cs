using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
    private List<T> list;

    public Stack(List<T> list)
    {
        this.list = list;
    }

    public T Pop()
    {
        if (this.list.Count == 0)
        {
            throw new IndexOutOfRangeException("No elements");
        }

        T item = this.list[this.list.Count - 1];
        this.list.RemoveAt(this.list.Count - 1);
        return item;
    }

    public void Push(T item)
    {
        this.list.Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.list.Count - 1; i >= 0; i--)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

