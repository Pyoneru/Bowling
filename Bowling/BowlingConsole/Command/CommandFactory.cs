using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Creator commands.
    /// </summary>
    public class CommandFactory
    {

        protected Dictionary<string, ICommand> prototypes;

        public CommandFactory()
        {
            prototypes = new Dictionary<string, ICommand>();
        }

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

                    if(!prototypes.ContainsKey(Constants.PRINT_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.PRINT_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.PRINT_COMMAND_FULL_FLAG, new PrintCommand());
                    }
                    command = (PrintCommand) prototypes[Constants.PRINT_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion PrintCommand

                #region HelpCommand
                case Constants.HELP_COMMAND_FULL_FLAG:
                case Constants.HELP_COMMAND_SHORT_FLAG:

                    if (!prototypes.ContainsKey(Constants.HELP_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.HELP_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.HELP_COMMAND_FULL_FLAG, new HelpCommand());
                    }
                    command = (HelpCommand) prototypes[Constants.HELP_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion HelpCommand

                #region OutputGenerateFileCommand
                case Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG:
                case Constants.OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG:

                    if (!prototypes.ContainsKey(Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG, new OutputGenerateFileCommand());
                    }
                    command = (OutputGenerateFileCommand) prototypes[Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion OutputGenerateFileCommand

                #region ErrorCommand
                case Constants.ERROR_COMMAND_FACTORY_FLAG:

                    if (!prototypes.ContainsKey(Constants.ERROR_COMMAND_FACTORY_FLAG))
                    {
                        prototypes.Add(Constants.ERROR_COMMAND_FACTORY_FLAG, new ErrorCommand());
                    }
                    command = (ErrorCommand) prototypes[Constants.ERROR_COMMAND_FACTORY_FLAG].Clone();

                    break;
                #endregion ErrorCommand

                #region OutputTypeCommand
                case Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG:
                case Constants.OUTPUT_TYPE_COMMAND_SHORT_FLAG:

                    if (!prototypes.ContainsKey(Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.OUTPUT_TYPE_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG, new OutputTypeCommand());
                    }
                    command = (OutputTypeCommand)prototypes[Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion OutputTypeCommand

                #region BowlingTypeCommand
                case Constants.BOWLING_TYPE_COMMAND_FULL_FLAG:
                case Constants.BOWLING_TYPE_COMMAND_SHORT_FLAG:

                    if (!prototypes.ContainsKey(Constants.BOWLING_TYPE_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.BOWLING_TYPE_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.BOWLING_TYPE_COMMAND_FULL_FLAG, new BowlingTypeCommand());
                    }
                    command = (BowlingTypeCommand)prototypes[Constants.BOWLING_TYPE_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion BowlingTypeCommand

                #region OutputCommand
                case Constants.OUTPUT_COMMAND_FULL_FLAG:
                case Constants.OUTPUT_COMMAND_SHORT_FLAG:

                    if (!prototypes.ContainsKey(Constants.OUTPUT_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.OUTPUT_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.OUTPUT_COMMAND_FULL_FLAG, new OutputCommand());
                    }
                    command = (OutputCommand)prototypes[Constants.OUTPUT_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion OutputCommand

                #region HTMLOutputTemplatePathCommand
                case Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG:
                case Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG:

                    if (!prototypes.ContainsKey(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG) &&
                        !prototypes.ContainsKey(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG))
                    {
                        prototypes.Add(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG, new HTMLOutputTemplatePathCommand());
                    }
                    command = (HTMLOutputTemplatePathCommand)prototypes[Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG].Clone();

                    break;
                #endregion HTMLOutputTemplatePathCommand
            }
            return command;
        }
    }
}
