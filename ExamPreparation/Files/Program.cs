using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFiles = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, ulong>> filesDict = new Dictionary<string, Dictionary<string, ulong>>();

            for (int i = 0; i < numberOfFiles; i++)
            {
                string[] filePath = Console.ReadLine().Split('\\').ToArray();
                string rootFolder = filePath[0];
                string[] fileNameSize = filePath[filePath.Length - 1].Split(';');
                string name = fileNameSize[0];
                ulong size = ulong.Parse(fileNameSize[1]);

                if (!filesDict.ContainsKey(rootFolder))
                {
                    filesDict.Add(rootFolder, new Dictionary<string, ulong>());
                    filesDict[rootFolder].Add(name, size);
                }
                else
                {
                    if (filesDict[rootFolder].ContainsKey(name))
                    {
                        filesDict[rootFolder][name] = size;
                    }
                    else
                    {
                        filesDict[rootFolder].Add(name, size);
                    }
                }
            }

            string[] printCommand = Console.ReadLine().Split(' ');
            string root = printCommand[2];
            string extension = printCommand[0];

            if (!filesDict.ContainsKey(root) || !filesDict[root].Any(x => x.Key.EndsWith(extension)))
            {
                Console.WriteLine("No");
                return;
            }
            else
            {
                foreach (var file in filesDict[printCommand[2]].Where(x => x.Key.EndsWith(extension)).OrderByDescending(y => y.Value).ThenBy(z => z.Key))
                {
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                }
            }
        }
    }
}
