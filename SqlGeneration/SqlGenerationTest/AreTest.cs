using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;
using SqlGeneration.Extensions;

namespace SqlGenerationTest
{
    [TestClass]
    public class AreTest
    {
        [TestClass]
        public class AllOfTheseTrue
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_And_Object()
            {
                var clause = Are.AreAllOfTheseTrue(Column.Named("Foo").IsEqualTo(12), Column.Named("Bar").IsGreaterThan("asdf"));

                Assert.IsInstanceOfType(clause, typeof(And));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Clause_Containing_The_Word_And_Once_For_Two_Clauses()
            {
                var clause = Are.AreAllOfTheseTrue(Column.Named("Foo").IsEqualTo(12), Column.Named("Bar").IsGreaterThan("asdf"));

                StringAssert.Contains(clause.ToString(), "AND");
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Clause_With_Two_Ands_For_Three_Clauses()
            {
                var clause = Are.AreAllOfTheseTrue(Column.Named("Foo").IsEqualTo(12), Column.Named("Bar").IsGreaterThan("asdf"), Column.Named("Baz").IsLessThan(4.2));

                Assert.AreEqual<int>(3, Regex.Split(clause.ToString(), "AND").Count());
            }
        }

        [TestClass]
        public class AnyOfTheseTrue
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Or_Object()
            {
                var clause = Are.AnyOfTheseTrue(Column.Named("Foo").IsEqualTo(12), Column.Named("Bar").IsGreaterThan("asdf"));

                Assert.IsInstanceOfType(clause, typeof(Or));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Clause_With_Word_Or_In_It()
            {
                var clause = Are.AnyOfTheseTrue(Column.Named("Foo").IsEqualTo(12), Column.Named("Bar").IsGreaterThan("asdf"));

                StringAssert.Contains(clause.ToString(), "OR");
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Object_With_Two_Ors_For_Three_Parameters()
            {
                var clause = Are.AnyOfTheseTrue(Column.Named("Foo").IsEqualTo(12), Column.Named("Bar").IsGreaterThan("asdf"), Column.Named("Baz").IsLessThan(4.2));

                Assert.AreEqual<int>(3, Regex.Split(clause.ToString(), "OR").Count());
            }
        }
    }
}
