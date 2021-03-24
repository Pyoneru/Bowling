using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    public class CommandFactory
    {
        protected Dictionary<string, ICommand> prototypes;

        public CommandFactory()
        {
            prototypes = new Dictionary<string, ICommand>();
        }

        public ICommand CreateCommand(string flag)
        {
            return null;
        }
    }
}
