namespace VendingMachine.DataAccess.Tables
{
    public class UserRecord
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Privilege { get; set; }

    }
}