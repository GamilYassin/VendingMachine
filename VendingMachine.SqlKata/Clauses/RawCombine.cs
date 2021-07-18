namespace VendingMachine.QueryBuilder
{
    public class RawCombine : CombineBase
    {
        #region Properties

        public object[] Bindings { get; set; }
        public string Expression { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new RawCombine
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