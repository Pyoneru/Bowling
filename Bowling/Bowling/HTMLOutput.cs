using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;

namespace Bowling
{
    /// <summary>
    /// Implementation of IOutput.
    /// Create output in html format.
    /// Implementation using RazorEngine library
    /// </summary>
    public class HTMLOutput : IOutput
    {
        /// <summary>
        /// Key needed by RazorEngine
        /// </summary>
        protected const string KEY = "html_bowling";

        /// <summary>
        /// By default is used DEFAULT_TEMPLATE_PATH to finding template file it you will not provide custom path.
        /// </summary>
        protected const string DEFAULT_TEMPLATE_PATH = "template.cshtml";

        public dynamic Output { get; set; }

        public bool CreateFileOutput { get; set; }

        /// <summary>
        /// Path to template
        /// </summary>
        public string TemplatePath { get; set; }

        public HTMLOutput(string templatePath)
        {
            templatePath = TemplatePath;
        }

        /// <summary>
        /// Constructor without use default template path
        /// </summary>
        public HTMLOutput(): this(DEFAULT_TEMPLATE_PATH) { }


        /// <summary>
        /// Implementation method.
        /// Create Output. Save to file if option is enabled and return Output.
        /// </summary>
        /// <param name="bowlings">Collection of BowlingScore</param>
        /// <param name="output">filename to save</param>
        /// <returns>Output</returns>
        public dynamic CreateOutput(ref ICollection<BowlingScore> bowlings, string output)
        {
            CreateOutputFromTemplate(ref bowlings);

            if (CreateFileOutput)
            {
                SaveToFile(output);
            }

            return Output;
        }

        /// <summary>
        /// Create output html.
        /// Separate creating output from saving to file.
        /// </summary>
        /// <param name="bowlings">Collection of BowlingScore</param>
        protected void CreateOutputFromTemplate(ref ICollection<BowlingScore> bowlings)
        {
            var template = File.ReadAllText(TemplatePath);

            Output = Engine.Razor.RunCompile(template, KEY, null, bowlings);
        }

        /// <summary>
        /// Invoke SaveToFileAsync
        /// </summary>
        /// <param name="filename">filename to save</param>
        public void SaveToFile(string filename)
        {
            _ = SaveToFileAsync(filename);
        }

        /// <summary>
        /// Asynchronous saving Output to file.
        /// </summary>
        /// <param name="filename">filename to save</param>
        /// <returns>Task</returns>
        protected async Task SaveToFileAsync(string filename)
        {
            await File.WriteAllTextAsync(filename, Output);
        }
    }
}
