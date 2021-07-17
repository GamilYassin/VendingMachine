using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Enums;
using VendingMachine.Presentation.Context;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.Presentation.ModelMappers;
using VendingMachine.Services.EnumerationBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Presentation.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        #region Methods

        public User FindById(int id)
        {
            UsersModelMapper map = new UsersModelMapper();

            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                UserRecord userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == id).First();

                return map.MapFromTable(userRecord);
            }
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            UsersModelMapper map = new UsersModelMapper();

            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                List<UserRecord> userRecords = dbContext.UserRecords.Select(x => x).ToList();

                foreach (UserRecord item in userRecords)
                {
                    users.Add(map.MapFromTable(item));
                }
            }

            return users;
        }

        public void Commit()
        {
            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                //dbContext.SaveChanges();
            }
        }

        public UserPrivilegeEnum GetUserPrivilege(string userName, string userPass)
        {
            UserPrivilegeEnum privilege;

            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                string userPrivlege = dbContext.UserRecords.Where(x => string.Compare(x.UserName, userName, true) == 0 &&
                                                                    string.Compare(x.UserPassword, userPass, true) == 0)
                                                        .Select(x => x.Privilege).First();
                //Enumumeration.Parse(userPrivlege, out privilege);

                privilege = Enumeration.FromDisplayName<UserPrivilegeEnum>(userPrivlege);
            }

            return privilege;
        }

        public void InsertUser(User user)
        {
            UsersModelMapper map = new UsersModelMapper();
            InsertUser(map.MapFromDomain(user));
        }

        public void InsertUser(UserRecord user)
        {
            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                dbContext.UserRecords.Add(user);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUser(UserRecord user)
        {
            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                UserRecord userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == user.Id).First();

                user.CopyTo(ref userRecord);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            UsersModelMapper map = new UsersModelMapper();
            UpdateUser(map.MapFromDomain(user));
        }

        public void DeleteUser(int id)
        {
            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                UserRecord userRecord = dbContext.UserRecords.Select(x => x).Where(x => x.Id == id).First();

                dbContext.UserRecords.Remove(userRecord);
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            DeleteUser(user.Id);
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public int RecordsCount()
        {
            throw new NotImplementedException();
        }

        public int AddModel(User model, bool commit = false)
        {
            throw new NotImplementedException();
        }

        public bool Contains(User model)
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(User model, bool commit = false)
        {
            throw new NotImplementedException();
        }

        public int DeleteModel(User model, bool commit = false)
        {
            throw new NotImplementedException();
        }

        public int DeleteModelById(int id, bool commit = false)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}