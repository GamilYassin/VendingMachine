namespace VendingMachine.QueryBuilder
{
    public class OrderByRandom : OrderByBase
    {
        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new OrderByRandom
            {
                Engine = Engine,
            };
        }

        #endregion Methods
    }
}