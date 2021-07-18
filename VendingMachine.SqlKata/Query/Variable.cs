namespace VendingMachine.QueryBuilder
{
    public class Variable
    {
        #region Constructors

        public Variable(string name)
        {
            this.Name = name;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; set; }

        #endregion Properties
    }
}