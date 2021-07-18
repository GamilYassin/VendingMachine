using Dapper;
using SqlKata;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.DataAccess.SQLOperations;
using VendingMachine.DataAccess.Tables;

namespace VendingMachine.DataAccess.SqlOperations
{
    public class SqlOperation
    {
        #region Constructors

        public SqlOperation(string tableName, IEnumerable<KeyValuePair<string, object>> values, SqlOperationTypeEnum type)
        {
            OperationType = type;
            TableName = tableName;
            Parameters = values;
            //SqlQuery = sql;
            //Parameters = new DynamicParameters(values);
            //Param = new DynamicParameters(vmRecord);
            //ColumnNames = values.Select(x => x.Key).ToArray<string>();
        }

        #endregion Constructors

        #region Properties

        //public IEnumerable<string> ColumnNames { get; set; }
        public SqlOperationTypeEnum OperationType { get; set; }
        public IEnumerable<KeyValuePair<string, object>> Parameters { get; set; }
        //public DynamicParameters Param { get; set; }
        //public DynamicParameters Parameters { get; set; }
        //public Query SqlQuery { get; set; }
        public string TableName { get; set; }

        #endregion Properties
    }
}