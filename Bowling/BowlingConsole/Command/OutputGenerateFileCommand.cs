using Bowling;
using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Set CreateFileOutput propertie
    /// </summary>
    public class OutputGenerateFileCommand : ICommand
    {
        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        protected IOutput output;
        protected bool generate;

        public OutputGenerateFileCommand()
        {
            FullFlag = Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG;
            ShortFlag = Constants.OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG;
            Description = Constants.OUTPUT_GENERATE_FILE_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Copy only properties. 
        /// </summary>
        /// <returns>Clone of instance</returns>
        public object Clone()
        {
            OutputGenerateFileCommand command = new OutputGenerateFileCommand();
            command.FullFlag = FullFlag;
            command.ShortFlag = ShortFlag;
            command.Description = Description;
            return command;
        }

        /// <summary>
        /// Set CreateFileOutput properties in IOutput instance
        /// </summary>
        public void Execute()
        {
            output.CreateFileOutput = generate;
        }

        /// <summary>
        /// Set generate or use false by defualt
        /// </summary>
        /// <param name="data">IOuput and bool for setting generate</param>
        public void SetData(params object[] data)
        {
            if(data.Length > 0)
            {
                output = (IOutput)data[0];

                if (data.Length > 1)
                {
                    generate = (bool)data[1];
                }
                else
                {
                    generate = false;
                }
            }
        }
    }
}
