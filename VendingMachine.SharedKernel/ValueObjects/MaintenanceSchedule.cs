using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.SharedKernel.ValueObjects
{
	public class MaintenanceSchedule : IValueObject
	{
		#region Fields

		public static readonly int DefaultFrequency = 30;

		#endregion Fields

		#region Constructors

		public MaintenanceSchedule(int frequency, Date lastMaintDate)
		{
			this.Frequency = frequency;
			this.LastMaintDate = lastMaintDate;
		}

		public MaintenanceSchedule() : this(DefaultFrequency, Date.Now)
		{
		}

		public MaintenanceSchedule(int frequency) : this(frequency, Date.Now)
		{
		}

		#endregion Constructors

		#region Properties

		public int Frequency { get; set; }
		public Date LastMaintDate { get; set; }

		#endregion Properties

		#region Methods

		public static MaintenanceSchedule MaintenanceScheduleFactory(int frequency, Date dateVal)
		{
			return new MaintenanceSchedule(frequency, dateVal);
		}

		public Date GetNextMaintDate()
		{
			return this.LastMaintDate.AddDays(this.Frequency);
		}

		public override string ToString()
		{
			return $"Next Maintenance Date: {GetNextMaintDate().ToString()}";
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#endregion Methods
	}
}