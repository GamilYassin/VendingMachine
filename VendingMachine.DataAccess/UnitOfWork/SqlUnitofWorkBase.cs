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

        public void Commit()
        {
            if (newModels != null)
            {
                _ = sqlDataManager.Insert(newModels);
            }

            if (deletedModels != null)
            {
                _ = sqlDataManager.Delete(deletedModels);
            }

            if (changedModel != null)
            {
                _ = sqlDataManager.Update(changedModel);
            }
        }

        public bool IsCommitted()
        {
            bool isNewEmpty = newModels.Count > 0;
            bool isChangedEmpty = changedModel.Count > 0;
            bool isDeletedEmpty = deletedModels.Count > 0;

            return isNewEmpty && isChangedEmpty && isDeletedEmpty;
        }

        public void RegisterChanged(T model)
        {
            changedModel.Add(model);
        }

        public void RegisterDeleted(T model)
        {
            deletedModels.Add(model);
        }

        public void RegisterNew(T model)
        {
            newModels.Add(model);
        }
    }
}
