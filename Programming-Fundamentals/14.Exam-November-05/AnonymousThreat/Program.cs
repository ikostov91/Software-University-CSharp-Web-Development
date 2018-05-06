using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] command = input.Split(' ');
                string commandType = command[0];

                switch (commandType)
                {
                    case "merge":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        Merge(startIndex, endIndex, list);
                        break;
                    case "divide":
                        int index = int.Parse(command[1]);
                        int partitions = int.Parse(command[2]);
                        Divide(index, partitions, list);
                        break;
                }
            }

            Console.WriteLine(String.Join(" ", list));
        }

        private static void Divide(int index, int partitions, List<string> list)
        {
            string stringToDivide = list[index];
            List<string> partitionsList = new List<string>();

            int stringLength = stringToDivide.Length;
            double partitionsCount = (double)stringLength / partitions;

            if (partitionsCount % 2 != 0)
            {
                int longestPartitionLength = Convert.ToInt32(Math.Ceiling(partitionsCount));
                string longestPartition = stringToDivide.Substring(stringToDivide.Length - longestPartitionLength);
                partitions -= 1;
                stringToDivide = stringToDivide.Remove(stringToDivide.Length - longestPartitionLength);
                int smallerPartitionsLenght = stringToDivide.Length / partitions;

                for (int i = 0; i < partitions; i++)
                {
                    string currentPartition = stringToDivide.Substring(0, smallerPartitionsLenght);
                    partitionsList.Add(currentPartition);
                    stringToDivide = stringToDivide.Remove(0, smallerPartitionsLenght);
                }

                partitionsList.Add(longestPartition);
            }
            else
            {
                double partitionLength = stringToDivide.Length / partitions;
                for (int i = 0; i < partitions; i++)
                {
                    string currentPartiton = stringToDivide.Substring(0, (int)partitionLength);
                    partitionsList.Add(currentPartiton);
                    stringToDivide = stringToDivide.Remove(0, (int)partitionLength);
                }
            }

            list.RemoveAt(index);
            list.InsertRange(index, partitionsList);
        }

        private static void Merge(int startIndex, int endIndex, List<string> list)
        {
            if (startIndex >= list.Count)
            {
                return;
            }
            else if (startIndex < 0)
            {
                startIndex = 0;
            }

            int count = endIndex - startIndex + 1;

            int subCount = list.Count - startIndex;

            if (count > subCount)
            {
                count = subCount;
            }

            StringBuilder mergedSubstring = new StringBuilder();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                string currentString = list[i];
                mergedSubstring.Append(currentString);
                
            }
            list.RemoveRange(startIndex, count);
            list.Insert(startIndex, mergedSubstring.ToString());
        }
    }
}
