using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Print description for all available commands or specific commands given by user
    /// </summary>
    public class HelpCommand : ICommand
    {
        protected const int ALL_AVAILABLE_FLAGS = 7;

        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        protected CommandFactory factory;
        protected string[] flags;

        public HelpCommand()
        {
            FullFlag = Constants.HELP_COMMAND_FULL_FLAG;
            ShortFlag = Constants.HELP_COMMAND_SHORT_FLAG;
            Description = Constants.HELP_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Copy only properties. 
        /// </summary>
        /// <returns>Clone of instance</returns>
        public object Clone()
        {
            HelpCommand command = new HelpCommand();
            command.FullFlag = FullFlag;
            command.ShortFlag = ShortFlag;
            command.Description = Description;
            return command;
        }

        /// <summary>
        /// Print description for every available command or print error.
        /// </summary>
        public void Execute()
        {
            if(factory != null)
            {
                foreach(var flag in flags)
                {
                    Console.WriteLine("You need give filename in arguments.\n");
                    ICommand command = factory.CreateCommand(flag);
                    if(command != null)
                    {
                        Console.WriteLine(command.Description + "\n");
                    }
                    else
                    {
                        Console.WriteLine("Command {0} not found", flag);
                    }
                }
            }
            else
            {
                Console.WriteLine("CommandFactory not found");
            }
        }

        /// <summary>
        /// Initialize Command Factory and add commands to print. Defined by user or add all available.
        /// </summary>
        /// <param name="data">CommandFactory and flags</param>
        public void SetData(params object[] data)
        {
            if(data.Length > 0)
            {
                factory = (CommandFactory)data[0];

                if(data.Length > 1)
                {
                    flags = new string[data.Length - 1];
                    for (int i = 1; i < data.Length; i++)
                        flags[i - 1] = data[i].ToString();
                }
                else
                {
                    flags = new string[]{
                        Constants.HELP_COMMAND_FULL_FLAG,
                        Constants.PRINT_COMMAND_FULL_FLAG,
                        Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG,
                        Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG,
                        Constants.BOWLING_TYPE_COMMAND_FULL_FLAG,
                        Constants.OUTPUT_COMMAND_FULL_FLAG,
                        Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG
                    };
                }
            }
        }
    }
}
