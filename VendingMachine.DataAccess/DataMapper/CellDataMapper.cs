using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Entities;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class CellDataMapper : IModelMapper<Cell, CellTableRecord>
    {
        public CellTableRecord MapFromDomain(Cell domainModel)
        {
            return new CellTableRecord();
            //{ 
            //VendingMachineId = domainModel.,
            //CellId = domainModel.
            //};
        }

        public void MapFromTable(ref Cell domainModel, CellTableRecord databaseModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
