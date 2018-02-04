using System;
using SimpleJudge;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {            
            InputReader.StartReadingCommands();

            //Tester.CompareContent(@"Files\actual.txt", @"Files\expected.txt");
        }
    }
}
