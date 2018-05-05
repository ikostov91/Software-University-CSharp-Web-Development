using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (var streamReader = new StreamReader("words.txt"))
            {
                string word;
                string text = File.ReadAllText("text.txt");

                while ((word = streamReader.ReadLine()) != null)
                {
                    var count = Regex.Matches(text.ToLower(), @"\b" + word + @"\b").Count;

                    if (!words.ContainsKey(word))
                    {
                        words[word] = count;
                    }
                }

                words = words.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);

                using (var streamWriter = new StreamWriter("results.txt"))
                {
                    foreach (var wordResult in words)
                    {
                        string line = wordResult.Key + " - " + wordResult.Value;
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }
    }
}
