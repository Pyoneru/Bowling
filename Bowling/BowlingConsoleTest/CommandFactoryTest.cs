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

        [TestMethod]
        public void CreateCommandIsNotNull()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void BadFlagCommandShouldReturnNull()
        {
            string badFlag = "badFlag";

            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            Assert.IsNull(command);
        }

        [TestMethod]
        public void CreatePrintCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            var isPrintCommand = command is PrintCommand;

            Assert.IsTrue(isPrintCommand);
        }

        [TestMethod]
        public void CreatePrintCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_SHORT_FLAG);

            var isPrintCommand = command is PrintCommand;

            Assert.IsTrue(isPrintCommand);
        }

        [TestMethod]
        public void CreateHelpCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_FULL_FLAG);

            var isPrintCommand = command is HelpCommand;

            Assert.IsTrue(isPrintCommand);
        }

        [TestMethod]
        public void CreateHelpCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_SHORT_FLAG);

            var isPrintCommand = command is HelpCommand;

            Assert.IsTrue(isPrintCommand);
        }

        [TestMethod]
        public void CreateErrorCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_FULL_FLAG);

            var isPrintCommand = command is HelpCommand;

            Assert.IsTrue(isPrintCommand);
        }

        [TestMethod]
        public void CreateErrorCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_SHORT_FLAG);

            var isPrintCommand = command is HelpCommand;

            Assert.IsTrue(isPrintCommand);
        }


    }
}
