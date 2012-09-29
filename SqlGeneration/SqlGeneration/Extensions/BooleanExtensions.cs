using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneration.Extensions
{
    public static class BooleanExtensions
    {
        public static And And(this Component thisClause, Component andTarget)
        {
            return new And(thisClause, andTarget);
        }

        public static Or Or(this Component thisClause, Component orTarget)
        {
            return new Or(thisClause, orTarget);
        }
    }
}
