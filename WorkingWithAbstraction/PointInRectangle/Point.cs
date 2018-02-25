using System;
using System.Collections.Generic;
using System.Text;

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

    public Point()
    {
        this.x = 0;
        this.y = 0;
    }

    public Point(int x, int y):this()
    {
        this.x = x;
        this.y = y;
    }
}

