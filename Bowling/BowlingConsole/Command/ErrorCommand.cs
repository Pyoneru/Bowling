using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Print error message
    /// </summary>
    public class ErrorCommand : ICommand
    {
        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        protected string message;

        public ErrorCommand()
        {
            FullFlag = Constants.ERROR_COMMAND_FULL_FLAG;
            ShortFlag = Constants.ERROR_COMMAND_SHORT_FLAG;
            Description = Constants.ERROR_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Print message with red color
        /// </summary>
        public void Execute()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Set message
        /// </summary>
        /// <param name="data">Messages to print</param>
        public void SetData(params object[] data)
        {
            if(data.Length > 0)
            {
                message = "";
                foreach(var obj in data)
                {
                    message += obj.ToString() + "\n";
                }
            }
        }
    }
}
