using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneration
{
    public abstract class BinaryBoolean : Component
    {
        private readonly Component[] _components;
        protected IEnumerable<Component> Components { get { return _components; } }

        public BinaryBoolean(params Component[] components)
        {
            _components = components;
        }

        protected string JoinClausesWith(string joinClause)
        {
            var componentStrings = new List<string>();
            foreach (var component in Components)
                componentStrings.Add(string.Format("({0})", component));

            return String.Join(joinClause, componentStrings.ToArray());
        }
    }
}
