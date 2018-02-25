using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

public class Rectangle
{
    private Point topLeftPoint;
    private Point bottomRightPoint;

    public Point TopLeftPoint
    {
        get { return this.topLeftPoint; }
        set { this.topLeftPoint = value; }
    }

    public Point BottomRightPoint
    {
        get { return this.bottomRightPoint; }
        set { this.bottomRightPoint = value; }
    }

    public Rectangle(Point topLeftPoint, Point bottomRightPoint)
    {
        TopLeftPoint = new Point(topLeftPoint.X, topLeftPoint.Y);
        BottomRightPoint = new Point(bottomRightPoint.X, bottomRightPoint.Y);
    }

    public bool Contains(Point point)
    {
        bool contains = point.X >= topLeftPoint.X && 
                        point.X <= bottomRightPoint.X && 
                        point.Y >= topLeftPoint.Y &&
                        point.Y <= bottomRightPoint.Y;

        return contains;
    }
}

