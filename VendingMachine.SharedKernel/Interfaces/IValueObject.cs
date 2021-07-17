using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Services.Interfaces
{
	public interface IValueObject
	{
		#region Methods

		string ToString();

		bool Equals(object obj);

		#endregion Methods
	}
}