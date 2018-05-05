using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "print")
            {
                string[] instruction = input.Split(' ').ToArray();

                switch (instruction[0])
                {
                    case "add":
                        AddNumber(numbers, instruction[1], instruction[2]);
                        break;
                    case "addMany":
                        AddManyNumbers(numbers, instruction);
                        break;
                    case "contains":
                        CheckIfContains(numbers, instruction[1]);
                        break;
                    case "remove":
                        RemoveAtIndex(numbers, instruction[1]);
                        break;
                    case "shift":
                        ShiftPositions(numbers, instruction[1]);
                        break;
                    case "sumPairs":
                        SumPairs(numbers);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }

        private static void SumPairs(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = numbers[i] + numbers[i + 1];
                numbers.RemoveAt(i + 1);
            }
        }

        private static void ShiftPositions(List<int> numbers, string v)
        {
            int positions = int.Parse(v);

            for (int i = 0; i < positions; i++)
            {
                int firstElement = numbers[0];
                for (int j = 1; j < numbers.Count; j++)
                {
                    numbers[j - 1] = numbers[j]; 
                }
                numbers[numbers.Count - 1] = firstElement;
            }
        }

        private static void RemoveAtIndex(List<int> numbers, string v)
        {
            int index = int.Parse(v);
            numbers.RemoveAt(index);
        }

        private static void AddManyNumbers(List<int> numbers, string[] instruction)
        {
            int index = int.Parse(instruction[1]);
            for (int i = 2; i < instruction.Length; i++)
            {
                int number = int.Parse(instruction[i]);
                numbers.Insert(index, number);
                index += 1;
            }
        }

        private static void CheckIfContains(List<int> numbers, string v)
        {
            int number = int.Parse(v);
            if (numbers.Contains(number))
            {
                Console.WriteLine(numbers.IndexOf(number));
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        private static void AddNumber(List<int> numbers, string index, string number)
        {
            int numberToAdd = int.Parse(number);
            int listIndex = int.Parse(index);
            numbers.Insert(listIndex, numberToAdd);
        }
    }
}
