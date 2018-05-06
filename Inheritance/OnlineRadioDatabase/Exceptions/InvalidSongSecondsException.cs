using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException(string message) : base(message)
    {
        
    }
}

