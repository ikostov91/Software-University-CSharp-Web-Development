using System;
using System.Collections.Generic;
using System.Text;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T Left
    {
        get { return this.left; }
        set { this.left = value; }
    }

    public T Right
    {
        get { return this.right; }
        set { this.right = value; }
    }

    public T GetHevier()
    {
        // If left is larger than right, returns 1
        // if right is larger than left, returns -1
        // if left and right are equal, returns 0
        var comparisonResult = this.left.CompareTo(this.right);

        if (comparisonResult > 0)
        {
            return this.left;
        }

        if (comparisonResult < 0)
        {
            return this.right;
        }

        return default(T);
    }
}

// Get by index
// public T this[int index]
// {
//     get { return this.items[index]; }
//     set { this.items[index] = value; }
// }

