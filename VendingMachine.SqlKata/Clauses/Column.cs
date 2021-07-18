namespace VendingMachine.QueryBuilder
{
    /// <summary>
    ///  Represents "column" or "column as alias" clause.
    /// </summary>
    /// <seealso cref="ColumnBase" />
    public class Column : ColumnBase
    {
        #region Properties

        /// <summary>
        ///  Gets or sets the column name. Can be "columnName" or "columnName as columnAlias".
        /// </summary>
        /// <value>
        ///  The column name.
        /// </value>
        public string Name { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc />
        public override ClauseBase Clone()
        {
            return new Column
            {
                Engine = Engine,
                Name = Name,
                Component = Component,
            };
        }

        #endregion Methods
    }
}