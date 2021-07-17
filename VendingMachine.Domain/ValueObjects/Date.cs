using System;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.ValueObjects
{
    public class Date : IValueObject
    {
        #region Fields

        public static readonly Date Now = DateFactory(DateTime.Now);
        public static readonly string DefaultDateFormat = "MM/dd/yyyy";

        #endregion Fields

        #region Constructors

        public Date(DateTime dateVal)
        {
            this.Value = dateVal;
        }

        #endregion Constructors

        #region Properties

        public DateTime Value { get; set; }

        #endregion Properties

        #region Methods

        public static Date DateFactory(DateTime dateVal)
        {
            return new Date(dateVal);
        }

        public static Date DateFactory(int year, int month, int day)
        {
            return new Date(new DateTime(year, month, day));
        }

        public static Date operator +(Date date1, Date date2)
        {
            return DateFactory(date1.Value.Year + date2.Value.Year,
                                date1.Value.Month + date2.Value.Month,
                                date1.Value.Day + date2.Value.Day);
        }

        public static Date operator -(Date date1, Date date2)
        {
            return DateFactory(date1.Value.Year - date2.Value.Year,
                                date1.Value.Month - date2.Value.Month,
                                date1.Value.Day - date2.Value.Day);
        }

        public static bool operator ==(Date date1, Date date2)
        {
            return (date1.Value == date2.Value);
        }

        public static bool operator !=(Date date1, Date date2)
        {
            return !(date1 == date2);
        }

        public Date AddYears(int years)
        {
            return DateFactory(this.Value.Year + years,
                                this.Value.Month, this.Value.Day);
        }

        public Date AddMonths(int months)
        {
            return DateFactory(this.Value.Year,
                                this.Value.Month + months,
                                this.Value.Day);
        }

        public Date AddDays(int days)
        {
            return DateFactory(this.Value.Year,
                                this.Value.Month,
                                this.Value.Day + days);
        }

        public Date SubtractYears(int years)
        {
            return DateFactory(this.Value.Year - years,
                                this.Value.Month, this.Value.Day);
        }

        public Date SubtractMonths(int months)
        {
            return DateFactory(this.Value.Year,
                                this.Value.Month - months,
                                this.Value.Day);
        }

        public Date SubtractDays(int days)
        {
            return DateFactory(this.Value.Year,
                                this.Value.Month,
                                this.Value.Day - days);
        }

        public override string ToString()
        {
            return Value.ToString(DefaultDateFormat);
        }

        public override bool Equals(object obj)
        {
            Date date = this;
            return date == (Date)obj;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public Date Add(Date obj)
        {
            return (this + obj);
        }

        public Date Subtract(Date obj)
        {
            return (this - obj);
        }

        #endregion Methods
    }
}