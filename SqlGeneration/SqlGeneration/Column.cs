using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlGeneration
{
    public struct Column
    {
        private readonly string _name;

        public Column(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        public static Column Named(string name)
        {
            return new Column(name);
        }
    }
}
