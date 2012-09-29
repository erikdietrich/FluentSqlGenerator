using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlGeneration.Extensions
{
    public static class ComparisonExtensions
    {
        public static Component IsEqualTo<T>(this Column column, T value)
        {
            return BuildWithOperator(column, value, "=");
        }

        public static Component IsGreaterThan<T>(this Column column, T value)
        {
            return BuildWithOperator(column, value, ">");
        }

        public static Component IsLessThan<T>(this Column column, T value)
        {
            return BuildWithOperator(column, value, "<");
        }

        public static Component IsGreaterThanOrEqualTo<T>(this Column column, T value)
        {
            return BuildWithOperator(column, value, ">=");
        }

        public static Component IsLessThanOrEqualTo<T>(this Column column, T value)
        {
            return BuildWithOperator(column, value, "<=");
        }

        public static Component IsNotEqualTo<T>(this Column column, T value)
        {
            return BuildWithOperator(column, value, "<>");
        }

        public static Component Contains<T>(this Column column, T value)
        {
            return BuildWithOperator(column, string.Format("%{0}%", value), "LIKE");
        }

        public static Component IsOneOf<T>(this Column column, params T[] parameters)
        {
            return new Clause(String.Format("{0} IN ('{1}')", column, String.Join("','", parameters.ToList())));
        }


        private static Component BuildWithOperator<T>(Column column, T value, string op)
        {
            return new Clause(string.Format("{0} {1} '{2}'", column, op, value));
        }
    }
}
