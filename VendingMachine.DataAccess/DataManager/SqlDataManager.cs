using Serilog;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public override int Insert(IEnumerable<T> models)
        {
            try
            {
                if (models == null)
                {
                    Log.Warning("Passed Enumerable models is null");
                    return 0;
                }
                int affected = 0;
                string tableName = DataBaseServices.GetTableName(new T());

                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    foreach (T model in models)
                    {
                        IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(model);
                        affected += db.Query(tableName)
                                      .Insert(values);
                    }
                }
                return affected;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Insert error");
                return 0;
            }
        }

        public override List<T> FindAll()
        {
            try
            {
                string tableName = DataBaseServices.GetTableName(new T());
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    return db.Query(tableName)
                             .Get<T>()
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Find All error");
                return null;
            }
        }


        public override T FindById(int id)
        {
            try
            {
                string tableName = DataBaseServices.GetTableName(new T());
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    return db.Query(tableName).Where("Id", id).First<T>();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager FindById error", id);
                return default;
            }
        }



        public override int Update(T model)
        {
            try
            {
                string tableName = DataBaseServices.GetTableName(model);
                IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(model, false);
                if (values is null)
                {
                    Log.Error("Model Values ValuePair List can not be null");
                    throw new Exception("Model Values ValuePair List can not be null");
                }
                int id = model.Id;
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    return db.Query(tableName)
                             .Where("Id", id)
                             .Update(values);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Update error", model);
                return 0;
            }
        }

        public override int Update(IEnumerable<T> models)
        {
            try
            {
                int affected = 0;
                string tableName = DataBaseServices.GetTableName(new T());
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    foreach (T model in models)
                    {
                        int id = model.Id;
                        IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(model, false);
                        affected += db.Query(tableName)
                                 .Where("Id", id)
                                 .Update(values);
                    }
                    return affected;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Update error");
                return 0;
            }
        }



        public override int Delete(T model)
        {
            try
            {
                string tableName = DataBaseServices.GetTableName(model);
                int id = model.Id;
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    return db.Query(tableName)
                             .Where("Id", id)
                             .Delete();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Delete error", model);
                return 0;
            }
        }

        public override int Delete(IEnumerable<T> models)
        {
            try
            {
                int affected = 0;
                string tableName = DataBaseServices.GetTableName(new T());
                using (SqlConnection connection = new SqlConnection(ConnectionIdentifier))
                using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                {
                    foreach (T model in models)
                    {
                        int id = model.Id;
                        affected += db.Query(tableName)
                                 .Where("Id", id)
                                 .Delete();
                    }
                    return affected;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SQL Data Manager Delete error");
                return 0;
            }
        }
    }
}
