using Dapper;
using VendingMachine.QueryBuilder;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.DataAccess.SQLOperations;
using VendingMachine.DataAccess.Tables;

namespace VendingMachine.DataAccess.SqlOperations
{
    public class SqlOperation
    {
        #region Constructors

        public SqlOperation(string tableName, IEnumerable<KeyValuePair<string, object>> values, SqlOperationTypeEnum type, string keyColName = null, object keyColValue = null)
        {
            OperationType = type;
            TableName = tableName;
            Parameters = values;
            if (string.IsNullOrEmpty(keyColName))
            {
                KeyColumnName = "Id";
            }
            else
            {
                KeyColumnName = keyColName;
            }

            if (keyColValue == null)
            {
                KeyColumnValue = values.Where(x => x.Key == "Id").Select(x => x.Value);
            }
            else
            {
                KeyColumnValue = keyColValue;
            }
        }

        #endregion Constructors

        #region Properties

        public string KeyColumnName { get; set; }
        public object KeyColumnValue { get; set; }
        public SqlOperationTypeEnum OperationType { get; set; }
        public IEnumerable<KeyValuePair<string, object>> Parameters { get; set; }
        public string TableName { get; set; }

        #endregion Properties
    }
}