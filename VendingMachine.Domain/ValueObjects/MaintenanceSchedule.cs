using System;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.ValueObjects
{
    public class MaintenanceSchedule : IValueObject
    {
        #region Fields

        public static readonly int DefaultFrequency = 30;

        #endregion Fields

        #region Constructors

        public MaintenanceSchedule(int frequency, Date lastMaintDate)
        {
            Frequency = frequency;
            LastMaintDate = lastMaintDate;
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
            return LastMaintDate.AddDays(Frequency);
        }

        public override string ToString()
        {
            return $"Next Maintenance Date: {GetNextMaintDate().ToString()}";
        }

        public override bool Equals(object obj)
        {
            MaintenanceSchedule schedule = (MaintenanceSchedule)obj;
            return (Frequency == schedule.Frequency)
                && (LastMaintDate == schedule.LastMaintDate);
        }

        public override int GetHashCode()
        {
            return Frequency.GetHashCode() ^ LastMaintDate.GetHashCode();
        }


        #endregion Methods
    }
}