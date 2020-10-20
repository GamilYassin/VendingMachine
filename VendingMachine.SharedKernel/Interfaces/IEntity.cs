using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.SharedKernel.Interfaces
{
	public interface IEntity
	{
		#region Properties

		int Id { get; set; }

		#endregion Properties
	}
}