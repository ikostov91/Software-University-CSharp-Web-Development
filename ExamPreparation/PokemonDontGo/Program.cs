using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int sumOfRemoved = 0, currentRemoved = 0;

            while (list.Any())
            {
                int index = int.Parse(Console.ReadLine());

                currentRemoved = RemoveElementFromList(list, index);
                sumOfRemoved += currentRemoved;

                IncreaseDecreaseValuesInList(list, currentRemoved);
            }

            Console.WriteLine(sumOfRemoved);
        }

        private static void IncreaseDecreaseValuesInList(List<int> list, int currentRemoved)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= currentRemoved)
                {
                    list[i] += currentRemoved;
                }
                else
                {
                    list[i] -= currentRemoved;
                }
            }
        }

        private static int RemoveElementFromList(List<int> list, int index)
        {
            int element = 0;

            if (index < 0)
            {
                element = list[0];
                int last = list[list.Count - 1];
                list.RemoveAt(0);
                list.Insert(0, last);
            }
            else if (index >= list.Count)
            {
                element = list[list.Count - 1];
                int first = list[0];
                list.RemoveAt(list.Count - 1);
                list.Add(first);
            }
            else
            {
                element = list[index];
                list.RemoveAt(index);
            }

            return element;
        }
    }
}
