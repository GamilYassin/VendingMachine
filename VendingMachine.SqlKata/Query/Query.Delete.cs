namespace VendingMachine.QueryBuilder
{
    public partial class Query
    {
        #region Methods

        public Query AsDelete()
        {
            Method = "delete";
            return this;
        }

        #endregion Methods
    }
}