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
    public class SimpleBowlingTest
    {
        private readonly string name = "Pyoneru";

        /// <summary>
        /// Final score without any collected bonus.
        /// </summary>
        [TestMethod]
        public void NoBonusScore()
        {
            var points = new int[] {
                4,5, // Round 1
                3,4, // Round 2
                7,1, // Round 3
                1,1, // Round 4
                2,5, // Round 5
                9,0, // Round 6
                2,3, // Round 7
                4,4, // Round 8
                3,6, // Round 9
                1,4, // Round 10
                -1,-1 // No additional throws
            };

            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            bowling.CountScore(ref score);

            int finalScore = score.Score;

            Assert.AreEqual(69, finalScore);
        }

        /// <summary>
        /// Final score with only one spare bonus.
        /// </summary>
        [TestMethod]
        public void OneSpareBonusScore()
        {
            var points = new int[] {
                5,5, // Round 1
                3,4, // Round 2
                7,1, // Round 3
                1,1, // Round 4
                2,5, // Round 5
                9,0, // Round 6
                2,3, // Round 7
                4,4, // Round 8
                3,6, // Round 9
                1,4, // Round 10
                -1,-1 // No additional throws
            };

            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            bowling.CountScore(ref score);

            int finalScore = score.Score;

            Assert.AreEqual(73, finalScore);
        }

        /// <summary>
        /// Final score with only one strike bonus.
        /// </summary>
        [TestMethod]
        public void OneStrikeBonusScore()
        {
            var points = new int[] {
                10, // Round 1
                3,5, // Round 2
                7,1, // Round 3
                1,1, // Round 4
                2,5, // Round 5
                9,0, // Round 6
                2,3, // Round 7
                4,4, // Round 8
                3,6, // Round 9
                1,4, // Round 10
                -1,-1,-1 // No additional throws
            };


            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            bowling.CountScore(ref score);

            int finalScore = score.Score;

            Assert.AreEqual(79, finalScore);
        }

        /// <summary>
        /// Final score with spare bonus in every round.
        /// </summary>
        [TestMethod]
        public void OnlySpareBonusScore()
        {
            var points = new int[] {
                1,9, // Round 1
                1,9, // Round 2
                1,9, // Round 3
                1,9, // Round 4
                1,9, // Round 5
                1,9, // Round 6
                1,9, // Round 7
                1,9, // Round 8
                1,9, // Round 9
                1,9, // Round 10
                9, // Addiontal throw
                -1 // No additional throw
            };


            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            bowling.CountScore(ref score);

            int finalScore = score.Score;

            Assert.AreEqual(118, finalScore);
        }

        /// <summary>
        /// Perfect game, collected 10 points with every one throw.
        /// </summary>
        [TestMethod]
        public void PerfectGameScore()
        {
            var points = new int[] {
                10, // Round 1
                10, // Round 2
                10, // Round 3
                10, // Round 4
                10, // Round 5
                10, // Round 6
                10, // Round 7
                10, // Round 8
                10, // Round 9
                10, // Round 10
                10,10, // Addiontal throws
                -1,-1,-1,-1,-1,-1,-1,-1,-1,-1, // No additional throws
            };

            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            bowling.CountScore(ref score);

            int finalScore = score.Score;

            Assert.AreEqual(300, finalScore);
        }

        /// <summary>
        /// Final score with combined collected bonuses.
        /// </summary>
        [TestMethod]
        public void CombineBonusScore()
        {
            var points = new int[] {
                10,         // Round 1
                9,1,        // Round 2
                7,1,        // Round 3
                1,9,        // Round 4
                10,         // Round 5
                9,0,        // Round 6
                2,3,        // Round 7
                4,4,        // Round 8
                3,6,        // Round 9
                1,4,        // Round 10
                -1,-1,-1,-1 // No additional throws
            };

            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            bowling.CountScore(ref score);

            int finalScore = score.Score;

            Assert.AreEqual(120, finalScore);
        }

        /// <summary>
        /// If bowling find bad data(out range) then throw ArgumentOutOfRangeException.
        /// </summary>
        [TestMethod]
        public void BadDataShouldThrowException()
        {
            var points = new int[] {
                1,9, // Round 1
                -1,9, // Round 2 <- -1 in this place is bad data
                1,9, // Round 3
                1,9, // Round 4
                1,9, // Round 5
                1,9, // Round 6
                1,9, // Round 7
                1,9, // Round 8
                1,9, // Round 9
                1,9, // Round 10
                9, // Addiontal throw
                -1 // No additional throw
            };

            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                bowling.CountScore(ref score);
            });
        }

        /// <summary>
        /// If player knock downed too many the pins in one round then throw ArgumentOutOfRangeException.
        /// Player can knock down max the 10 pins in one round.
        /// </summary>
        [TestMethod]
        public void TooManyKnockDownedThePinsInOneRound()
        {
            var points = new int[] {
                1,9, // Round 1
                9,9, // Round 2 <- 18 the pins knock downed in one round
                1,9, // Round 3
                1,9, // Round 4
                1,9, // Round 5
                1,9, // Round 6
                1,9, // Round 7
                1,9, // Round 8
                1,9, // Round 9
                1,9, // Round 10
                9, // Addiontal throw
                -1 // No additional throw
            };

            BowlingScore score = new BowlingScore(name, points);

            IBowling bowling = new SimpleBowling();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                bowling.CountScore(ref score);
            });
        }

    }
}
