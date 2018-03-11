using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private const int MinMinutes = 0;
    private const int MaxMinutes = 14;
    private const int MinSeconds = 0;
    private const int MaxSeconds = 59;
    private const int MinLength = 3;
    private const int MaxArtistLength = 20;
    private const int MaxNameLength = 30;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (!IsArtistNameValid(value))
            {
                throw new InvalidArtistNameException(ExceptionMessages.InvalidArtistNameException);
            }
            this.artistName = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
            if (!IsSongNameValid(value))
            {
                throw new InvalidSongNameException(ExceptionMessages.InvalidSongNameException);
            }
            this.songName = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
            if (!AreMinutesValid(value))
            {
                throw new InvalidSongMinutesException(ExceptionMessages.InvalidSongMinutesException);
            }
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (!AreSecondsValid(value))
            {
                throw new InvalidSongSecondsException(ExceptionMessages.InvalidSongSecondsException);
            }
            this.seconds = value;
        }
    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    private bool IsArtistNameValid(string artistName)
    {
        if (artistName.Length < MinLength || artistName.Length > MaxArtistLength)
        {
            return false;
        }

        return true;
    }

    private bool IsSongNameValid(string songName)
    {
        if (songName.Length < MinLength || songName.Length > MaxNameLength)
        {
            return false;
        }

        return true;
    }

    private bool AreMinutesValid(int minutes)
    {
        if (minutes < MinMinutes || minutes > MaxMinutes)
        {
            return false;
        }

        return true;
    }

    private bool AreSecondsValid(int seconds)
    {
        if (seconds < MinSeconds || seconds > MaxSeconds)
        {
            return false;
        }

        return true;
    }
}

