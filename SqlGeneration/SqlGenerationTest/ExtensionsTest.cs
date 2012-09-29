using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;
using SqlGeneration.Extensions;

namespace SqlGenerationTest
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestClass]
        public class And
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Clause_Containing_String_And()
            {
                var myClause = Column.Named("foo").IsEqualTo(12).And(Column.Named("bar").IsEqualTo(22));

                StringAssert.Contains(myClause.ToString(), "AND");
            }
        }

        [TestClass]
        public class Or
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Clause_Containing_String_Or()
            {
                var myClause = Column.Named("foo").IsEqualTo(12).Or(Column.Named("bar").IsEqualTo(22));

                StringAssert.Contains(myClause.ToString(), "OR");
            }
        }

        [TestClass]
        public class IsEqualTo
        {
            /// <summary>
            /// This is the most basic case
            /// </summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_Equals_Val_For_String_Parameter()
            {
                var myName = "col";
                var myValue = "fdas";
                Assert.AreEqual<string>(string.Format("{0} = '{1}'", myName, myValue), new Column(myName).IsEqualTo(myValue).ToString());
            }

            /// <summary>This is the case for an integer to prove that we can handle generic types</summary>
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_Equals_Val_For_Int_Parameter()
            {
                var myName = "col";
                var myValue = 12;
                Assert.AreEqual<string>(string.Format("{0} = '{1}'", myName, myValue), new Column(myName).IsEqualTo(myValue).ToString());
            }
        }

        [TestClass]
        public class IsGreaterThan
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_GreaterThan_Val_For_String_Parameter()
            {
                var columnName = "Id";
                var value = "blah";

                Assert.AreEqual<string>(string.Format("{0} > '{1}'", columnName, value), new Column(columnName).IsGreaterThan(value).ToString());
            }
        }

        [TestClass]
        public class IsLessThan
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_LessThan_Val_For_Double()
            {
                var columnName = "fdas";
                var value = 12.4;

                Assert.AreEqual<string>(string.Format("{0} < '{1}'", columnName, value), new Column(columnName).IsLessThan(value).ToString());
            }
        }

        [TestClass]
        public class IsGreaterThanOrEqualTo
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_GreaterThanEqual_For_Int_Parameter()
            {
                const string columnName = "asdf";
                const int value = 42;

                Assert.AreEqual<string>(string.Format("{0} >= '{1}'", columnName, value), new Column(columnName).IsGreaterThanOrEqualTo(value).ToString());
            }
        }

        [TestClass]
        public class IsLessThanOrEqualTo
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_LessThanEqual_For_DateTime_Parameter()
            {
                const string columnName = "asdf";
                var value = new DateTime(123456);

                Assert.AreEqual<string>(string.Format("{0} <= '{1}'", columnName, value), new Column(columnName).IsLessThanOrEqualTo(value).ToString());
            }
        }

        [TestClass]
        public class IsNotEqualTo
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_NotEqualTo_For_Decimal()
            {
                var columnName = "a;osiehf";
                decimal value = 12.3M;

                Assert.AreEqual<string>(string.Format("{0} <> '{1}'", columnName, value), new Column(columnName).IsNotEqualTo(value).ToString());
            }
        }

        [TestClass]
        public class Contains
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Col_Like_With_Wildcards()
            {
                var columnName = "asd;huf";
                var targetText = "as;jfa8;ouf";

                string whereClause = new Column(columnName).Contains(targetText).ToString();

                Assert.AreEqual<string>(string.Format("{0} LIKE '%{1}%'", columnName, targetText), whereClause);
            }
        }

        [TestClass]
        public class IsOneOf
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Column_In_Set_Of_Values()
            {
                var columnName = ";o8ahsdf";
                int value1 = 12;
                int value2 = 32;
                int value3 = 42;

                var whereClause = Column.Named(columnName).IsOneOf(value1, value2, value3);

                Assert.AreEqual<string>(string.Format("{0} IN ('{1}','{2}','{3}')", columnName, value1, value2, value3), whereClause.ToString());
            }
        }
    }
}
