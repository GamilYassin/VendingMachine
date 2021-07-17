﻿namespace VendingMachine.Domain.Models
{
    public class Location
    {
        #region Constructors

        public Location(int vmId,  string street, string city, string landMark)
        {
            VendingMachineId = vmId;
            Street = street;
            City = city;
            LandMark = landMark;
        }

        public Location() : this(0,string.Empty, string.Empty, string.Empty)
        {
        }

        #endregion Constructors

        #region Properties

        public string City { get; set; }
        public string LandMark { get; set; }
        public string Street { get; set; }
        public int VendingMachineId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            string result;
            result = $"{City}, {Street}";
            if (!string.IsNullOrEmpty(LandMark))
            {
                result += $" nearby {LandMark}";
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            Location otherLocation = (Location)obj;

            return (string.Compare(Street, otherLocation.Street, true) == 0)
                    && (string.Compare(City, otherLocation.City, true) == 0)
                    && (string.Compare(LandMark, otherLocation.LandMark, true) == 0);
        }

        public override int GetHashCode()
        {
            return Street.GetHashCode() * City.GetHashCode() * LandMark.GetHashCode();
        }


        #endregion Methods
    }
}