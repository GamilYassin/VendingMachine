﻿using Dapper;
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
                    //SqlServerCompiler compiler = new SqlServerCompiler();
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
                                //connection.Execute(compiler.Compile(operation.SqlQuery).Sql);
                            }
                            else if (operation.OperationType == SqlOperationTypeEnum.Delete)
                            {
                                //connection.Execute(compiler.Compile(operation.SqlQuery).Sql);
                            }
                            //connection.Execute(compiler.Compile(operation.SqlQuery).Sql, operation.Param, commandType: System.Data.CommandType.Text);
                        }
                    }
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