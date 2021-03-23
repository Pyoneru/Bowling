using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace TestBowling
{
    [TestClass]
    public class HTMLOutputTest
    {
        private IOutput output;

        /// <summary>
        /// For test, do not create output file. Output will be created only in Output propertie.
        /// </summary>
        public HTMLOutputTest()
        {
            output = new HTMLOutput("data/template.cshtml");
            output.CreateFileOutput = false;
        }

        /// <summary>
        /// Output should not be null or empty after created.
        /// </summary>
        [TestMethod]
        public void OutputIsNotNullOrEmpty()
        {
            ICollection<BowlingScore> scores = new List<BowlingScore>();
            scores.Add(GetBowlingScore());
            scores.Add(GetBowlingScore());

            output.CreateOutput(ref scores, "");

            string outputContent = output.Output;

            Assert.IsNotNull(outputContent);
            Assert.IsTrue(outputContent.Length > 0);
        }

        /// <summary>
        /// Output should contains two names(with 2 scores).
        /// </summary>
        [TestMethod]
        public void OutputContainsName()
        {
            ICollection<BowlingScore> scores = new List<BowlingScore>();
            scores.Add(GetBowlingScore());
            scores.Add(GetBowlingScore());

            output.CreateOutput(ref scores, "");

            string outputContent = output.Output;

            var enumerator = scores.GetEnumerator();

            enumerator.MoveNext();
            var nameFirst = enumerator.Current.Name;

            enumerator.MoveNext();
            var nameSecond = enumerator.Current.Name;

            var containsName = outputContent.Contains(nameFirst) && outputContent.Contains(nameSecond) ;

            Assert.IsTrue(containsName);
        }

        /// <summary>
        /// Output content should contains all numbers at 'score'.
        /// </summary>
        [TestMethod]
        public void OutputContainsPoints()
        {
            ICollection<BowlingScore> scores = new List<BowlingScore>();
            scores.Add(GetBowlingScore());

            output.CreateOutput(ref scores, "");

            string outputContent = output.Output;
            var it = scores.GetEnumerator();
            it.MoveNext();
            var score = it.Current;

            var containsAllPoints = true;
            foreach(var point in score.Points)
            {
                if (!outputContent.Contains(Convert.ToString(point)))
                {
                    containsAllPoints = false;
                    break;
                }
            }

            Assert.IsTrue(containsAllPoints);
        }

        /// <summary>
        /// Generate BowlingScore without any bonus
        /// </summary>
        /// <returns>New instance of BowlingScore</returns>
        private BowlingScore GetBowlingScore()
        {
            var names = new string[]{ "Pyoneru", "Peter", "Batman", "Cezary" };

            var points = new int[22];

            var rnd = new Random();
            for(int i = 0; i < 20; i++)
            {
                points[i] = rnd.Next(5); // generate numbers lower then 5(no bonus)
            }
            // Last two fields are empty.
            points[20] = -1;
            points[21] = -1;

            var score = new BowlingScore(names[rnd.Next(4)], points);
            score.Score = rnd.Next(50, 250);
            
            return score;
        }
    }
}
