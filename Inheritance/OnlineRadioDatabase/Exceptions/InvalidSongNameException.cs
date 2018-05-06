using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException(string message) : base(message)
    {
        
    }
}

