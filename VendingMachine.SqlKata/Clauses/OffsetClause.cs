namespace VendingMachine.QueryBuilder
{
    public class OffsetClause : ClauseBase
    {
        #region Fields

        private int _offset;

        #endregion Fields

        #region Properties

        public int Offset
        {
            get => _offset;
            set => _offset = value > 0 ? value : _offset;
        }

        #endregion Properties

        #region Methods

        public OffsetClause Clear()
        {
            _offset = 0;
            return this;
        }

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new OffsetClause
            {
                Engine = Engine,
                Offset = Offset,
                Component = Component,
            };
        }

        public bool HasOffset()
        {
            return _offset > 0;
        }

        #endregion Methods
    }
}