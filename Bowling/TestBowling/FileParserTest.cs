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

        [TestMethod]
        [DeploymentItem(@"data/good.txt")]
        public void CollectionIsNotEmptyFromGoodFile()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IParser parser = new FileParser(GetPath(goodFilename));

            ICollection<BowlingScore> bowlings = parser.Parse();

            Assert.IsTrue(bowlings.Count > 0);
        }

        private string GetPath(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.Location + "/../" + goodFilename;
        }
    }
}
