using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sourceFile = new FileStream("..\\Resources\\copyMe.png", FileMode.Open))
            {
                using (var destinationFile = new FileStream("copyMe-Copy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        var readBytesCounter = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytesCounter == 0)
                        {
                            break;
                        }

                        destinationFile.Write(buffer, 0, readBytesCounter);
                    }
                }
            }
        }
    }
}
