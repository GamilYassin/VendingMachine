namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents an "is null" condition.
    /// </summary>
    public class NullCondition : ConditionBase
    {
        #region Properties

        public string Column { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new NullCondition
            {
                Engine = Engine,
                Column = Column,
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}