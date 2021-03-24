using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingConsole.Command;
using BowlingConsole.Util;
using System;

namespace BowlingConsoleTest
{
    [TestClass]
    public class CommandFactoryTest
    {
        private CommandFactory factory;
        
        public CommandFactoryTest()
        {
            factory = new CommandFactory();
        }

        /// <summary>
        /// Returned command should not be null when flag is correct
        /// </summary>
        [TestMethod]
        public void CreateCommandIsNotNull()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            Assert.IsNotNull(command);
        }


    }
}
