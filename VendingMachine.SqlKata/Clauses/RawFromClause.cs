namespace VendingMachine.QueryBuilder
{
    public class RawFromClause : FromBase
    {
        #region Properties

        public object[] Bindings { set; get; }
        public string Expression { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new RawFromClause
            {
                Engine = Engine,
                Alias = Alias,
                Expression = Expression,
                Bindings = Bindings,
                Component = Component,
            };
        }

        #endregion Methods
    }
}