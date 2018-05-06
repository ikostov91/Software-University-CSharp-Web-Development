using System;
using System.Collections.Generic;
using System.Text;

public static class Swap<T>
{
    public static void SwapValues<T>(IList<Box<T>> values, int firstIndex, int secondIndex)
    {
        Box<T> temp = values[firstIndex];
        values[firstIndex] = values[secondIndex];
        values[secondIndex] = temp;

        //T firstValue = values[firstIndex];
        //T secondValue = values[secondIndex];

        //values[firstIndex] = secondValue;
        //values[secondIndex] = firstValue;
    }
}

