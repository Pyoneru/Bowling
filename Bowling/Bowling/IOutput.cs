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
        /// Result of creating output
        /// </summary>
        public dynamic Output { get; set; }
        
        /// <summary>
        /// Create file output after created output, inside CreateOutput method.
        /// </summary>
        public bool CreateFileOutput { get; set; }


        /// <summary>
        /// Create output
        /// </summary>
        /// <param name="bowlings">Collection of BowlingScore</param>
        /// <param name="output">output name, it can be filename when implementation create file</param>
        /// <returns>result of created output</returns>
        public dynamic CreateOutput(ref ICollection<BowlingScore> bowlings, string output);

        /// <summary>
        /// Save output to file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveToFile(string filename);
    }
}
