using System;

class StartUp
{
    static void Main(string[] args)
    {
        Controller controller = new Controller();
        controller.GetAppenders();
        controller.GetLogger();
        controller.ProcessMessages();
        controller.PrintLoggerInfo();
    }
}

