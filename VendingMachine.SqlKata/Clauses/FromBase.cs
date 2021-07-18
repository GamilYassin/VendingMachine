namespace VendingMachine.QueryBuilder
{
    public abstract class FromBase : ClauseBase
    {
        #region Fields

        protected string _alias;

        #endregion Fields

        #region Properties

        /// <summary>
        ///  Try to extract the Alias for the current clause.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual string Alias { get => _alias; set => _alias = value; }

        #endregion Properties
    }
}