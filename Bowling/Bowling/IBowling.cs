using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    /// <summary>
    /// Count final bowling score and set Score propertie it BowlingScore object
    /// </summary>
    public interface IBowling
    {
        /// <summary>
        /// Count final bowling score.
        /// </summary>
        /// <param name="score">Instance of BowlingScore</param>
        public void CountScore(ref BowlingScore score);
    }
}
