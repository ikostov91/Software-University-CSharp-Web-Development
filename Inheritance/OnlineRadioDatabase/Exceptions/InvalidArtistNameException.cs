using System;
using System.Collections.Generic;
using System.Text;

public class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException(string message) : base(message)
    {
        
    }
}

