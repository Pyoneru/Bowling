using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    /// <summary>
    /// Primary implementation of algorithm of counting final score in bowling
    /// </summary>
    public class SimpleBowling : IBowling
    {
        #region Algorithm
        /// <summary>
        /// Implementation of algorithm to count final score in bowling.
        /// </summary>
        /// <param name="score"></param>
        public void CountScore(ref BowlingScore score)
        {
            int finalScore = 0;
            int round = 1;
            int index = 0;

            while(round <= 10)
            {
                if (InRange(score[index]))
                {
                    int roundScore = score[index];

                    if(roundScore == 10)
                    {
                        AddValueOrThrowExecption(ref roundScore, score[index + 1]);
                        AddValueOrThrowExecption(ref roundScore, score[index + 2]);
                        index += 1;
                    }
                    else
                    {
                        AddValueOrThrowExecption(ref roundScore, score[index + 1]);

                        if (roundScore == 10)
                        {
                            AddValueOrThrowExecption(ref roundScore, score[index + 2]);
                        }
                        else if(roundScore > 10)
                        {
                            throw new ArgumentOutOfRangeException("Round score is out of range(0-10) [" + roundScore + "]");
                        }
                        index += 2;
                    }
                    finalScore += roundScore;
                    round++;
                }
            }
            score.Score = finalScore;
        }

        #endregion Algorithm

        #region Helper methods

        /// <summary>
        /// If value is in range then add it to roundScore
        /// </summary>
        /// <param name="roundScore">sum of colleceted points in one round</param>
        /// <param name="value">knock downed the pins in one throw</param>
        protected void AddValueOrThrowExecption(ref int roundScore, int value)
        {
            if (InRange(value))
            {
                roundScore += value;
            }
        }

        /// <summary>
        /// If value is out of range 0-10 then throw exception, otherwise return true
        /// </summary>
        /// <param name="value">knock downed the pins in one throw</param>
        /// <returns>true if exception was not thrown</returns>
        protected bool InRange(int value)
        {
            if (value < 0 || value > 10)
                throw new ArgumentOutOfRangeException("Bad value. [" + value + "] is not in range 0-10.");
            return true;
        }

        #endregion Helper methods
    }
}
