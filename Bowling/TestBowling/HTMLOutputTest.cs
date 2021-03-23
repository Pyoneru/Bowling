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
        private HTMLOutput output;

        /// <summary>
        /// For test, do not create output file. Output will be created only in Output propertie.
        /// </summary>
        public HTMLOutputTest()
        {
            output = new HTMLOutput();
            output.CreateFileOutput = false;
        }
    }
}
