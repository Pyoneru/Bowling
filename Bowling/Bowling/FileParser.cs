using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bowling
{
    public class FileParser : IParser
    {
        
        private string filename;

        public FileParser(string filename)
        {
            this.filename = filename;
        }

        public ICollection<BowlingScore> Parse()
        {
            StreamReader reader = new StreamReader(filename);

            return null;
        }
    }
}
