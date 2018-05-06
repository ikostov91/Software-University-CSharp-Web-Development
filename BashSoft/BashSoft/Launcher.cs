using System;
using BashSoft.Repository;
using SimpleJudge;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {            
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
