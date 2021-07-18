using System;

namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a "from" clause.
    /// </summary>
    public class FromClause : FromBase
    {
        #region Properties

        public override string Alias
        {
            get
            {
                if (Table.IndexOf(" as ", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var segments = Table.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    return segments[2];
                }

                return Table;
            }
        }
        public string Table { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new FromClause
            {
                Engine = Engine,
                Alias = Alias,
                Table = Table,
                Component = Component,
            };
        }

        #endregion Methods
    }
}