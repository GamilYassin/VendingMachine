namespace VendingMachine.QueryBuilder
{
    public abstract class ClauseBase
    {
        #region Properties

        /// <summary>
        ///  Gets or sets the component name.
        /// </summary>
        /// <value>
        ///  The component name.
        /// </value>
        public string Component { get; set; }
        /// <summary>
        ///  Gets or sets the SQL engine.
        /// </summary>
        /// <value>
        ///  The SQL engine.
        /// </value>
        public string Engine { get; set; } = null;

        #endregion Properties

        #region Methods

        public abstract ClauseBase Clone();

        #endregion Methods
    }
}