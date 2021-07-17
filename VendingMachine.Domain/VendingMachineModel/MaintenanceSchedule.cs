using System;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.Domain.Models
{
    public class MaintenanceSchedule
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

       

        public override string ToString()
        {
            return $"Last Maintenance Date {LastMaintDate}";
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