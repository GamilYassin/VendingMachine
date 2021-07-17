namespace VendingMachine.DataAccess.Tables
{
    public class SellItemRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Barcode { get; set; }
        public string ItemType { get; set; }
        public int GrandTotal { get; set; }
        public string GrandSellAmount { get; set; }
    }
}