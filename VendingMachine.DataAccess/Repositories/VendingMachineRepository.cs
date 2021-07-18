using Dapper;
using Serilog;
using VendingMachine.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using VendingMachine.DataAccess.DataMapper;
using VendingMachine.DataAccess.SqlOperations;
using VendingMachine.DataAccess.SQLOperations;
using VendingMachine.DataAccess.Tables;
using VendingMachine.DataAccess.UnitOfWork;
using VendingMachine.Domain.Models;
using VendingMachine.Services.DataBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Repositories
{
    public class VendingMachineRepository
    {
        #region Fields

        private SqlUnitOfWork sqlUnitOfWork;

        #endregion Fields

        #region Constructors

        public VendingMachineRepository(SqlUnitOfWork sqlUnitOfWork = null)
        {
            if (sqlUnitOfWork == null)
            {
                this.sqlUnitOfWork = new SqlUnitOfWork();
            }
            else
            {
                this.sqlUnitOfWork = sqlUnitOfWork;
            }
        }

        #endregion Constructors

        #region Methods

        private void InsertCells(IList<CellModel> cells)
        {
            throw new NotImplementedException();
        }

        private void InsertLocation(LocationModel vMLocation)
        {
            throw new NotImplementedException();
        }

        private void InsertVendingMachine(VendingMachineModel model)
        {
            VendingMachineTableRecord vmRecord = new VendingMachineDataMapper().MapFromDomain(model);
            InsertVendingMachine(vmRecord);
        }

        private void InsertVendingMachine(VendingMachineTableRecord vmRecord)
        {
            IEnumerable<KeyValuePair<string, object>> values = DataBaseServices.GetKeyValuePairs(vmRecord);
            string tableName = DataBaseServices.GetTableName(vmRecord);
            //Query sqlInsertQ = new Query(tableName)
            //                       .AsInsert(values);
            //IEnumerable<object> columnsVals = values.Select(x => x.Value);
            //string connectionString = DataBaseServices.GetConnectionIdentifier();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (QueryFactory db = new QueryFactory(connection, new SqlServerCompiler()))
            //{
            //    connection.Execute(db.Compiler.Compile(sqlInsertQ).Sql, columnsVals);
            //}

            sqlUnitOfWork.RegisterOperation(new SqlOperation(tableName, values, SqlOperationTypeEnum.Insert));
        }

        public void AddModel(VendingMachineModel model, bool commit = false)
        {
            //int affected = 0;
            //New vending machine means new location and new cells records
            // Add vending machine
            //VendingMachineTableRecord vmRecord = new VendingMachineDataMapper().MapFromDomain(model);
            //affected += vmUnitofWork.AddModel(vmRecord);
            //// Add location
            //LocationTableRecord locationRecord = new LocationDataMapper().MapFromDomain(model);
            //affected += locationUnitofWork.AddModel(locationRecord);
            //// Add cells collection
            //foreach (CellModel cell in model.Cells)
            //{
            //    CellTableRecord cellRecord = new CellDataMapper().MapFromDomain(cell);
            //    affected += cellUnitofWork.AddModel(cellRecord);
            //}

            InsertVendingMachine(model);
            //InsertLocation(model.VMLocation);
            //InsertCells(model.Cells);

            if (commit)
            {
                Commit();
            }
        }

        public void AddModel(VendingMachineTableRecord model, bool commit = false)
        {
            InsertVendingMachine(model);
            if (commit)
            {
                Commit();
            }
        }

        public void Commit()
        {
            //vmUnitofWork.Commit();
            //locationUnitofWork.Commit();
            //cellUnitofWork.Commit();
            sqlUnitOfWork.Execute();
        }

        public bool Contains(VendingMachineModel model)
        {
            //VendingMachineTableRecord vmRecord = new VendingMachineDataMapper().MapFromDomain(model);
            //return vmUnitofWork.Contains(vmRecord);

            throw new NotImplementedException();
        }

        public int DeleteModel(VendingMachineModel model, bool commit = false)
        {
            //int affected = 0;
            //foreach (CellModel cell in model.Cells)
            //{
            //    CellTableRecord cellRecord = new CellDataMapper().MapFromDomain(cell);
            //    affected += cellUnitofWork.DeleteModel(cellRecord);
            //}

            //VendingMachineTableRecord vmRecord = new VendingMachineDataMapper().MapFromDomain(model);
            //affected += vmUnitofWork.AddModel(vmRecord);
            //// Add location
            //LocationTableRecord locationRecord = new LocationDataMapper().MapFromDomain(model);
            //affected += locationUnitofWork.AddModel(locationRecord);
            //// Add cells collection

            if (commit)
            {
                Commit();
            }
            return 0;
        }

        public int DeleteModelById(int id, bool commit = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendingMachineModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public VendingMachineModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int RecordsCount()
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(VendingMachineModel model, bool commit = false)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}