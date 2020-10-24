using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Presentation.Exceptions
{
	public class NullConnectionStringException : Exception
	{
		#region Constructors

		public NullConnectionStringException() : this("Connection String is Null")
		{
		}

		public NullConnectionStringException(string message) : base(message)
		{
		}

		#endregion Constructors
	}
}