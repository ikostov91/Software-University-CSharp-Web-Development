using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allMatches = new List<string>();

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            string pattern = @"\|<\w{0," + numbers[0] + @"}(?<camera>\w{0," + numbers[1] + "})";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match camera in matches)
            {
                var result = camera.Groups["camera"].Value;
                allMatches.Add(result);
            }

            Console.WriteLine(String.Join(", ", allMatches));
        }
    }
}
