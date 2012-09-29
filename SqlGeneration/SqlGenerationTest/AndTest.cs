using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;

namespace SqlGenerationTest
{
    [TestClass]
    public class AndTest
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

                Assert.AreEqual<string>(string.Format("({0}) AND ({1})", myLeft, myRight), new And(myLeftClause, myRightClause).ToString());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Initializes_ToString_As_Expected_With_Three_Claises()
            {
                var left = "asdfa";
                var middle = "a9sd8hfa9s8df";
                var right = "Fdasf;aosjf";
                var leftClause = new Clause(left);
                var middleClause = new Clause(middle);
                var rightClause = new Clause(right);

                Assert.AreEqual<string>(string.Format("({0}) AND ({1}) AND ({2})", left, middle, right), new And(leftClause, middleClause, rightClause).ToString());
            }
        }
    }
}
