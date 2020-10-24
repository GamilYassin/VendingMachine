using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Exceptions
{
	internal class NotSameSellItemException : Exception
	{
		#region Constructors

		public NotSameSellItemException() : this("The 2 Cart Items should have same sell item")
		{
		}

		public NotSameSellItemException(string message) : base(message)
		{
		}

		#endregion Constructors
	}
}