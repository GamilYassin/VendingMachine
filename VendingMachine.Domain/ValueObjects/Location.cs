using VendingMachine.Services.Interfaces;

namespace VendingMachine.Domain.ValueObjects
{
    public class Location : IValueObject
    {
        #region Constructors

        public Location(string street, string city, string landMark)
        {
            Street = street;
            City = city;
            LandMark = landMark;
        }

        public Location() : this(string.Empty, string.Empty, string.Empty)
        {
        }

        #endregion Constructors

        #region Properties

        public string City { get; protected set; }
        public string LandMark { get; protected set; }
        public string Street { get; protected set; }

        #endregion Properties

        #region Methods

        public static Location LocationFactory(string street, string city, string landMark)
        {
            return new Location(street, city, landMark);
        }

        public override string ToString()
        {
            string result;
            result = $"{City}, {Street}";
            if (!string.IsNullOrEmpty(LandMark))
            {
                result = result + $" nearby {LandMark}";
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