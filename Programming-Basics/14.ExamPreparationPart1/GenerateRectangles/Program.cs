using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int rectangles = 0, area = 0;

            for (int i = -n; i < n; i++)
            {
                for (int j = -n; j < n; j++)
                {
                    for (int k = i + 1; k <= n; k++)
                    {
                        for (int l = j + 1; l <= n; l++)
                        {
                            area = Math.Abs(k - 1) * Math.Abs(l - j);

                            if (area >= m)
                            {
                                Console.WriteLine("({0},{1})({2},{3}) -> {4}", i, j, k, l, area);
                                rectangles++;
                            }
                        }
                    }      
                }
            }

            if (rectangles == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
