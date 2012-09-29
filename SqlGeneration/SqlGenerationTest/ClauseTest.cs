using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;

namespace SqlGenerationTest
{
    [TestClass]
    public class ClauseTest
    {
        [TestClass]
        public class Constructor
        {
            /// <summary>
            /// This is going to be an immutable object that simply prints what it's initialized with
            /// </summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Initializes_ToString_To_Passed_In_Value()
            {
                string myClauseValue = "asdf";
                Assert.AreEqual<string>(myClauseValue, new Clause(myClauseValue).ToString());
            }
        }
    }
}
