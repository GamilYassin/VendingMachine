using Dapper;
using Serilog;
using VendingMachine.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendingMachine.DataAccess.SqlOperations;
using VendingMachine.Services.DataBase;

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

        #endregion Methods
    }
}