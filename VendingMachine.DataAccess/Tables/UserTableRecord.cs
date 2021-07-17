using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class UserTableRecord: ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Privilege { get; set; }

        public UserTableRecord(int id, string name, string password, string privilege)
        {
            Id=id;
            UserName=name;
            UserPassword=password;
            Privilege = privilege;
        }

        public UserTableRecord(): this(0,string.Empty,string.Empty,string.Empty)
        {

        }
    }
}