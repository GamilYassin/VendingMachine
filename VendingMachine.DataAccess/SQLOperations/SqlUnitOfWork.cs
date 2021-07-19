using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendingMachine.DataAccess.SqlOperations;
using VendingMachine.QueryBuilder;
using VendingMachine.Services.DataBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.SQLOperations
{
    public class SqlUnitOfWork
    {
        #region Fields

        private string connectionString;
        private List<SqlOperation> sqlOperations;

        #endregion Fields

        #region Constructors

        public SqlUnitOfWork()
        {
            sqlOperations = new List<SqlOperation>();
            connectionString = DataBaseServices.GetConnectionIdentifier();
        }

        #endregion Constructors

        #region Methods

        public void Execute()
        {
            try
            {
                if (sqlOperations.Count > 0)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
                    {
                        foreach (SqlOperation operation in sqlOperations)
                        {
                            if (operation.OperationType == SqlOperationTypeEnum.Insert)
                            {
                                db.Query(operation.TableName).Insert(operation.Parameters);
                            }
                            else if (operation.OperationType == SqlOperationTypeEnum.Update)
                            {
                                db.Query(operation.TableName)
                                  .Where(operation.KeyColumnName, operation.KeyColumnValue)
                                  .Update(operation.Parameters);
                            }
                            else if (operation.OperationType == SqlOperationTypeEnum.Delete)
                            {
                                db.Query(operation.TableName)
                                  .Where(operation.KeyColumnName, operation.KeyColumnValue)
                                  .Delete();
                            }
                        }
                    }
                    sqlOperations.Clear();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Executing an SQL Operation");
            }
        }

        public void RegisterOperation(SqlOperation operation)
        {
            sqlOperations.Add(operation);
        }

        public void InsertRecord(ITable vmRecord)
        {
            IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(vmRecord);
            string tableName = DataBaseServices.GetTableName(vmRecord);
            RegisterOperation(new SqlOperation(tableName, values, SqlOperationTypeEnum.Insert));
        }

        public void DeleteRecord(string tableName, string keyColumnName, object keyColValue)
        {
            RegisterOperation(new SqlOperation(tableName, null, SqlOperationTypeEnum.Delete, keyColumnName, keyColValue));
        }

        public void UpdateRecord(ITable vmRecord, string keyColumnName, object keyColValue)
        {
            IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(vmRecord);
            string tableName = DataBaseServices.GetTableName(vmRecord);
            RegisterOperation(new SqlOperation(tableName, values, SqlOperationTypeEnum.Update, keyColumnName, keyColValue));
        }

        public int RecordsCount(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
            {
                return db.Query(tableName)
                         .Count<int>();
            }
        }

        public T FindById<T>(string tableName, string keyColName, object keyColValue) where T : ITable
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
            {
                return db.Query(tableName)
                         .Where(keyColName, keyColValue)
                         .FirstOrDefault<T>();
            }
        }

        public IEnumerable<T> FindAll<T>(string tableName, string keyColName, object keyColValue) where T: ITable
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
            {
                return db.Query(tableName)
                         .Where(keyColName, keyColValue)
                         .Get<T>();
            }
        }

        public IEnumerable<T> FindAll<T>(string tableName) where T : ITable
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
            {
                return db.Query(tableName)
                         .Get<T>();
            }
        }

        #endregion Methods
    }
}