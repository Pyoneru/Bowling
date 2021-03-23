using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Bowling
{
    /// <summary>
    /// Parser for data from file with known structure.
    /// </summary>
    public class FileParser : IParser
    {
        #region Constants

        protected readonly char COMMA = ',';
        protected readonly char SPACE = ' ';
        protected readonly string WHITE_CHARACTERS_REGEX = @"\s+";
        protected readonly int POINTS_LENTGH = 22;

        #endregion Constants

        protected string filename;

        /// <summary>
        /// Set path to file in constructor(filename)
        /// </summary>
        /// <param name="filename">Path to file</param>
        public FileParser(string filename)
        {
            this.filename = filename;
        }

        #region Implemented method

        /// <summary>
        /// Parse file(filename) to collection of BowlingScore.
        /// </summary>
        /// <returns>Collection of BowlingScore</returns>
        public ICollection<BowlingScore> Parse()
        {
            List<BowlingScore> scores = new List<BowlingScore>();

            var reader = new StreamReader(filename);
            TwoLines two = new TwoLines();
            while (GetNextTwoLines(reader, ref two))
            {
                var name = two.First;
                var points = LinePointsToIntArray(two.Second);

                scores.Add(new BowlingScore(name, points));
            }
            reader.Close();

            return scores;
        }

        #endregion Implemented method

        #region Helper methods

        /// <summary>
        /// Read next to two lines from reader.
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="two">Refernce to TwoLines object</param>
        /// <returns>True if two lines were read correct, false in otherwise</returns>
        protected bool GetNextTwoLines(StreamReader reader, ref TwoLines twoLines)
        {
            if ((twoLines.First = reader.ReadLine()) == null) return false;
            if ((twoLines.Second = reader.ReadLine()) == null) return false;
            
            return true;
        }


        /// <summary>
        /// Convert one line with known structure to int array.
        /// </summary>
        /// <param name="line">line with points</param>
        /// <returns>Points as int array</returns>
        protected int[] LinePointsToIntArray(string line)
        {
            var points = new int[POINTS_LENTGH];

            line = line.Replace(COMMA, SPACE); // remove all comma from line

            var strPoints = Regex.Split(line, WHITE_CHARACTERS_REGEX);

            var idx = 0;

            foreach (var strPoint in strPoints)
            {
                points[idx] = Convert.ToInt32(strPoint);
                idx++;
            }

            // Fill empty fields
            for(; idx < POINTS_LENTGH; idx++)
            {
                points[idx] = -1;
            }

            return points;
        }

        #endregion Helper Methods

        /// <summary>
        /// Helper class, contains only two string to saved two lines from file.
        /// </summary>
        protected class TwoLines
        {
            public string First { get; set; }
            public string Second { get; set; }
        }
    }
}
