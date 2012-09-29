using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;

namespace SqlGenerationTest
{
    [TestClass]
    public class NotTest
    {

        [TestClass]
        public class Constructor
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Initializes_ToString_To_Not_Plus_Parantheses_Plus_Clause_ToString()
            {
                var myClause = new Clause("asdF");
                var myNot = new Not(myClause);

                Assert.AreEqual<string>(String.Format("NOT ({0})", myClause), myNot.ToString());
            }
        }
    }
}
