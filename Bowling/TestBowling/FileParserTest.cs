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
        private const string badFilename = "bad.txt";
        private const string noExistsFilename = "no_exists.txt";
        private const string badPointsFilename = "bad_points.txt";
        private const string noPointsFilename = "no_points.txt";


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

            var it = bowlings.GetEnumerator();
            it.MoveNext();

            var bowling = it.Current;
            var name = bowling.Name;
        
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

            var it = bowlings.GetEnumerator();
            it.MoveNext();

            var bowling = it.Current;
            int[] points = bowling.Points;

            // Empty fields are initialized by -1
            int notFilled = 0;
            foreach (var point in points)
            {
                if (point == -1) notFilled++;
            }

            Assert.AreNotEqual(22, notFilled);
        }

        /// <summary>
        /// If line with points exists but not contains any one point, should be avoided.
        /// </summary>
        [TestMethod]
        public void PointsAreNotFilledFromBadFile()
        {
            IParser parser = new FileParser(GetPath(noPointsFilename));

            var bowlings = parser.Parse();

            var sizeOfBowlings = bowlings.Count;

            Assert.AreEqual(1, sizeOfBowlings);
        }

        /// <summary>
        /// File 'bad.txt' should contains one full object(name and points) and one not full object(only name).
        /// Parser should return collection with only one element.
        /// </summary>
        [TestMethod]
        public void NotAddScoreToCollectionIfDataIsNotFull()
        {
            IParser parser = new FileParser(GetPath(badFilename));

            var bowlings = parser.Parse();

            int size = bowlings.Count;

            Assert.AreEqual(1, size);
        }

        /// <summary>
        /// Throw FileNotFoundException if not found the file.
        /// </summary>
        [TestMethod]
        public void BadFileNameShouldThrowFileNotFoundException()
        {
            IParser parser = new FileParser(GetPath(noExistsFilename));

            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                var bowlings = parser.Parse();
            });
        }

        /// <summary>
        /// If any point has bad format then throw execption(can not convert to int).
        /// </summary>
        [TestMethod]
        public void BadPointsDataShouldThrowException()
        {
            IParser parser = new FileParser(GetPath(badPointsFilename));

            Assert.ThrowsException<FormatException>(() =>
            {
                var bowlings = parser.Parse();
            });
        }

        /// <summary>
        /// Get path to file in output directory.
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Global path to file</returns>
        private string GetPath(string filename)
        {
            return Environment.CurrentDirectory + "/data/" + filename;
        }
    }
}
