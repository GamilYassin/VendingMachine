using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.SharedKernel.ValueObjects
{
	public class Location : IValueObject
	{
		#region Constructors

		public Location(string street, string city, string landMark)
		{
			this.Street = street;
			this.City = city;
			this.LandMark = landMark;
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
			result = $"{this.City}, {this.Street}";
			if (!string.IsNullOrEmpty(this.LandMark))
			{
				result = result + $" nearby {this.LandMark}";
			}
			return result;
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