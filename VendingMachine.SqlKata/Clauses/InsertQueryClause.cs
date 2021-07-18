using System.Collections.Generic;

namespace VendingMachine.QueryBuilder
{
    public class InsertQueryClause : InsertClauseBase
    {
        #region Properties

        public List<string> Columns { get; set; }
        public Query Query { get; set; }

        #endregion Properties

        #region Methods

        public override ClauseBase Clone()
        {
            return new InsertQueryClause
            {
                Engine = Engine,
                Component = Component,
                Columns = Columns,
                Query = Query.Clone(),
            };
        }

        #endregion Methods
    }
}