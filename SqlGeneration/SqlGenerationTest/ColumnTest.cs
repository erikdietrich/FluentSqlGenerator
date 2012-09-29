using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;

namespace SqlGenerationTest
{
    [TestClass]
    public class ColumnTest
    {
        [TestClass]
        public class Constructor
        {
            /// <summary>When created the column's name should match what is passed in</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Initializes_ToString_To_Passed_In_Value()
            {
                const string myName = "23";
                var myColumn = new Column(myName);

                Assert.AreEqual<string>(myName, myColumn.ToString());
            }
        }

        [TestClass]
        public class Named
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_New_Column_With_Name_ToString_To_Passed_In_Value()
            {
                const string columnName = "asdF";

                Assert.AreEqual<string>(columnName, Column.Named(columnName).ToString());
            }
        }
    }
}
