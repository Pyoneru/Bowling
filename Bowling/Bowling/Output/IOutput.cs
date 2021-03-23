using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    /// <summary>
    /// Create output for collections of BowlingScore
    /// </summary>
    public interface IOutput
    {

        /// <summary>
        /// Result of created output
        /// </summary>
        public dynamic Output { get; set; }
        
        /// <summary>
        /// Create file output after created output, should be used inside CreateOutput method.
        /// </summary>
        public bool CreateFileOutput { get; set; }


        /// <summary>
        /// Create output by input data (bowlings).
        /// </summary>
        /// <param name="bowlings">Collection of BowlingScore</param>
        /// <param name="output">Output name, it can be filename when the implementation will creating file as output</param>
        /// <returns>Result of created output</returns>
        public dynamic CreateOutput(ref ICollection<BowlingScore> bowlings, string output);

        /// <summary>
        /// Save output to file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveToFile(string filename);
    }
}
