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
        /// Create output
        /// </summary>
        /// <param name="bowlings">Collection of BowlingScore</param>
        /// <param name="output">output name, it can be filename when implementation create file</param>
        /// <returns>result of created output</returns>
        public int CreateOutput(ref ICollection<BowlingScore> bowlings, string output);

        /// <summary>
        /// Get specific message for result given from CreateOutput method
        /// </summary>
        /// <param name="result">result given from CreateOutput method</param>
        /// <returns>Specific message</returns>
        public string GetResultMessage(int result);
    }
}
