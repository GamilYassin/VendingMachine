using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Services.EnumerationBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class VendingMachineMapper : IModelMapper<VendingMachineModel, VendingMachineTableRecord>
    {
        public VendingMachineModel MapFromTable(VendingMachineTableRecord databaseModel)
        {
            return new VendingMachineModel()
            {
                Id = databaseModel.Id,
                Model = databaseModel.Model,
                Manufacturer = databaseModel.Manufacturer,
                StartDate = new Date(databaseModel.StartDate),
                VMMaintenanceSchedule = new MaintenanceSchedule(databaseModel.Frequency, new Date(databaseModel.StartDate)),
                GrandBalanceAmount = Money.MoneyFactory(databaseModel.GrandBalance),
                State = Enumeration.FromDisplayName<VendingMachineStateEnum>(databaseModel.State),
            };
        }

        public VendingMachineTableRecord MapFromDomain(VendingMachineModel domainModel)
        {
            return new VendingMachineTableRecord()
            {
                Id = domainModel.Id,
                Model = domainModel.Model,
                Manufacturer = domainModel.Manufacturer,
                StartDate = domainModel.StartDate.Value,
                Frequency = domainModel.VMMaintenanceSchedule.Frequency,
                LastMaintDate = domainModel.VMMaintenanceSchedule.LastMaintDate.Value,
                GrandBalance = domainModel.GrandBalanceAmount.ToString(),
                State = domainModel.State.DisplayName,
            };
        }
    }
}
