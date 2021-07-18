namespace VendingMachine.QueryBuilder
{
    public class Combine : CombineBase
    {
        #region Properties

        /// <summary>
        ///  Gets or sets a value indicating whether this <see cref="Combine" /> clause will combine all.
        /// </summary>
        /// <value>
        ///  <c> true </c> if all; otherwise, <c> false </c>.
        /// </value>
        public bool All { get; set; } = false;
        /// <summary>
        ///  Gets or sets the combine operation, e.g. "UNION", etc.
        /// </summary>
        /// <value>
        ///  The combine operation.
        /// </value>
        public string Operation { get; set; }
        /// <summary>
        ///  Gets or sets the query to be combined with.
        /// </summary>
        /// <value>
        ///  The query that will be combined.
        /// </value>
        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new Combine
            {
                Engine = Engine,
                Operation = Operation,
                Component = Component,
                Query = Query,
                All = All,
            };
        }

        #endregion Methods
    }
}