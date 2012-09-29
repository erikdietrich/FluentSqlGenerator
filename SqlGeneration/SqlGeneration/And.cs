using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlGeneration
{
    public class And : BinaryBoolean
    {
        public And(params Component[] components) : base(components)
        {}

        public override string ToString()
        {
            return JoinClausesWith(" AND ");
        }
    }
}
