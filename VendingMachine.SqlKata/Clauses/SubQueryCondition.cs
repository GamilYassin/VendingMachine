namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a comparison between a full "subquery" and a value.
    /// </summary>
    public class SubQueryCondition<T> : ConditionBase where T : QueryBase<T>
    {
        #region Properties

        public string Operator { get; set; }
        public Query Query { get; set; }
        public object Value { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new SubQueryCondition<T>
            {
                Engine = Engine,
                Value = Value,
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