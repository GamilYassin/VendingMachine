using System.Collections.Generic;
using VendingMachine.DataAccess.DataManager;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.UnitOfWork
{
    public class SqlUnitofWorkBase<T> : IUnitOFWork<T> where T : ITable
    {
        protected List<T> newModels;
        protected List<T> changedModel;
        protected List<T> deletedModels;
        protected SqlDataManager<T> sqlDataManager;

        public SqlUnitofWorkBase() : base()
        {
            newModels = new List<T>();
            changedModel = new List<T>();
            deletedModels = new List<T>();
            sqlDataManager = new SqlDataManager<T>();
        }

        ~SqlUnitofWorkBase()
        {
            if (!IsCommitted())
            {
                Commit();
            }
        }

        public int AddModel(T model, bool commit = false)
        {
            RegisterNew(model);
            if (commit)
                return Commit();
            return 1;
        }

        public int Commit()
        {
            int affected = 0;
            if (newModels != null)
            {
                affected += sqlDataManager.Insert(newModels);
            }

            if (deletedModels != null)
            {
                affected += sqlDataManager.Delete(deletedModels);
            }

            if (changedModel != null)
            {
                affected += sqlDataManager.Update(changedModel);
            }
            return affected;
        }

        public bool Contains(T model)
        {
            return sqlDataManager.Contains(model);
        }

        public int DeleteModel(T model, bool commit = false)
        {
            RegisterDeleted(model);
            if (commit)
                return Commit();
            return 1;
        }

        public int DeleteModelById(int id, bool commit = false)
        {
            T model = sqlDataManager.FindById(id);
            if (model != null)
            {
                return DeleteModel(model);
            }
            return 0;
        }

        public IEnumerable<T> FindAll()
        {
            return sqlDataManager.FindAll();
        }

        public T FindById(int id)
        {
            return sqlDataManager.FindById(id);
        }

        public bool IsCommitted()
        {
            bool isNewEmpty = newModels.Count > 0;
            bool isChangedEmpty = changedModel.Count > 0;
            bool isDeletedEmpty = deletedModels.Count > 0;

            return isNewEmpty && isChangedEmpty && isDeletedEmpty;
        }

        public int RecordsCount()
        {
            return sqlDataManager.RecordsCount();
        }

        protected void RegisterChanged(T model)
        {
            changedModel.Add(model);
        }

        protected void RegisterDeleted(T model)
        {
            deletedModels.Add(model);
        }

        protected void RegisterNew(T model)
        {
            newModels.Add(model);
        }

        public int UpdateModel(T model, bool commit = false)
        {
            RegisterChanged(model);
            if (commit)
                return Commit();
            return 1;
        }
    }
}
