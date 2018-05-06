using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Point
{
    private int x;
    private int y;

    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(Func<string> readPoint)
    {
        int[] pointCoordinates = readPoint().Split(new char[] { ' ' }, StringSplitOptions.None).Select(int.Parse).ToArray();
        X = pointCoordinates[0];
        Y = pointCoordinates[1];
    }
}

