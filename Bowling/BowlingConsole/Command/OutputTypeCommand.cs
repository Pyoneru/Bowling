using Bowling;
using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Set Output type
    /// </summary>
    public class OutputTypeCommand : ICommand
    {
        protected const string DEFAULT_TYPE = "html";

        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        public IOutput Output { get; protected set; }
        protected string type;

        public OutputTypeCommand()
        {
            FullFlag = Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG;
            ShortFlag = Constants.OUTPUT_TYPE_COMMAND_SHORT_FLAG;
            Description = Constants.OUTPUT_TYPE_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Copy only properties. 
        /// </summary>
        /// <returns>Clone of instance</returns>
        public object Clone()
        {
            OutputTypeCommand command = new OutputTypeCommand();
            command.FullFlag = FullFlag;
            command.ShortFlag = ShortFlag;
            command.Description = Description;
            return command;
        }

        /// <summary>
        /// Set output by type. If type not found, throw exception.
        /// </summary>
        public void Execute()
        {
            switch (type)
            {
                case DEFAULT_TYPE:
                    Output = new HTMLOutput();
                    break;
            }

            if (Output == null)
                throw new NullReferenceException("Type '" + type + "' of output not found");
        }

        /// <summary>
        /// Set custom type or use default.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(params object[] data)
        {
            if (data.Length > 0)
            {
                type = (string)data[0];
            }
            else
            {
                type = DEFAULT_TYPE;
            }
        }
    }
}
