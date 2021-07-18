using System;
using System.Data;
using System.Linq;

namespace VendingMachine.QueryBuilder
{
    public class XQuery : Query
    {
        #region Fields

        public Action<SqlResult> Logger = result => { };

        #endregion Fields

        #region Constructors

        public XQuery(IDbConnection connection, Compiler compiler)
        {
            Connection = connection;
            Compiler = compiler;
        }

        #endregion Constructors

        #region Properties

        public Compiler Compiler { get; set; }
        public IDbConnection Connection { get; set; }
        public QueryFactory QueryFactory { get; set; }

        #endregion Properties

        #region Methods

        public override Query Clone()
        {
            XQuery query = new XQuery(Connection, Compiler)
            {
                Clauses = Clauses.Select(x => x.Clone()).ToList(),
                Logger = Logger,

                QueryAlias = QueryAlias,
                IsDistinct = IsDistinct,
                Method = Method,
                Includes = Includes,
                Variables = Variables
            };

            query.SetEngineScope(EngineScope);

            return query;
        }

        #endregion Methods
    }
}