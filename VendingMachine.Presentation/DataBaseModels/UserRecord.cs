using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace VendingMachine.Presentation.DataBaseModels
{
	public class UserRecord
	{
		#region Properties

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string UserName { get; set; }

		[StringLength(50)]
		public string UserPassword { get; set; }

		[DefaultValue("Customer")]
		[MaxLength(50)]
		[Required]
		public string Privilege { get; set; }

		#endregion Properties

		#region Methods

		public void CopyTo(ref UserRecord dbRecord)
		{
			dbRecord.UserName = UserName;
			dbRecord.UserPassword = UserPassword;
			dbRecord.Privilege = Privilege;
		}

		#endregion Methods
	}
}