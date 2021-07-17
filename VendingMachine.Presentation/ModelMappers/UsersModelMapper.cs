using System;
using VendingMachine.Domain.Entities;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Presentation.ModelMappers
{
    public class UsersModelMapper : IModelMapper<User, UserRecord>
    {
        #region Methods

        public User MapFromTable(UserRecord databaseModel)
        {

            User user = new User()
            {
                Id = databaseModel.Id,
                UserName = databaseModel.UserName,
                UserPassword = databaseModel.UserPassword
            };

            Enum.TryParse(databaseModel.Privilege, true, out UserPrivilege privilege);
            user.Privilege = privilege;

            return user;
        }

        public UserRecord MapFromDomain(User domainModel)
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