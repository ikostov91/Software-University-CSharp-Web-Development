using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split(' ');

                string action = command[0];
                int start = 0, count = 0;

                switch (action)
                {
                    case "reverse":
                        start = int.Parse(command[2]);
                        count = int.Parse(command[4]);
                        ReverseFromIndex(start, count, sequence);
                        break;
                    case "sort":
                        start = int.Parse(command[2]);
                        count = int.Parse(command[4]);
                        SortFromIndex(start, count, sequence);
                        break;
                    case "rollLeft":
                        count = int.Parse(command[1]);
                        RollSequenceLeft(count, sequence);
                        break;
                    case "rollRight":
                        count = int.Parse(command[1]);
                        RollSequenceRight(count, sequence);
                        break;
                }
            }

            Console.WriteLine($"[{String.Join(", ", sequence)}]");
        }

        private static void SortFromIndex(int start, int count, List<string> sequence)
        {
            if (start < 0 || start >= sequence.Count || count < 0 || count > (sequence.Count - start))
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> sublist = new List<string>();
            sublist = sequence.GetRange(start, count);
            sublist.Sort();
            sequence.RemoveRange(start, count);
            sequence.InsertRange(start, sublist);
        }

        private static void ReverseFromIndex(int start, int count, List<string> sequence)
        {
            if (start < 0 || start >= sequence.Count || count < 0 || count > (sequence.Count - start))
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> sublist = new List<string>();

            sublist = sequence.GetRange(start, count);
            sublist.Reverse();
            sequence.RemoveRange(start, count);
            sequence.InsertRange(start, sublist);
        }

        private static void RollSequenceLeft(int count, List<string> sequence)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var firstElement = sequence[0];
                sequence.RemoveAt(0);
                sequence.Add(firstElement);
            }
        }

        private static void RollSequenceRight(int count, List<string> sequence)
        {
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var lastElement = sequence[sequence.Count - 1];
                sequence.RemoveAt(sequence.Count - 1);
                sequence.Insert(0, lastElement);
            }
        }
    }
}
