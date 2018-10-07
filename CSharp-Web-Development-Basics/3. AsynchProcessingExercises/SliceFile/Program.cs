using System;
using System.IO;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Create))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLength = (source.Length / parts) + 1;
                int currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}", destinationPath, currentPart, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[BufferLength];
                        while (currentByte <= partLength * currentPart)
                        {

                        }
                    }
                }
            }
        }
    }
}
