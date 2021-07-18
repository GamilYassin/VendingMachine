namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents an "exists sub query" clause condition.
    /// </summary>
    public class ExistsCondition : ConditionBase
    {
        #region Properties

        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new ExistsCondition
            {
                Engine = Engine,
                Query = Query.Clone(),
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}