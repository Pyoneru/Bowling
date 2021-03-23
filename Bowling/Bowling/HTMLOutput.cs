using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class HTMLOutput : IOutput
    {
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
            throw new NotImplementedException();
        }

        public void SaveToFile(string filename)
        {
            throw new NotImplementedException();
        }

        
    }
}
