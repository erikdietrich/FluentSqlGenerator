using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlGeneration;

namespace SqlGenerationTest
{
    public class Are
    {
        public static Component AreAllOfTheseTrue(params Component[] components)
        {
            return new And(components);
        }
        public static Component AnyOfTheseTrue(params Component[] components)
        {
            return new Or(components);
        }
    }
}
