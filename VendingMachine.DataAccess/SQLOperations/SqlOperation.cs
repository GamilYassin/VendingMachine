using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataAccess.SQLOperations;

namespace VendingMachine.DataAccess.SqlOperations
{
  public  class SqlOperation
    {
        public string TableName { get; set; }
        public Query SqlQuery { get; set; }
        //public IEnumerable<string>  ColumnNames { get; set; }
        //public SqlOperationTypeEnum OperationType { get; set; }

        public SqlOperation(string tableName, Query sql)
        {
            //OperationType = sqlOperationType;
            TableName = tableName;
            SqlQuery = sql;
            //ColumnNames= columns;
        }
    }
}
