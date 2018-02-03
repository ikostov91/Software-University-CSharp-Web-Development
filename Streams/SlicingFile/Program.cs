using System;
using System.IO;

namespace SlicingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());

            string fileName = "sliceMe.mp4";
            string destinationDirectory = "..\\Resources\\Sliced";
            Slice(fileName, destinationDirectory, parts);
            
        }

        private static void Slice(string fileName, string destinationDirectory, int parts)
        {
            using (var sourceFile = new FileStream("..\\Resources\\" + fileName, FileMode.Open))
            {
                int index = 0;

                long partSize = (long)Math.Ceiling((decimal)sourceFile.Length / parts);

                using (var destinationFiles = new FileStream())
                {
                    
                }

            }
        }
    }
}
