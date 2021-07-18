using System;
using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class CartItemDataMapper : IModelMapper<CartItemModel, CarItemTableRecord>
    {
        public CarItemTableRecord MapFromDomain(CartItemModel domainModel)
        {
            return new CarItemTableRecord()
            {
                SessionId = domainModel.SessionId,
                SellItemId = domainModel.SellItem.Id,
                SellItemQty = domainModel.Qty,
            };
        }

        public void MapFromTable(ref CartItemModel domainModel, CarItemTableRecord databaseModel)
        {
            if (domainModel == null)
            {
                domainModel = new CartItemModel();
            }  
            domainModel.SessionId = databaseModel.SessionId;
            domainModel.Qty = databaseModel.SellItemQty;
            domainModel.SellItem.Id = databaseModel.SellItemId;
        }   
    }
}
