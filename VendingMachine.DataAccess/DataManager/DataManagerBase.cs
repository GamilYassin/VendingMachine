using System.Collections.Generic;
using VendingMachine.Services.DataBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataManager
{
    public abstract class DataManagerBase<T> : IDataManager<T> where T : IEntity, new()
    {
        public string ConnectionIdentifier { get; protected set; }

        protected DataManagerBase()
        {
            ConnectionIdentifier = DataBaseServices.GetConnectionIdentifier();
        }

        public abstract int Delete(T model);
        public abstract List<T> FindAll(string tableName);
        public abstract T FindById(int id);
        public abstract int Insert(T model);
        public abstract int Update(T model);
    }
}
