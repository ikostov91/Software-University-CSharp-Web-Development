using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            bool noMoreEquals = false;

            do
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers[i] = numbers[i] + numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                    }
                }

                noMoreEquals = CheckIfEqualElementsExist(numbers);

            } while (noMoreEquals == false);
            
            
            Console.WriteLine(String.Join(" ", numbers));
        }

        static bool CheckIfEqualElementsExist(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
