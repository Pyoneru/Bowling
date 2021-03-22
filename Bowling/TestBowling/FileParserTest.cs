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


        private string GetPath(string filename)
        {
            return Assembly.GetExecutingAssembly().Location + "/../" + goodFilename;
        }
    }
}
