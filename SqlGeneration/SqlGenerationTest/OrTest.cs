using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;

namespace SqlGenerationTest
{
    [TestClass]
    public class OrTest
    {

        [TestClass]
        public class Constructor
        {
            /// <summary>Parantheses for consistency and left AND right is obvious</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Initializes_ToString_To_Left_And_Right_With_Parentheses()
            {
                var myLeft = "asdfa";
                var myRight = "Fdasf;aosjf";
                var myLeftClause = new Clause(myLeft);
                var myRightClause = new Clause(myRight);

                Assert.AreEqual<string>(string.Format("({0}) OR ({1})", myLeft, myRight), new Or(myLeftClause, myRightClause).ToString());
            }
        }
    }
}
