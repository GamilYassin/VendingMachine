using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Enums;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.SharedKernel.Interfaces;

namespace VendingMachine.Presentation.ModelMappers
{
	public class UsersModelMapper : IModelMapper<User, UserRecord>
	{
		#region Methods

		public User MapBackward(UserRecord databaseModel)
		{
			UserPrivilege privilege;

			User user = new User()
			{
				Id = databaseModel.Id,
				UserName = databaseModel.UserName,
				UserPassword = databaseModel.UserPassword
			};

			Enum.TryParse(databaseModel.Privilege, true, out privilege);
			user.Privilege = privilege;

			return user;
		}

		public UserRecord MapForward(User domainModel)
		{
			UserRecord userRecord = new UserRecord()
			{
				Id = domainModel.Id,
				UserName = domainModel.UserName,
				UserPassword = domainModel.UserPassword,
				Privilege = domainModel.Privilege.ToString()
			};

			return userRecord;
		}

		#endregion Methods
	}
}