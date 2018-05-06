using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException(string message) : base(message)
    {
        
    }
}

