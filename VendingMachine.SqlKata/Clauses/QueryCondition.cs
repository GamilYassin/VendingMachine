namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a comparison between a column and a full "subquery".
    /// </summary>
    public class QueryCondition<T> : ConditionBase where T : QueryBase<T>
    {
        #region Properties

        public string Column { get; set; }
        public string Operator { get; set; }
        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new QueryCondition<T>
            {
                Engine = Engine,
                Column = Column,
                Operator = Operator,
                Query = Query.Clone(),
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}