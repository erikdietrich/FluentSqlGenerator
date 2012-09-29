using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneration
{
    public class Or : BinaryBoolean
    {

        public Or(params Component[] components) : base(components)
        {}

        public override string ToString()
        {
            return JoinClausesWith(" OR ");
        }
    }
}
