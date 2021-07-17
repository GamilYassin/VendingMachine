using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.Presentation.Exceptions;

namespace VendingMachine.Presentation.Context
{
	public sealed class VendingMachineContext : DbContext
	{
		#region Properties

		public DbSet<CellsRecord> CellsRecords { get; set; }

		public DbSet<InsideBalanceRecord> InsideBalanceRecords { get; set; }

		public DbSet<LocationRecord> LocationRecords { get; set; }

		public DbSet<SellItemRecord> SellItemRecords { get; set; }

		public DbSet<UserRecord> UserRecords { get; set; }

		public DbSet<VendingMachineRecord> VendingMachineRecords { get; set; }

		#endregion Properties

		#region Methods

		public static VendingMachineContext InstanceFactory(string connectionString)
		{
			if (instance == null)
				instance = new VendingMachineContext();

			instance.connectionString = connectionString;
			return instance;
		}

		public static VendingMachineContext InstanceFactory()
		{
			if (instance == null)
				instance = new VendingMachineContext();

			if (String.IsNullOrEmpty(instance.connectionString))
				throw new NullConnectionStringException();

			return instance;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString);
			base.OnConfiguring(optionsBuilder);
		}

		#endregion Methods

		#region Fields

		private static VendingMachineContext instance;
		private string connectionString;

		#endregion Fields

		#region Constructors

		private VendingMachineContext() : base()
		{
		}

		private VendingMachineContext(string connectionString) : base()
		{
			this.connectionString = connectionString;
		}

		#endregion Constructors
	}
}