using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    /// <summary>
    /// Parse data to collection of BowlingScore
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Return parsed data to collection of BowlingScore
        /// </summary>
        /// <returns>Collection of BowlingScore</returns>
        public ICollection<BowlingScore> Parse();
    }
}
