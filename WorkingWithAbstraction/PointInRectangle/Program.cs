using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] rectanglePoints = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None)
            .Select(int.Parse).ToArray();

        Point topLeft = new Point(rectanglePoints[0], rectanglePoints[1]);
        Point bottomRight = new Point(rectanglePoints[2], rectanglePoints[3]);

        Rectangle rectangle = new Rectangle(topLeft, bottomRight);

        int numberOfPoints = int.Parse(Console.ReadLine());

        for (int i = 1; i <= numberOfPoints; i++)
        {
            int[] pointCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None)
                .Select(int.Parse).ToArray();

            Point point = new Point(pointCoordinates[0], pointCoordinates[1]);

            bool isPointInRectangle = rectangle.Contains(point);
            Console.WriteLine(isPointInRectangle);
        }
    }
}

