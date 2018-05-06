using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    public void Run()
    {
        RaceTower rt = new RaceTower();

        int numberOfLapsInRace = int.Parse(Console.ReadLine());
        int lengthOfTrack = int.Parse(Console.ReadLine());
        rt.SetTrackInfo(numberOfLapsInRace, lengthOfTrack);
        bool raceOver = false;

        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            switch (input[0])
            {
                case "RegisterDriver":
                    rt.RegisterDriver(input.Skip(1).ToList());
                    break;
                case "Leaderboard":
                    Console.WriteLine(rt.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    try
                    {
                        Console.WriteLine(rt.CompleteLaps(input.Skip(1).ToList()));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "Box":
                    rt.DriverBoxes(input.Skip(1).ToList());
                    break;
                case "ChangeWeather":
                    rt.ChangeWeather(input.Skip(1).ToList());
                    break;
            }
        }
    }
}

