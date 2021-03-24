using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Get filename from command
    /// </summary>
    public class OutputCommand : ICommand
    {
        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        public string Filename { get; protected set; }

        public OutputCommand()
        {
            FullFlag = Constants.OUTPUT_COMMAND_FULL_FLAG;
            ShortFlag = Constants.OUTPUT_COMMAND_SHORT_FLAG;
            Description = Constants.OUTPUT_COMMAND_DESCRIPTION;
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
        /// Check if filename is null or empty, then throw exception. Otherwise do nothing.
        /// </summary>
        public void Execute()
        {
            if (string.IsNullOrEmpty(Filename))
                throw new NullReferenceException("Filename is empty");
        }

        /// <summary>
        /// Extract filename from command
        /// </summary>
        /// <param name="data">command</param>
        public void SetData(params object[] data)
        {
            if(data.Length > 0)
            {
                string command = (string)data[0];

                Filename = command.Split("=")[1];
            }
        }
    }
}
