using System;
using System.Collections.Generic;
using System.Text;

public class SongDatabase
{
    private List<Song> allSongs;

    public List<Song> AllSongs
    {
        get { return this.allSongs; }
    }

    public SongDatabase()
    {
        allSongs = new List<Song>();
    }

    public void AddSong(Song song)
    {
        this.allSongs.Add(song);
        Console.WriteLine("Song added.");
    }

    public int TotalPlaylistLength()
    {
        int totalLength = 0;

        foreach (var song in allSongs)
        {
            totalLength += (song.Minutes * 60) + song.Seconds;
        }

        return totalLength;
    }

    public override string ToString()
    {
        int totalLength = this.TotalPlaylistLength();
        int hours = totalLength / 3600;
        int minutes = (totalLength % 3600) / 60;
        int seconds = (totalLength % 3600) % 60;

        StringBuilder result = new StringBuilder();
        result.AppendLine($"Songs added: {this.allSongs.Count}")
              .Append($"Playlist length: {hours}h {minutes}m {seconds}s");

        return result.ToString();
    }
}

