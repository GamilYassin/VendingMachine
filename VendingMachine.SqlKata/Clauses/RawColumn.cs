namespace VendingMachine.QueryBuilder
{
    public class RawColumn : ColumnBase
    {
        #region Properties

        public object[] Bindings { set; get; }
        /// <summary>
        ///  Gets or sets the RAW expression.
        /// </summary>
        /// <value>
        ///  The RAW expression.
        /// </value>
        public string Expression { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new RawColumn
            {
                Engine = Engine,
                Expression = Expression,
                Bindings = Bindings,
                Component = Component,
            };
        }

        #endregion Methods
    }
}