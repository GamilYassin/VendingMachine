using System;
using System.Collections.Generic;
using VendingMachine.DataAccess.Tables;
using VendingMachine.DataAccess.UnitOfWork;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Repositories
{
    public class VendingMachineRepository : IRepository<VendingMachineModel>
    {
        private SqlUnitofWorkBase<VendingMachineTableRecord> vmUnitofWork;
        private SqlUnitofWorkBase<LocationTableRecord> locationUnitofWork;
        private SqlUnitofWorkBase<CellTableRecord> cellUnitofWork;

        public VendingMachineRepository()
        {
            vmUnitofWork = new SqlUnitofWorkBase<VendingMachineTableRecord>();
            locationUnitofWork = new SqlUnitofWorkBase<LocationTableRecord>();
            cellUnitofWork = new SqlUnitofWorkBase<CellTableRecord>();
        }


        public int AddModel(VendingMachineModel model, bool commit = false)
        {
            //vmUnitofWork.AddModel(model, commit);
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public bool Contains(VendingMachineModel model)
        {
            throw new NotImplementedException();
        }

        public int DeleteModel(VendingMachineModel model, bool commit = false)
        {
            throw new NotImplementedException();
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
    }
}
