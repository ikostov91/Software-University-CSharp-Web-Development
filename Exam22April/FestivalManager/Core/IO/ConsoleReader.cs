using System;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	public class ConsoleReader : IReader
	{
        //private readonly System.IO.StringReader reader;

        //public StringReader(string contents)
        //{
        //	this.reader = new System.IO.StringReader(contents);
        //}

        //public string ReadLine() => this.reader.ReadLine();

	    public ConsoleReader()
	    {
	    }

	    public string ReadLine() => Console.ReadLine();
	}
}