using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Util
{
    public static class Constants
    {
        #region PrintCommand

        public const string PRINT_COMMAND_FULL_FLAG = "--print";
        public const string PRINT_COMMAND_SHORT_FLAG = "-p";
        public const string PRINT_COMMAND_DESCRIPTION = "Print output in console";

        #endregion PrintCommand

        #region HelpCommand

        public const string HELP_COMMAND_FULL_FLAG = "--help";
        public const string HELP_COMMAND_SHORT_FLAG = "-h";
        public const string HELP_COMMAND_DESCRIPTION = "Use --help and command flag to print description for this command";

        #endregion HelpCommand

        #region OutputGenerateFileCommand

        public const string OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG = "--nofile";
        public const string OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG = "-nf";
        public const string OUTPUT_GENERATE_FILE_COMMAND_DESCRIPTION = "Use this flag to not generating file output";

        #endregion OutputGenerateFileCommand

        #region ErrorCommand

        public const string ERROR_COMMAND_FULL_FLAG = "";
        public const string ERROR_COMMAND_SHORT_FLAG = "";
        public const string ERROR_COMMAND_DESCRIPTION = "";

        #endregion ErrorCommand

        #region OutputTypeCommand

        public const string OUTPUT_TYPE_COMMAND_FULL_FLAG = "--type-output";
        public const string OUTPUT_TYPE_COMMAND_SHORT_FLAG = "--to";
        public const string OUTPUT_TYPE_COMMAND_DESCRIPTION = "Chanage output type generation. You can use only html type in this version";

        #endregion OutputTypeCommand
    }
}
