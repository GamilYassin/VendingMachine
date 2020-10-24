using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VendingMachine.Presentation.Context
{
	public class VendingMachineContextFactory : IDesignTimeDbContextFactory<VendingMachineContext>
	{
		#region Fields

		public static string Default_Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
						@"AttachDbFilename=C:\Users\Gemi\source\repos\VendingMachine\VendingMachine.Presentation\DataBase\MasterDataBase.mdf;" +
						"Integrated Security=True";

		#endregion Fields

		#region Methods

		public VendingMachineContext CreateDbContext(string[] args)
		{
			return VendingMachineContext.InstanceFactory(Default_Connection);
		}

		#endregion Methods
	}
}