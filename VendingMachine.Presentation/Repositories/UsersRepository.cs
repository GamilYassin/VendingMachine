using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Domain.Entities;
using VendingMachine.Presentation.Context;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.Presentation.ModelMappers;
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

                return map.MapBackward(userRecord);
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
                    users.Add(map.MapBackward(item));
                }
            }

            return users;
        }

        public void Commit()
        {
            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                dbContext.SaveChanges();
            }
        }

        public UserPrivilege GetUserPrivilege(string userName, string userPass)
        {
            UserPrivilege privilege;

            using (VendingMachineContext dbContext = VendingMachineContext.InstanceFactory())
            {
                string userPrivlege = dbContext.UserRecords.Where(x => string.Compare(x.UserName, userName, true) == 0 &&
                                                                    string.Compare(x.UserPassword, userPass, true) == 0)
                                                        .Select(x => x.Privilege).First();
                Enum.TryParse(userPrivlege, out privilege);
            }

            return privilege;
        }

        public void InsertUser(User user)
        {
            UsersModelMapper map = new UsersModelMapper();
            InsertUser(map.MapForward(user));
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
            UpdateUser(map.MapForward(user));
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

        #endregion Methods
    }
}