namespace VendingMachine.Services.Interfaces
{
    public interface IUnitOFWork<T> where T : ITable
    {
        void RegisterNew(T model);
        void RegisterChanged(T model);
        void RegisterDeleted(T model);
        bool IsCommitted();
        void Commit();
    }
}
