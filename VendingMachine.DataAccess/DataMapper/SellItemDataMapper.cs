using System;
using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.EnumerationBase;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.DataAccess.DataMapper
{
    public class SellItemDataMapper : IModelMapper<SellItemModel, SellItemTableRecord>
    {
        public SellItemTableRecord MapFromDomain(SellItemModel domainModel)
        {
            return new SellItemTableRecord()
            {
                Id = domainModel.Id,
                Barcode = domainModel.Barcode,
                ItemType = domainModel.ItemType.DisplayName,
                Name = domainModel.Name,
                Price = domainModel.Price.ToString(),
            };
        }

        public void MapFromTable(ref SellItemModel domainModel, SellItemTableRecord databaseModel)
        {
            if (domainModel == null)
            {
                domainModel = new SellItemModel();
            }
            domainModel.Id = databaseModel.Id;
            domainModel.Barcode = databaseModel.Barcode;
            domainModel.ItemType = Enumeration.FromDisplayName<SellItemTypeEnum>(databaseModel.ItemType);
            domainModel.Name = databaseModel.Name;
            domainModel.Price = Money.MoneyFactory(databaseModel.Price);
        }
    }
}
