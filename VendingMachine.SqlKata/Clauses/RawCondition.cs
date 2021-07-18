namespace VendingMachine.QueryBuilder
{
    public class RawCondition : ConditionBase
    {
        #region Properties

        public object[] Bindings { set; get; }
        public string Expression { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new RawCondition
            {
                Engine = Engine,
                Expression = Expression,
                Bindings = Bindings,
                IsOr = IsOr,
                IsNot = IsNot,
                Component = Component,
            };
        }

        #endregion Methods
    }
}