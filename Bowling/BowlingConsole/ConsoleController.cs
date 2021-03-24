using BowlingConsole.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole
{
    public class ConsoleController : Controller
    {
        public ConsoleController(CommandFactory factory, string[] args) : base(factory, args)
        {
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
