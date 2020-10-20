
using System.Collections.Generic;
using VendingMachine.Domain.BaseClasses;
using VendingMachine.SharedKernel.Interfaces;
using VendingMachine.SharedKernel.ValueObjects;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Entities
{
	public class VendingMachine : Entity, IAggregateRoot
	{
		#region Properties
		public Location VMLocation { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public MaintenanceSchedule VMMaintenanceSchedule { get; set; }
		public Money GrandBalance { get; set; }
		public Money CustomerBalance { get; set; }
		public Balance InsideBalance { get; set; }
		public Date StartDate { get; set; }
		public IList<Cell> Cells { get; set; }
		public VMState State { get; set; }

		#endregion Properties
	}
}