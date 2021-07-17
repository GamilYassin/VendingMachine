using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class CellDataMapper : IModelMapper<CellModel, CellTableRecord>
    {
        public CellTableRecord MapFromDomain(CellModel domainModel)
        {
            return new CellTableRecord();
            //{ 
            //VendingMachineId = domainModel.,
            //CellId = domainModel.
            //};
        }

        public void MapFromTable(ref CellModel domainModel, CellTableRecord databaseModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
