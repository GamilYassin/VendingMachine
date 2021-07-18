namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a boolean (true/false) condition.
    /// </summary>
    public class BooleanCondition : ConditionBase
    {
        #region Properties

        public string Column { get; set; }
        public bool Value { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new BooleanCondition
            {
                Engine = Engine,
                Column = Column,
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
                Value = Value,
            };
        }

        #endregion Methods
    }
}