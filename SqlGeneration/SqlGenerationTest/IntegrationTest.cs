using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlGeneration;
using SqlGeneration.Extensions;

namespace SqlGeneration
{
    
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void A_Not_Clause()
        {
            var columnEquals12 = new Column("column").IsEqualTo(12);
            var myClause = new Not(columnEquals12);

            Assert.AreEqual<string>("NOT (column = '12')", myClause.ToString());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Basic_And_Stuff()
        {
            var myWhere = new And(new Column("MerchantId").IsEqualTo(12), new Column("Status").IsEqualTo("Good"));

            Assert.AreEqual<string>("(MerchantId = '12') AND (Status = 'Good')", myWhere.ToString());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Factory_Method_For_Column()
        {
            var whereClause = new And(Column.Named("MerchantId").IsEqualTo(12), Column.Named("Status").IsEqualTo("Good"));

            Assert.AreEqual<string>("(MerchantId = '12') AND (Status = 'Good')", whereClause.ToString());            
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Fluent_And_With_Extension()
        {
            var whereClause = Column.Named("MerchantId").IsEqualTo(12).And(Column.Named("Status").IsEqualTo("Good"));
            
            Assert.AreEqual<string>("(MerchantId = '12') AND (Status = 'Good')", whereClause.ToString());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Fluent_With_And()
        {
            var whereClause = Are.AreAllOfTheseTrue(Column.Named("Foo").IsOneOf(1, 2, 3), Column.Named("Bar").IsEqualTo(6));

            Assert.AreEqual<string>("(Foo IN ('1','2','3')) AND (Bar = '6')", whereClause.ToString());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Static_Class_With_Nested_And_Or()
        {
            var whereClause = Are.AreAllOfTheseTrue(Column.Named("Foo").IsEqualTo(0), Are.AnyOfTheseTrue(Column.Named("Bar").IsEqualTo(1), Column.Named("Baz").IsEqualTo(2)));

            Assert.AreEqual<string>("(Foo = '0') AND ((Bar = '1') OR (Baz = '2'))", whereClause.ToString());
        }
    }    
}
