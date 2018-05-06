using System;
using System.Linq;

namespace OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            SongDatabase database = new SongDatabase();

            for (int i = 1; i <= numberOfSongs; i++)
            {
                try
                {
                    string[] songInfo = Console.ReadLine().Split(new char[] {';',':'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (songInfo.Length < 4)
                    {
                        throw new InvalidSongException(ExceptionMessages.InvalidSong);
                    }

                    string artist = songInfo[0];
                    string title = songInfo[1];
                    int minutes = int.Parse(songInfo[2]);
                    int seconds = int.Parse(songInfo[3]);

                    Song song = new Song(artist, title, minutes, seconds);
                    database.AddSong(song);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine(database.ToString());
        }
    }
}
