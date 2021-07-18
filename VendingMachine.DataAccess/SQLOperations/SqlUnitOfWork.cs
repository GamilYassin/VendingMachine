using Dapper;
using Serilog;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VendingMachine.DataAccess.SqlOperations;
using VendingMachine.Services.DataBase;

namespace VendingMachine.DataAccess.SQLOperations
{
    public class SqlUnitOfWork
    {
        private List<SqlOperation> sqlOperations;
        private string connectionString;

        public SqlUnitOfWork()
        {
            sqlOperations = new List<SqlOperation>();
            connectionString = DataBaseServices.GetConnectionIdentifier();
        }

        public void RegisterOperation(SqlOperation operation)
        {
            sqlOperations.Add(operation);
        }

        public void Execute()
        {
            try
            {
                if (sqlOperations.Count > 0)
                {
                    SqlServerCompiler compiler = new SqlServerCompiler();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    //using (QueryFactory db = new QueryFactory(connection, compiler))
                    {
                        foreach (SqlOperation operation in sqlOperations)
                        {
                            //if (operation.OperationType == SqlOperationTypeEnum.Insert)
                            //{
                            //    //db.Query(operation.TableName)
                            //    //  .Insert(operation.ColumnNames, operation.SqlQuery);
                            //}
                            //else if (operation.OperationType == SqlOperationTypeEnum.Update)
                            //{
                            //    connection.Execute(compiler.Compile(operation.SqlQuery).Sql);
                            //}
                            //else if (operation.OperationType == SqlOperationTypeEnum.Delete)
                            //{
                            //    connection.Execute(compiler.Compile(operation.SqlQuery).Sql);
                            //}
                            connection.Execute(compiler.Compile(operation.SqlQuery).Sql);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Executing an SQL Operation");
            }
        }
    }
}
