using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VendingMachine.QueryBuilder
{
    public class SqlResult
    {
        #region Fields

        private static readonly Type[] NumberTypes =
        {
            typeof(int),
            typeof(long),
            typeof(decimal),
            typeof(double),
            typeof(float),
            typeof(short),
            typeof(ushort),
            typeof(ulong),
        };
        public Dictionary<string, object> NamedBindings = new Dictionary<string, object>();

        #endregion Fields

        #region Properties

        public List<object> Bindings { get; set; } = new List<object>();
        public Query Query { get; set; }
        public string RawSql { get; set; } = "";
        public string Sql { get; set; } = "";

        #endregion Properties

        #region Methods

        private string ChangeToSqlValue(object value)
        {
            if (value == null)
            {
                return "NULL";
            }

            if (Helper.IsArray(value))
            {
                return Helper.JoinArray(",", value as IEnumerable);
            }

            if (NumberTypes.Contains(value.GetType()))
            {
                return Convert.ToString(value, CultureInfo.InvariantCulture);
            }

            if (value is DateTime date)
            {
                if (date.Date == date)
                {
                    return "'" + date.ToString("yyyy-MM-dd") + "'";
                }

                return "'" + date.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            if (value is bool vBool)
            {
                return vBool ? "true" : "false";
            }

            if (value is Enum vEnum)
            {
                return Convert.ToInt32(vEnum) + $" /* {vEnum} */";
            }

            // fallback to string
            return "'" + value.ToString() + "'";
        }

        public override string ToString()
        {
            List<object> deepParameters = Helper.Flatten(Bindings).ToList();

            return Helper.ReplaceAll(RawSql, "?", i =>
            {
                if (i >= deepParameters.Count)
                {
                    throw new Exception(
                        $"Failed to retrieve a binding at index {i}, the total bindings count is {Bindings.Count}");
                }

                object value = deepParameters[i];
                return ChangeToSqlValue(value);
            });
        }

        #endregion Methods
    }
}