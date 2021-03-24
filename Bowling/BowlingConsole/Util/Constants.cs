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
        public const string OUTPUT_TYPE_COMMAND_SHORT_FLAG = "-to";
        public const string OUTPUT_TYPE_COMMAND_DESCRIPTION = "Chanage output type generation. Only html type is available in this version. Use example: '-to=html'";

        #endregion OutputTypeCommand

        #region BowlingTypeCommand

        public const string BOWLING_TYPE_COMMAND_FULL_FLAG = "--type-bowling";
        public const string BOWLING_TYPE_COMMAND_SHORT_FLAG = "-tb";
        public const string BOWLING_TYPE_COMMAND_DESCRIPTION = "Change implementation of score counter. Only simple implementation is available in this version. Use example: '-tb=simple'";

        #endregion BowlingTypeCommand

        #region OutputCommand

        public const string OUTPUT_COMMAND_FULL_FLAG = "--output";
        public const string OUTPUT_COMMAND_SHORT_FLAG = "-o";
        public const string OUTPUT_COMMAND_DESCRIPTION = "Change default output file name. Use example: '-o=FILENAME_WITHOUT_SPACE'";

        #endregion OutputCommand

        #region HTML_OUTPUT_TEMPLATE_PATH_COMMAND

        public const string HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG = "--html-template-path";
        public const string HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG = "-html-tp";
        public const string HTML_OUTPUT_TEMPLATE_PATH_COMMAND_DESCRIPTION = "Specific command for html work. That's means this command work only if html output is used. Use example: '--html-template-path=PATH_TO_TEMPLE'";

        #endregion HTML_OUTPUT_TEMPLATE_PATH_COMMAND
    }
}
