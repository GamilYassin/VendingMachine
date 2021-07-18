namespace VendingMachine.QueryBuilder
{
    public class BasicDateCondition : BasicCondition
    {
        #region Properties

        public string Part { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new BasicDateCondition
            {
                Engine = Engine,
                Column = Column,
                Operator = Operator,
                Value = Value,
                IsOr = IsOr,
                IsNot = IsNot,
                Part = Part,
                Component = Component,
            };
        }

        #endregion Methods
    }
}