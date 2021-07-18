namespace VendingMachine.QueryBuilder
{
    public class UnsafeLiteral
    {
        #region Constructors

        public UnsafeLiteral(string value, bool replaceQuotes = true)
        {
            if (value == null)
            {
                value = "";
            }

            if (replaceQuotes)
            {
                value = value.Replace("'", "''");
            }

            this.Value = value;
        }

        #endregion Constructors

        #region Properties

        public string Value { get; set; }

        #endregion Properties
    }
}