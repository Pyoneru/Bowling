using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Bowling
{
    /// <summary>
    /// Parser for parse date from file with known structure.
    /// </summary>
    public class FileParser : IParser
    {
        #region Constants

        protected readonly char COMMA = ',';
        protected readonly char SPACE = ' ';
        protected readonly string WHITE_CHARACTERS_REGEX = @"\s+";
        protected readonly int POINTS_LENTGH = 22;

        #endregion Constants

        private string filename;

        /// <summary>
        /// Set path to file in constructor(filename)
        /// </summary>
        /// <param name="filename">path to file</param>
        public FileParser(string filename)
        {
            this.filename = filename;
        }


        #region Implemented method

        /// <summary>
        /// Parse file(filename) to collection of BowlingScore.
        /// </summary>
        /// <returns>BowlingScore collection</returns>
        public ICollection<BowlingScore> Parse()
        {
            List<BowlingScore> scores = new List<BowlingScore>();

            var reader = new StreamReader(filename);
            TwoLines two;
            while ((two = GetNextTwoLines(reader)) != null)
            {
                var name = two.First;
                var points = StringToPoints(two.Second);
                scores.Add(new BowlingScore(name, points));
            }
            reader.Close();
            return scores;
        }

        #endregion Implemented method

        #region Helper methods

        /// <summary>
        /// Read next two lines from StreamReader if exists.
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>If two lines were read, then return TwoLines object. If one line was not read, then return null</returns>
        protected TwoLines GetNextTwoLines(StreamReader reader)
        {
            var two = new TwoLines();

            if ((two.First = reader.ReadLine()) == null) return null;
            if ((two.Second = reader.ReadLine()) == null) return null;
            
            return two;
        }


        /// <summary>
        /// Convert one line with known structure to int array.
        /// </summary>
        /// <param name="line">line with points</param>
        /// <returns>int array (points)</returns>
        protected int[] StringToPoints(string line)
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
            if(idx < POINTS_LENTGH)
            {
                for(; idx < POINTS_LENTGH; idx++)
                {
                    points[idx] = -1;
                }
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
