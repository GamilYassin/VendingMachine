using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Services.EnumerationBase;

namespace VendingMachine.DataAccess.SQLOperations
{
  public  class SqlOperationTypeEnum: Enumeration
    {

        public SqlOperationTypeEnum(int value, string displayName): base(value, displayName)
        {

        }

        public static SqlOperationTypeEnum Insert = new SqlOperationTypeEnum(1, "Insert");
        public static SqlOperationTypeEnum Update = new SqlOperationTypeEnum(2, "Update");
        public static SqlOperationTypeEnum Delete = new SqlOperationTypeEnum(3, "Delete");
    }
}
