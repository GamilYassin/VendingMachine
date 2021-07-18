namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a "is in subquery" condition.
    /// </summary>
    public class InQueryCondition : ConditionBase
    {
        #region Properties

        public string Column { get; set; }
        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new InQueryCondition
            {
                Engine = Engine,
                Column = Column,
                Query = Query.Clone(),
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}