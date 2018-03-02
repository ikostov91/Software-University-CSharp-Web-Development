using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //int[] coords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).Select(int.Parse).ToArray();

        //Point topLeft = new Point(coords[0], coords[1]);
        //Point bottomRight = new Point(coords[2], coords[3]);
        //Rectangle rectangle = new Rectangle(new Point(coords[0], coords[1]), new Point(coords[2], coords[3]));

        Rectangle rectangle = new Rectangle(Console.ReadLine());

        int numberOfPoints = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numberOfPoints; i++)
        {
            //int[] pointCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).Select(int.Parse).ToArray();
            //Point point = new Point(pointCoordinates[0], pointCoordinates[1]);

            Point point = new Point(Console.ReadLine);

            bool isPointInRectangle = rectangle.Contains(point);
            Console.WriteLine(isPointInRectangle);
        }
    }
}

