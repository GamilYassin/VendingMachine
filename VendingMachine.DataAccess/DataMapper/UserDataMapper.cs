using VendingMachine.DataAccess.Tables;
using VendingMachine.Domain.Models;
using VendingMachine.Services.EnumerationBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataMapper
{
    public class UserDataMapper : IModelMapper<UserModel, UserTableRecord>
    {
        public UserTableRecord MapFromDomain(UserModel domainModel)
        {
            return new UserTableRecord()
            {
                Id = domainModel.Id,
                UserName = domainModel.UserName,
                UserPassword = domainModel.UserPassword,
                Privilege = domainModel.Privilege.ToString(),
            };
        }

        public void MapFromTable(ref UserModel domainModel, UserTableRecord databaseModel)
        {
            if (domainModel == null)
            {
                domainModel = new UserModel();
            }

            domainModel.Id = databaseModel.Id;
            domainModel.UserName = databaseModel.UserName;
            domainModel.UserPassword = databaseModel.UserPassword;
            domainModel.Privilege = Enumeration.FromDisplayName<UserPrivilegeEnum>(databaseModel.Privilege);
        }
    }
}
