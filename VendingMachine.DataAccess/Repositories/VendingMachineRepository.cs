using System;
using System.Collections.Generic;
using VendingMachine.DataAccess.DataMapper;
using VendingMachine.DataAccess.SQLOperations;
using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.DataBase;

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
            this.sqlUnitOfWork = sqlUnitOfWork ?? new SqlUnitOfWork();
        }

        #endregion Constructors

        #region Methods

        public void AddModel(VendingMachineModel model, bool commit = false)
        {
            sqlUnitOfWork.InsertRecord(new VendingMachineDataMapper().MapFromDomain(model));
            sqlUnitOfWork.InsertRecord(new LocationDataMapper().MapFromDomain(model));
            foreach (CellModel cell in model.Cells)
            {
                sqlUnitOfWork.InsertRecord(new CellDataMapper().MapFromDomain(cell));
            }

            if (commit)
            {
                Commit();
            }
        }

        public void Commit()
        {
            sqlUnitOfWork.Execute();
        }

        public bool Contains(VendingMachineModel model)
        {
            sqlUnitOfWork.InsertRecord(new VendingMachineDataMapper().MapFromDomain(model));
            sqlUnitOfWork.InsertRecord(new LocationDataMapper().MapFromDomain(model));
            foreach (CellModel cell in model.Cells)
            {
                sqlUnitOfWork.InsertRecord(new CellDataMapper().MapFromDomain(cell));
            }

            throw new NotImplementedException();
        }

        public int DeleteModel(VendingMachineModel model, bool commit = false)
        {
            sqlUnitOfWork.DeleteRecord(DataBaseServices.LocationTableName, "VendingMachineId", model.Id);
            sqlUnitOfWork.DeleteRecord(DataBaseServices.CellTableName, "VendingMachineId", model.Id);
            sqlUnitOfWork.DeleteRecord(DataBaseServices.VendingMachineTableName, "Id", model.Id);

            if (commit)
            {
                Commit();
            }
            return 0;
        }

        public VendingMachineModel FindById(int id)
        {
            VendingMachineModel vm = new VendingMachineModel();
            VendingMachineTableRecord vmRecord = sqlUnitOfWork.FindById<VendingMachineTableRecord>(DataBaseServices.VendingMachineTableName, "Id", id);
            new VendingMachineDataMapper().MapFromTable(ref vm, vmRecord);

            LocationTableRecord locationRecord = sqlUnitOfWork.FindById<LocationTableRecord>(DataBaseServices.VendingMachineTableName, "VendingMachineId", vm.Id);
            new LocationDataMapper().MapFromTable(ref vm, locationRecord);

            IEnumerable<CellTableRecord> cells = sqlUnitOfWork.FindAll<CellTableRecord>(DataBaseServices.CellTableName, "VendingMachineId", vm.Id);
            foreach (CellTableRecord cell in cells)
            {
                CellModel cellModel = new CellModel();
                new CellDataMapper().MapFromTable(ref cellModel, cell);
                vm.Cells.Add(cellModel);
            }

            return vm;
        }

        public int RecordsCount()
        {
            return sqlUnitOfWork.RecordsCount(DataBaseServices.VendingMachineTableName);
        }

        public int UpdateModel(VendingMachineModel model, bool commit = false)
        {
            sqlUnitOfWork.UpdateRecord(new VendingMachineDataMapper().MapFromDomain(model), "Id", model.Id);
            sqlUnitOfWork.UpdateRecord(new LocationDataMapper().MapFromDomain(model), "VendingMachineId", model.Id);
            foreach (CellModel cell in model.Cells)
            {
                sqlUnitOfWork.UpdateRecord(new CellDataMapper().MapFromDomain(cell), "VendingMachineId", model.Id);
            }

            if (commit)
            {
                Commit();
            }
            return 0;
        }

        #endregion Methods
    }
}