using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < numberOfEmployees; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();

            if (input.Length == 6)
            {
                Employee employee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4], int.Parse(input[5]));
            }
            else
            {
                if (input.Length == 5)
                {
                    int number;
                    bool tryParseAge = int.TryParse(input[4], out number);

                    switch (tryParseAge)
                    {
                        case true:
                            break;
                        case false:
                            break;
                    }
                }
            }
        }
    }
}
