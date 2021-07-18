namespace VendingMachine.QueryBuilder
{
    public class IncrementClause : InsertClause
    {
        #region Properties

        public string Column { get; set; }
        public int Value { get; set; } = 1;

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new IncrementClause
            {
                Engine = Engine,
                Component = Component,
                Column = Column,
                Value = Value
            };
        }

        #endregion Methods
    }
}