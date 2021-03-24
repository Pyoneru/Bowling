using System;
using System.Collections.Generic;
using System.Text;
using BowlingConsole.Command;
using BowlingConsole.Util;
using Bowling;

namespace BowlingConsole
{
    public abstract class Controller
    {
        protected CommandFactory factory;
        protected string[] args;

        public Controller(CommandFactory factory, string[] args)
        {
            this.factory = factory;
            this.args = args;
        }

        public abstract void Run(); 
    }
}
