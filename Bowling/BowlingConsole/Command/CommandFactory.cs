using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Command creator.
    /// </summary>
    public class CommandFactory
    {

        /// <summary>
        /// If command was not created before, create prototype.
        /// Return copy of prototype
        /// </summary>
        /// <param name="flag">Command flag</param>
        /// <returns>Copy of prototype</returns>
        public ICommand CreateCommand(string flag)
        {
            ICommand command = null;
            switch (flag)
            {
                #region PrintCommand
                case Constants.PRINT_COMMAND_FULL_FLAG:
                case Constants.PRINT_COMMAND_SHORT_FLAG:

                    command = new PrintCommand();

                    break;
                #endregion PrintCommand

                #region HelpCommand
                case Constants.HELP_COMMAND_FULL_FLAG:
                case Constants.HELP_COMMAND_SHORT_FLAG:

                    command = new HelpCommand();

                    break;
                #endregion HelpCommand

                #region OutputGenerateFileCommand
                case Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG:
                case Constants.OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG:

                    command = new OutputGenerateFileCommand();

                    break;
                #endregion OutputGenerateFileCommand

                #region ErrorCommand
                case Constants.ERROR_COMMAND_FACTORY_FLAG:

                    command = new ErrorCommand();

                    break;
                #endregion ErrorCommand

                #region OutputTypeCommand
                case Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG:
                case Constants.OUTPUT_TYPE_COMMAND_SHORT_FLAG:

                    command = new OutputTypeCommand();

                    break;
                #endregion OutputTypeCommand

                #region BowlingTypeCommand
                case Constants.BOWLING_TYPE_COMMAND_FULL_FLAG:
                case Constants.BOWLING_TYPE_COMMAND_SHORT_FLAG:

                    command = new BowlingTypeCommand();

                    break;
                #endregion BowlingTypeCommand

                #region OutputCommand
                case Constants.OUTPUT_COMMAND_FULL_FLAG:
                case Constants.OUTPUT_COMMAND_SHORT_FLAG:

                    command = new OutputCommand();

                    break;
                #endregion OutputCommand

                #region HTMLOutputTemplatePathCommand
                case Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG:
                case Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG:

                    command = new HTMLOutputTemplatePathCommand();

                    break;
                #endregion HTMLOutputTemplatePathCommand
            }
            return command;
        }
    }
}
