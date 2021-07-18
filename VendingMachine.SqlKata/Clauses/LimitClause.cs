namespace VendingMachine.QueryBuilder
{
    public class LimitClause : ClauseBase
    {
        #region Fields

        private int _limit;

        #endregion Fields

        #region Properties

        public int Limit
        {
            get => _limit;
            set => _limit = value > 0 ? value : _limit;
        }

        #endregion Properties

        #region Methods

        public LimitClause Clear()
        {
            _limit = 0;
            return this;
        }

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new LimitClause
            {
                Engine = Engine,
                Limit = Limit,
                Component = Component,
            };
        }

        public bool HasLimit()
        {
            return _limit > 0;
        }

        #endregion Methods
    }
}