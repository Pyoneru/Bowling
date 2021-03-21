using System;
using System.Collections.Generic;

namespace Bowling
{
    public class BowlingScore
    {
        #region Properties

        /// <summary>
        /// Nickname for user
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Collected points by user
        /// </summary>
        public int[] Points { get; }
        /// <summary>
        /// Final score
        /// </summary>
        public int Score { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize name and points properties
        /// </summary>
        /// <param name="name">Nickname for user</param>
        /// <param name="points">Collected points by user</param>
        public BowlingScore(string name, int[] points)
        {
            CheckPointsLenth(points);
            Name = name;
            Points = points;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// If length of points array is different from 22, then throw ArugemtnException
        /// </summary>
        /// <param name="points">Collected points by user</param>
        protected void CheckPointsLenth(int[] points)
        {
            if (points.Length != 22)
                throw new ArgumentException("BowlingScore points must have exactly 22 elements");
        }

        #endregion Methods


        #region Equals and HashCode

        /// <summary>
        /// Generated Equals method by Visual Studio
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>true if obj is the same as this object, false otherwise</returns>
        public override bool Equals(object obj)
        {
            return obj is BowlingScore score &&
                   Name == score.Name &&
                   EqualityComparer<int[]>.Default.Equals(Points, score.Points) &&
                   Score == score.Score;
        }

        /// <summary>
        /// Generated GetHashCode method by Visual Studio
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Points, Score);
        }

        #endregion Equals and HashCode
    }
}
