using System.Collections.Generic;

namespace VendingMachine.QueryBuilder
{
    public class InsertClause : InsertClauseBase
    {
        #region Properties

        public List<string> Columns { get; set; }
        public bool ReturnId { get; set; } = false;
        public List<object> Values { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new InsertClause
            {
                Engine = Engine,
                Component = Component,
                Columns = Columns,
                Values = Values,
                ReturnId = ReturnId,
            };
        }

        #endregion Methods
    }
}