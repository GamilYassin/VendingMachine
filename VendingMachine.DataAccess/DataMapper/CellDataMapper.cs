using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class CellDataMapper : IModelMapper<CellModel, CellTableRecord>
    {
        public CellTableRecord MapFromDomain(CellModel domainModel)
        {
            return new CellTableRecord()
            {
                VendingMachineId = domainModel.VendingMachineId,
                CellId = domainModel.CellId,
                ItemId = domainModel.SellItem.Id,
                ItemQty = domainModel.SellItemQty,
            };

        }

        public void MapFromTable(ref CellModel domainModel, CellTableRecord databaseModel)
        {
            if (domainModel == null)
            {
                domainModel = new CellModel();
            }
            domainModel.VendingMachineId = databaseModel.VendingMachineId;
            domainModel.CellId = databaseModel.CellId;
            domainModel.SellItem.Id = databaseModel.ItemId;
        }
    }
}
