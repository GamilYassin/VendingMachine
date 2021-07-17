using System.Collections.Generic;
using VendingMachine.Domain.Base;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.Entities
{
    public class VendingMachineModel : EntityBase, IAggregateRoot
    {
        #region Properties

        public Location VMLocation { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public MaintenanceSchedule VMMaintenanceSchedule { get; set; }
        public Money GrandBalanceAmount { get; set; }
        public Balance InsideBalance { get; set; }
        public Date StartDate { get; set; }
        public IList<Cell> Cells { get; set; }
        public VendingMachineStateEnum State { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer}, {Model}, {VMLocation}";
        }

        #endregion Properties
    }
}