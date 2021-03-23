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
        public dynamic Output { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CreateFileOutput { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
