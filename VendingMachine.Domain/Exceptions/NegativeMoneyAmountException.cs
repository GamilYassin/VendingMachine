using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Exceptions
{
	public class NegativeMoneyAmountException : Exception
	{
		#region Constructors

		public NegativeMoneyAmountException() : this("Money can not have -ve Amount value")
		{
		}

		public NegativeMoneyAmountException(string message) : base(message)
		{
		}

		#endregion Constructors
	}
}