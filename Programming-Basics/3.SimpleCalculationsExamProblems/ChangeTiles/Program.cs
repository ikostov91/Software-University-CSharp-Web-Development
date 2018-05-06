using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTiles
{
    class Program
    {
        static void Main()
        {
            double totalAreaLength = double.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileLength = double.Parse(Console.ReadLine());
            double benchWidth = double.Parse(Console.ReadLine());
            double benchLength = double.Parse(Console.ReadLine());
            double tileArea = (totalAreaLength * totalAreaLength) - (benchWidth * benchLength);
            double oneTileSize = tileWidth * tileLength;
            double tilesNeeded = tileArea / oneTileSize;
            Console.WriteLine(tilesNeeded);
            double timeToChangeTiles = tilesNeeded * 0.2;
            Console.WriteLine(timeToChangeTiles);
        }
    }
}
