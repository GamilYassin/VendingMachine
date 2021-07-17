using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
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

        public void MapFromTable(ref VendingMachineModel domainModel, VendingMachineTableRecord databaseModel)
{
            domainModel.Id = databaseModel.Id;
            domainModel.Model = databaseModel.Model;
            domainModel.Manufacturer = databaseModel.Manufacturer;
            domainModel.StartDate = new Date(databaseModel.StartDate);
            domainModel.VMMaintenanceSchedule = new MaintenanceSchedule(databaseModel.Frequency, new Date(databaseModel.StartDate));
            domainModel.GrandBalanceAmount = Money.MoneyFactory(databaseModel.GrandBalance);
            domainModel.State = Enumeration.FromDisplayName<VendingMachineStateEnum>(databaseModel.State);
        }
    }
}
