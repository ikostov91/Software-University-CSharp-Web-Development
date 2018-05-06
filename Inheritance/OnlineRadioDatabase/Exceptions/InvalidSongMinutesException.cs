using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException(string message) : base(message)
    {
        
    }
}

