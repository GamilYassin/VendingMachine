namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a "nested" clause condition. i.e OR (myColumn = "A")
    /// </summary>
    public class NestedCondition<T> : ConditionBase where T : QueryBase<T>
    {
        #region Properties

        public T Query { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new NestedCondition<T>
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