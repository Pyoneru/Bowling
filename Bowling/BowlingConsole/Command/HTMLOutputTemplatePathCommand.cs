using BowlingConsole.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Bowling;

namespace BowlingConsole.Command
{
    /// <summary>
    /// Set path to template for HTMLOutput
    /// </summary>
    public class HTMLOutputTemplatePathCommand : ICommand
    {
        public string FullFlag { get; set; }
        public string ShortFlag { get; set; }
        public string Description { get; set; }

        public HTMLOutput Output { get; protected set; }
        protected string templatePath;

        public HTMLOutputTemplatePathCommand()
        {
            FullFlag = Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG;
            ShortFlag = Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG;
            Description = Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_DESCRIPTION;
        }

        /// <summary>
        /// Copy only properties. 
        /// </summary>
        /// <returns>Clone of instance</returns>
        public object Clone()
        {
            HTMLOutputTemplatePathCommand command = new HTMLOutputTemplatePathCommand();
            command.FullFlag = FullFlag;
            command.ShortFlag = ShortFlag;
            command.Description = Description;
            return command;
        }

        /// <summary>
        /// Check if output or templatepath is null, if not then set TemplatePath
        /// </summary>
        public void Execute()
        {
            if (Output == null)
                throw new ArgumentNullException("Output is null");

            if (string.IsNullOrEmpty(templatePath))
                throw new ArgumentNullException("Template path is null or empty.");

            Output.TemplatePath = templatePath;
        }

        /// <summary>
        /// Get HTMLOutput and path to template
        /// </summary>
        /// <param name="data">HTMLOutput and string</param>
        public void SetData(params object[] data)
        {
            if(data.Length > 0)
            {
                Output = (HTMLOutput)data[0];

                if(data.Length > 1)
                {
                    string command = (string)data[1];
                    templatePath = command.Split("=")[1];
                }
                else
                {
                    templatePath = Output.TemplatePath;
                }
            }
        }
    }
}
