using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlGeneration
{
    public class Clause : Component
    {
        private readonly string _clauseValue;

        public Clause(string clauseValue)
        {
            _clauseValue = clauseValue;
        }

        public override string ToString()
        {
            return _clauseValue;
        }
    }
}
