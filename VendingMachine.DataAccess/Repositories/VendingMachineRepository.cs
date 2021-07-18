using System;
using System.Collections.Generic;
using VendingMachine.DataAccess.DataMapper;
using VendingMachine.DataAccess.SQLOperations;
using VendingMachine.Domain.Models;

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