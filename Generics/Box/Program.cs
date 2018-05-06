using System;

public class Program
{
    static void Main(string[] args)
    {
        Program pr = new Program();
        pr.BoxTestWithIntegers();
    }

    private void BoxGenericTest()
    {
        int value = int.Parse(Console.ReadLine());
        Box<int> box = new Box<int>(value);
        Console.WriteLine(box);

        var box2 = new Box<string>("trololo");
        Console.WriteLine(box2);

        Console.WriteLine(new Box<string>("dsadad"));
    }

    private void BoxTestWithStrings()
    {
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string value = Console.ReadLine();
            var box = new Box<string>(value);
            Console.WriteLine(box);
        }
    }

    private void BoxTestWithIntegers()
    {
        int numberOfIntegers = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfIntegers; i++)
        {
            int value = int.Parse(Console.ReadLine());
            var box = new Box<int>(value);
            Console.WriteLine(box);
        }
    }
}

