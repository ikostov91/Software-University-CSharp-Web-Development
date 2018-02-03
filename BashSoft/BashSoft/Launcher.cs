using System;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
            
            InputReader.StartReadingCommands();
        }
    }
}
