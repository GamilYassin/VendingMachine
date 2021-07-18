namespace VendingMachine.QueryBuilder
{
    public class BaseJoin : JoinBase
    {
        #region Properties

        public Join Join { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new BaseJoin
            {
                Engine = Engine,
                Join = Join.Clone(),
                Component = Component,
            };
        }

        #endregion Methods
    }
}