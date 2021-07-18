namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a "is between" condition.
    /// </summary>
    public class BetweenCondition<T> : ConditionBase
    {
        #region Properties

        public string Column { get; set; }
        public T Higher { get; set; }
        public T Lower { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new BetweenCondition<T>
            {
                Engine = Engine,
                Column = Column,
                Higher = Higher,
                Lower = Lower,
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}