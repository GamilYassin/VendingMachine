using System;
using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.EnumerationBase;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.DataAccess.DataMapper
{
    public class CustomerSessionDataMapper : IModelMapper<CustomerSessionModel, CustomerSessionTableRecord>
    {
        public CustomerSessionTableRecord MapFromDomain(CustomerSessionModel domainModel)
        {
            return new CustomerSessionTableRecord()
            {
                Id = domainModel.Id,
                VendingMachineId = domainModel.VendingMachineId,
                BalanceText = domainModel.CustomerBalance.Encode(),
                Status = domainModel.Status.ToString(),
            };
        }

        public void MapFromTable(ref CustomerSessionModel domainModel, CustomerSessionTableRecord databaseModel)
        {
            if (domainModel == null)
            {
                domainModel = new CustomerSessionModel();
            }
            domainModel.Id = databaseModel.Id;
            domainModel.VendingMachineId= databaseModel.VendingMachineId;
            domainModel.Status = Enumeration.FromDisplayName<CustomerSessionStatusEnum>(databaseModel.Status);
            domainModel.CustomerBalance = Balance.Empty.Decode(databaseModel.BalanceText);
        }
    }
}
