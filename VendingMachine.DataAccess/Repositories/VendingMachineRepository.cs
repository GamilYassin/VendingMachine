using System;
using System.Collections.Generic;
using VendingMachine.Services.Interfaces;
using VendingMachine.Domain;
using VendingMachine.DataAccess.UnitOfWork;
using VendingMachine.DataAccess.Tables;

namespace VendingMachine.DataAccess.Repositories
{
    public class VendingMachineRepository : IRepository<Domain.Entities.VendingMachine>
    {
        private SqlUnitofWorkBase<VendingMachineTableRecord> vmUnitofWork;
        private SqlUnitofWorkBase<LocationTableRecord> locationUnitofWork;
        private SqlUnitofWorkBase<InsideBalanceTableRecord> balanceUnitofWork;
        private SqlUnitofWorkBase<CellTableRecord> cellUnitofWork;

        public VendingMachineRepository()
        {
            vmUnitofWork = new SqlUnitofWorkBase<VendingMachineTableRecord>();
            locationUnitofWork = new SqlUnitofWorkBase<LocationTableRecord>();
            balanceUnitofWork = new SqlUnitofWorkBase<InsideBalanceTableRecord>();
            cellUnitofWork=new SqlUnitofWorkBase<CellTableRecord>();
        }


        public int AddModel(Domain.Entities.VendingMachine model, bool commit = false)
        {
            vmUnitofWork.AddModel(model, commit);

        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Domain.Entities.VendingMachine model)
        {
            throw new NotImplementedException();
        }

        public int DeleteModel(Domain.Entities.VendingMachine model, bool commit = false)
        {
            throw new NotImplementedException();
        }

        public int DeleteModelById(int id, bool commit = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entities.VendingMachine> FindAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.VendingMachine FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int RecordsCount()
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(Domain.Entities.VendingMachine model, bool commit = false)
        {
            throw new NotImplementedException();
        }
    }
}
