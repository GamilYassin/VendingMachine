using System.Collections.Generic;

namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents aggregate clause like "COUNT", "MAX" or etc.
    /// </summary>
    /// <seealso cref="ClauseBase" />
    public class AggregateClause : ClauseBase
    {
        #region Properties

        /// <summary>
        ///  Gets or sets columns that used in aggregate clause.
        /// </summary>
        /// <value>
        ///  The columns to be aggregated.
        /// </value>
        public List<string> Columns { get; set; }

        /// <summary>
        ///  Gets or sets the type of aggregate function.
        /// </summary>
        /// <value>
        ///  The type of aggregate function, e.g. "MAX", "MIN", etc.
        /// </value>
        public string Type { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new AggregateClause
            {
                Engine = Engine,
                Type = Type,
                Columns = new List<string>(Columns),
                Component = Component,
            };
        }

        #endregion Methods
    }
}