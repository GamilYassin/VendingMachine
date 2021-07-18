namespace VendingMachine.QueryBuilder
{
    public class OrderBy : OrderByBase
    {
        #region Properties

        public bool Ascending { get; set; } = true;
        public string Column { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new OrderBy
            {
                Engine = Engine,
                Component = Component,
                Column = Column,
                Ascending = Ascending
            };
        }

        #endregion Methods
    }
}