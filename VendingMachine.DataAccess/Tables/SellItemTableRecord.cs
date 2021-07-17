using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class SellItemTableRecord: ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Barcode { get; set; }
        public string ItemType { get; set; }


        public SellItemTableRecord(int id, string name, string price, string barcode, string itemType)
        {
            Id= id;
            Name= name;
            Price= price;
            Barcode= barcode;
            ItemType= itemType;
        }

        public SellItemTableRecord(): this(0,string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }
    }
}