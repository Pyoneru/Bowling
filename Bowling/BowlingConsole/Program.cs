using System;
using BowlingConsole.Command;

namespace BowlingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new ConsoleController(new Command.CommandFactory(), args);
            controller.Run();
        }
    }
}
