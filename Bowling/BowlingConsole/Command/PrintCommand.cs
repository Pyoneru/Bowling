using System;
using System.Collections.Generic;
using System.Text;
using BowlingConsole.Util;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Print output in console.
    /// </summary>
    public class PrintCommand : ICommand
    {

        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        protected string content;

        public PrintCommand()
        {
            FullFlag = Constants.PRINT_COMMAND_FULL_FLAG;
            ShortFlag = Constants.PRINT_COMMAND_SHORT_FLAG;
            Description = Constants.PRINT_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Just print content
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(content);
        }

        /// <summary>
        /// Create content. Sum all objects in data by ToString method.
        /// if data has not any element. do nothig.
        /// </summary>
        /// <param name="data">Data to print in console</param>
        public void SetData(params object[] data)
        {
            if(data.Length >= 1)
            {
                content = "";
                foreach(var obj in data)
                {
                    content += obj.ToString() + "\n";
                }
            }
        }
    }
}
