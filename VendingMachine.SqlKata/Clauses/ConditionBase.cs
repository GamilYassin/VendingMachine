namespace VendingMachine.QueryBuilder
{
    public abstract class ConditionBase : ClauseBase
    {
        #region Properties

        public bool IsNot { get; set; } = false;
        public bool IsOr { get; set; } = false;

        #endregion Properties
    }
}