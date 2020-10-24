using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Presentation.DataBaseModels;

namespace VendingMachine.Presentation.Context
{
	public class VendingMachineContext : DbContext
	{
		#region Constructors

		public VendingMachineContext(string connectionString) : base()
		{
			this.connectionString = connectionString;
		}

		#endregion Constructors

		#region Properties

		public DbSet<CellsRecord> CellsRecords { get; set; }
		public DbSet<InsideBalanceRecord> InsideBalanceRecords { get; set; }
		public DbSet<LocationRecord> LocationRecords { get; set; }
		public DbSet<SellItemRecord> SellItemRecords { get; set; }
		public DbSet<UserRecord> UserRecords { get; set; }
		public DbSet<VendingMachineRecord> VendingMachineRecords { get; set; }

		#endregion Properties

		#region Fields

		protected readonly string connectionString;

		#endregion Fields

		#region Methods

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(this.connectionString);
			base.OnConfiguring(optionsBuilder);
		}

		#endregion Methods
	}
}