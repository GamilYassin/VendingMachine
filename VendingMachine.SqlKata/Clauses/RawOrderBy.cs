namespace VendingMachine.QueryBuilder
{
    public class RawOrderBy : OrderByBase
    {
        #region Properties

        public object[] Bindings { set; get; }
        public string Expression { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new RawOrderBy
            {
                Engine = Engine,
                Component = Component,
                Expression = Expression,
                Bindings = Bindings,
            };
        }

        #endregion Methods
    }
}