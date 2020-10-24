﻿using System;
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

		[StringLength(50)]
		public string UserName { get; set; }

		[StringLength(50)]
		public string UserPassword { get; set; }

		[DefaultValue("Customer")]
		public string Privilege { get; set; }

		#endregion Properties
	}
}