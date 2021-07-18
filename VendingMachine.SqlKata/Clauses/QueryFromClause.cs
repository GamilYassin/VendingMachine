namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a "from subquery" clause.
    /// </summary>
    public class QueryFromClause : FromBase
    {
        #region Properties

        public override string Alias
        {
            get
            {
                return string.IsNullOrEmpty(_alias) ? Query.QueryAlias : _alias;
            }
        }
        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new QueryFromClause
            {
                Engine = Engine,
                Alias = Alias,
                Query = Query.Clone(),
                Component = Component,
            };
        }

        #endregion Methods
    }
}