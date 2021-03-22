using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Bowling
{
    public class FileParser : IParser
    {

        protected readonly char commna = ',';
        protected readonly char space = ' ';
        protected readonly string whiteCharacterRegex = @"\s+";
        protected readonly int pointsLength = 22;

        private string filename;

        public FileParser(string filename)
        {
            this.filename = filename;
        }

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

        protected TwoLines GetNextTwoLines(StreamReader reader)
        {
            var two = new TwoLines();

            if ((two.First = reader.ReadLine()) == null) return null;
            if ((two.Second = reader.ReadLine()) == null) return null;
            
            return two;
        }

        protected int[] StringToPoints(string line)
        {
            var points = new int[pointsLength];

            line = line.Replace(commna, space);

            var strPoints = Regex.Split(line, whiteCharacterRegex);

            var idx = 0;

            foreach (var strPoint in strPoints)
            {
                points[idx] = Convert.ToInt32(strPoint);
                idx++;
            }

            // Fill empty fields
            if(idx < pointsLength)
            {
                for(; idx < pointsLength; idx++)
                {
                    points[idx] = -1;
                }
            }

            return points;
        }

        protected class TwoLines
        {
            public string First { get; set; }
            public string Second { get; set; }
        }
    }
}
