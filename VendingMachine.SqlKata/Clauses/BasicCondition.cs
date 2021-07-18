namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a comparison between a column and a value.
    /// </summary>
    public class BasicCondition : ConditionBase
    {
        #region Properties

        public string Column { get; set; }
        public string Operator { get; set; }
        public virtual object Value { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new BasicCondition
            {
                Engine = Engine,
                Column = Column,
                Operator = Operator,
                Value = Value,
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}