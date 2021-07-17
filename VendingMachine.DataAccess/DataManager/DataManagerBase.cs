using System.Collections.Generic;
using VendingMachine.Services.DataBase;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.DataManager
{
    public abstract class DataManagerBase<T> : IDataManager<T> where T : ITable
    {
        protected string ConnectionIdentifier { get; set; }

        protected DataManagerBase()
        {
            ConnectionIdentifier = DataBaseServices.GetConnectionIdentifier();
        }

        public abstract int Delete(T model);
        public abstract List<T> FindAll();
        public abstract T FindById(int id);
        public abstract int Insert(T model);
        public abstract int Update(T model);
        public abstract int Insert(IEnumerable<T> models);
        public abstract int Update(IEnumerable<T> models);
        public abstract int Delete(IEnumerable<T> models);
    }
}
