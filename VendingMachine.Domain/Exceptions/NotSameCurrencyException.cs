using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Exceptions
{
	public class NotSameCurrencyException : Exception
	{
		#region Constructors

		public NotSameCurrencyException() : this("Can not operate in 2 money values with different currencies")
		{
		}

		public NotSameCurrencyException(string message) : base(message)
		{
		}

		#endregion Constructors
	}
}