namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents a comparison between two columns.
    /// </summary>
    public class TwoColumnsCondition : ConditionBase
    {
        #region Properties

        public string First { get; set; }
        public string Operator { get; set; }
        public string Second { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new TwoColumnsCondition
            {
                Engine = Engine,
                First = First,
                Operator = Operator,
                Second = Second,
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}