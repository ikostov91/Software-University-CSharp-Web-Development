using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value;  }
    }

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Height + this.Width);
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return "Rectangle";
    }
}

