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
    public class HTMLOutput : IOutput
    {
        protected const string KEY = "html_bowling";
        protected const string DEFAULT_TEMPLATE_PATH = "template.cshtml";
        public dynamic Output { get; set; }
        public bool CreateFileOutput { get; set; }

        public string TemplatePath { get; set; }

        public HTMLOutput(string templatePath)
        {
            templatePath = TemplatePath;
        }

        public HTMLOutput(): this(DEFAULT_TEMPLATE_PATH) { }

        public dynamic CreateOutput(ref ICollection<BowlingScore> bowlings, string output)
        {
            var template = File.ReadAllText(TemplatePath);

            Output = Engine.Razor.RunCompile(template, KEY, null, bowlings);

            if (CreateFileOutput)
            {
                SaveToFile(output);
            }

            return Output;
        }

        public void SaveToFile(string filename)
        {
            _ = SaveToFileAsync(filename);
        }

        protected async Task SaveToFileAsync(string filename)
        {
            await File.WriteAllTextAsync(filename, Output);
        }
    }
}
