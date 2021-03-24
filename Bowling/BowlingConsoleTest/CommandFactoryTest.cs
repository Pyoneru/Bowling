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

        #region NullTests
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

            ICommand command = factory.CreateCommand(badFlag);

            Assert.IsNull(command);
        }
        #endregion NullTests

        #region PrintCommand
        /// <summary>
        /// Full flag of PrintCommand should return instance of PrintCommand
        /// </summary>
        [TestMethod]
        public void CreatePrintCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);

            var isCommand = command is PrintCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of PrintCommand should return instance of PrintCommand
        /// </summary>
        [TestMethod]
        public void CreatePrintCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.PRINT_COMMAND_SHORT_FLAG);

            var isCommand = command is PrintCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion PrintCommand

        #region HelpCommand
        /// <summary>
        /// Full flag of HelpCommand should return instance of HelpCommand
        /// </summary>
        [TestMethod]
        public void CreateHelpCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_FULL_FLAG);

            var isCommand = command is HelpCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of HelpCommand should return instance of HelpCommand
        /// </summary>
        [TestMethod]
        public void CreateHelpCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HELP_COMMAND_SHORT_FLAG);

            var isCommand = command is HelpCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion HelpCommand

        #region ErrorCommand
        /// <summary>
        /// Flag of ErrorCommand should return instance of ErrorCommand
        /// </summary>
        [TestMethod]
        public void CreateErrorCommandFlag()
        {
            ICommand command = factory.CreateCommand(Constants.ERROR_COMMAND_FACTORY_FLAG);

            var isCommand = command is ErrorCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion ErrorCommand

        #region BowlingTypeCommand
        /// <summary>
        /// Full flag of BowlingTypeCommand should return instance of BowlingTypeCommand
        /// </summary>
        [TestMethod]
        public void CreateBowlingTypeCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.BOWLING_TYPE_COMMAND_FULL_FLAG);

            var isCommand = command is BowlingTypeCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of BowlingTypeCommand should return instance of BowlingTypeCommand
        /// </summary>
        [TestMethod]
        public void CreateBowlingTypeCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.BOWLING_TYPE_COMMAND_SHORT_FLAG);

            var isPrintCommand = command is BowlingTypeCommand;

            Assert.IsTrue(isPrintCommand);
        }
        #endregion BowlingTypeCommand

        #region HTMLOutputTemplatePathCommand
        /// <summary>
        /// Full flag of HTMLOutputTemplatePathCommand should return instance of HTMLOutputTemplatePathCommand
        /// </summary>
        [TestMethod]
        public void CreateHTMLOutputTemplatePathCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG);

            var isCommand = command is HTMLOutputTemplatePathCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of HTMLOutputTemplatePathCommand should return instance of HTMLOutputTemplatePathCommand
        /// </summary>
        [TestMethod]
        public void CreateHTMLOutputTemplatePathCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG);

            var isCommand = command is HTMLOutputTemplatePathCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion HTMLOutputTemplatePathCommand

        #region OutputCommand
        /// <summary>
        /// Full flag of OutputCommand should return instance of OutputCommand
        /// </summary>
        [TestMethod]
        public void CreateOutputCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.OUTPUT_COMMAND_FULL_FLAG);

            var isCommand = command is OutputCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of OutputCommand should return instance of OutputCommand
        /// </summary>
        [TestMethod]
        public void CreateOutputCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.OUTPUT_COMMAND_SHORT_FLAG);

            var isCommand = command is OutputCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion OutputCommand

        #region OutputGenerateFileCommand
        /// <summary>
        /// Full flag of OutputGenerateFileCommand should return instance of OutputGenerateFileCommand
        /// </summary>
        [TestMethod]
        public void CreateOutputGenerateFileCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG);

            var isCommand = command is OutputGenerateFileCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of OutputGenerateFileCommand should return instance of OutputGenerateFileCommand
        /// </summary>
        [TestMethod]
        public void CreateOutputGenerateFileCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG);

            var isCommand = command is OutputGenerateFileCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion OutputGenerateFileCommand

        #region OutputTypeCommand
        /// <summary>
        /// Full flag of OutputTypeCommand should return instance of OutputTypeCommand
        /// </summary>
        [TestMethod]
        public void CreateOutputTypeCommandFullFlag()
        {
            ICommand command = factory.CreateCommand(Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG);

            var isCommand = command is OutputTypeCommand;

            Assert.IsTrue(isCommand);
        }

        /// <summary>
        /// Short flag of OutputTypeCommand should return instance of OutputTypeCommand
        /// </summary>
        [TestMethod]
        public void CreateOutputTypeCommandShortFlag()
        {
            ICommand command = factory.CreateCommand(Constants.OUTPUT_TYPE_COMMAND_SHORT_FLAG);

            var isCommand = command is OutputTypeCommand;

            Assert.IsTrue(isCommand);
        }
        #endregion OutputTypeCommand
    }
}
