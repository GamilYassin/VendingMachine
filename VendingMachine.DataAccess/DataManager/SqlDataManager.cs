using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendingMachine.Services.DataBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataManager
{
    public class SqlDataManager<T> : DataManagerBase<T> where T : ITable, new()
    {
        public SqlDataManager() : base()
        {

        }

        public override int Insert(T model)
        {
            try
            {
                string tableName = DataBaseServices.GetTableName(model);
                IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(model);
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    return db.Query(tableName)
                             .Insert(values);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Insert error", model);
                return 0;
            }
        }

        public override T FindById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public override List<T> FindAll(string tableName)
        {
            throw new System.NotImplementedException();
        }

        public override int Update(T model)
        {
            throw new System.NotImplementedException();
        }

        public override int Delete(T model)
        {
            throw new System.NotImplementedException();
        }
    }
}
