using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlGeneration
{
    public class Not : Component
    {
        private readonly Component _component;

        public Not(Component component)
        {
            _component = component;
        }

        public override string ToString()
        {
            return String.Format("NOT ({0})", _component);
        }
    }
}
