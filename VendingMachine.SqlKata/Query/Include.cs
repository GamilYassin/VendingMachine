namespace VendingMachine.QueryBuilder
{
    public class Include
    {
        #region Properties

        public string ForeignKey { get; set; }
        public bool IsMany { get; set; }
        public string LocalKey { get; set; }
        public string Name { get; set; }
        public Query Query { get; set; }

        #endregion Properties
    }
}