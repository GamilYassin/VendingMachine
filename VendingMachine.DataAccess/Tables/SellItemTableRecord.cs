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
        public int GrandTotal { get; set; }
        public string GrandSellAmount { get; set; }

        public SellItemTableRecord(int id, string name, string price, string barcode, string itemType, int grandTotal, string grandAmount)
        {
            Id= id;
            Name= name;
            Price= price;
            Barcode= barcode;
            ItemType= itemType;
            GrandTotal= grandTotal;
            GrandSellAmount= grandAmount;
        }

        public SellItemTableRecord(): this(0,string.Empty, string.Empty, string.Empty, string.Empty,0, string.Empty)
        {

        }
    }
}