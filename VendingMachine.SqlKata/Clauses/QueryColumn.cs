namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents column clause calculated using query.
    /// </summary>
    /// <seealso cref="ColumnBase" />
    public class QueryColumn : ColumnBase
    {
        #region Properties

        /// <summary>
        ///  Gets or sets the query that will be used for column value calculation.
        /// </summary>
        /// <value>
        ///  The query for column value calculation.
        /// </value>
        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new QueryColumn
            {
                Engine = Engine,
                Query = Query.Clone(),
                Component = Component,
            };
        }

        #endregion Methods
    }
}