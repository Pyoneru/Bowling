using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;
using System.Collections.Generic;
using System.IO;
using System;
using System.Reflection;

namespace TestBowling
{
    [TestClass]
    public class FileParserTest
    {
        private const string goodFilename = "good.txt";

        /// <summary>
        /// Test file contains at least one person with points. Then parser should return list which is not empty. 
        /// </summary>
        [TestMethod]
        public void CollectionIsNotEmptyFromGoodFile()
        {
            IParser parser = new FileParser(GetPath(goodFilename));

            var bowlings = parser.Parse();

            Assert.IsTrue(bowlings.Count > 0);
        }

        /// <summary>
        /// Objects should contains some data after parsed. 
        /// </summary>
        [TestMethod]
        public void NameIsNotEmpyOrNullFromGoodFile()
        {
            IParser parser = new FileParser(GetPath(goodFilename));

            var bowlings = parser.Parse();

            var bowling = bowlings.GetEnumerator().Current;

            string name = bowling.Name;
        
            Assert.IsNotNull(name);
            Assert.IsFalse(name.Length == 0);
        }

        /// <summary>
        /// Empty fields are marked by -1(the player did not throw the ball). 
        /// If all points are equals to -1, that means parser work incorrect.
        /// </summary>
        [TestMethod]
        public void PointsAreFilledFromGoodFile()
        {
            IParser parser = new FileParser(GetPath(goodFilename));

            var bowlings = parser.Parse();

            var bowling = bowlings.GetEnumerator().Current;

            int[] points = bowling.Points;

            // Empty fields are initialized by -1
            int notFilled = 0;
            foreach (var point in points)
            {
                if (point == -1) notFilled++;
            }

            Assert.AreNotEqual(22, notFilled);
        }


        private string GetPath(string filename)
        {
            return Assembly.GetExecutingAssembly().Location + "/../" + goodFilename;
        }
    }
}
