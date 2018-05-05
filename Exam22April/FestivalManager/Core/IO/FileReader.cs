using System;
using System.IO;
using FestivalManager.Core.IO.Contracts;

// we might want to read from files idk lol ¯\_(ツ)_/¯
namespace FestivalManager.Core.IO
{
	using System.IO;
    //}
    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter()
        {
           
        }

        public void Write(string contents)
        {
            Console.Write(contents);
        }

        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }
    }
  
}