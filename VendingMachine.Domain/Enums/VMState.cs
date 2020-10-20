using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.SharedKernel.Enums
{
	public enum VMState
	{
		Starting,
		Operational,
		OnHold,
		OnMaintenance,
		Defect,
	}
}