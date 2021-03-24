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

        /// <summary>
        /// If flag command is bad, should return null
        /// </summary>
        [TestMethod]
        public void BadFlagCommandShouldReturnNull()
        {
            string badFlag = "badFlag";

            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            Assert.IsNull(command);
        }

        /// <summary>
        /// Full flag of PrintCommand should return instance of PrintCommand
        /// </summary>
        [TestMethod]
        public void CreatePrintCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            var isPrintCommand = command is PrintCommand;

            Assert.IsTrue(isPrintCommand);
        }

        /// <summary>
        /// Short flag of PrintCommand should return instance of PrintCommand
        /// </summary>
        [TestMethod]
        public void CreatePrintCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_SHORT_FLAG);

            var isPrintCommand = command is PrintCommand;

            Assert.IsTrue(isPrintCommand);
        }

        /// <summary>
        /// Full flag of HelpCommand should return instance of HelpCommand
        /// </summary>
        [TestMethod]
        public void CreateHelpCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_FULL_FLAG);

            var isPrintCommand = command is HelpCommand;

            Assert.IsTrue(isPrintCommand);
        }

        /// <summary>
        /// Short flag of HelpCommand should return instance of HelpCommand
        /// </summary>
        [TestMethod]
        public void CreateHelpCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_SHORT_FLAG);

            var isPrintCommand = command is HelpCommand;

            Assert.IsTrue(isPrintCommand);
        }

        /// <summary>
        /// Full flag of ErrorCommand should return instance of ErrorCommand
        /// </summary>
        [TestMethod]
        public void CreateErrorCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.ERROR_COMMAND_FULL_FLAG);

            var isPrintCommand = command is ErrorCommand;

            Assert.IsTrue(isPrintCommand);
        }
    }
}
