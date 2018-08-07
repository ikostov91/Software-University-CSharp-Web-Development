using System;
using TeamBuilder.App.Core;

namespace TeamBuilder.App
{
    class Application
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
