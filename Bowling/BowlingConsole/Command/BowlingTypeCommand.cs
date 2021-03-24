using Bowling;
using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Set Conter score type(Bowling implementation)
    /// </summary>
    public class BowlingTypeCommand : ICommand
    {
        protected const string DEFAULT_TYPE = "simple";

        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        public IBowling Bowling { get; protected set; }
        protected string type;

        public BowlingTypeCommand()
        {
            FullFlag = Constants.BOWLING_TYPE_COMMAND_FULL_FLAG;
            ShortFlag = Constants.BOWLING_TYPE_COMMAND_SHORT_FLAG;
            Description = Constants.BOWLING_TYPE_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Copy only properties. 
        /// </summary>
        /// <returns>Clone of instance</returns>
        public object Clone()
        {
            BowlingTypeCommand command = new BowlingTypeCommand();
            command.FullFlag = FullFlag;
            command.ShortFlag = ShortFlag;
            command.Description = Description;
            return command;
        }

        /// <summary>
        /// Set bowling by type. If type not found, throw exception.
        /// </summary>
        public void Execute()
        {
            switch (type)
            {
                case DEFAULT_TYPE:
                    Bowling = new SimpleBowling();
                    break;
            }

            if (Bowling == null)
                throw new ArgumentNullException("Type '" + type + "' of bowling not found");
        }

        /// <summary>
        /// Set custom type or use default.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(params object[] data)
        {
            if (data.Length > 0)
            {
                string command = (string)data[0];
                type = command.Split("=")[1];
            }
            else
            {
                type = DEFAULT_TYPE;
            }
        }
    }
}
