using System;
using System.Net;

namespace URLDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool decoding = true;

            while (decoding)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end") break;

                string decodedUrl = WebUtility.UrlDecode(input);
                Console.WriteLine(decodedUrl);
            }
        }
    }
}
