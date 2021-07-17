using VendingMachine.Domain.Base;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.ValueObjects
{
    public class SellItem : EntityBase
    {
        #region Constructors

        public SellItem()
        {
        }

        public SellItem(string name, Money price, string barCode, SellItemType itemType, int grandTotal, Money grandAmount)
        {
            this.Name = name;
            this.Price = price;
            this.Barcode = barCode;
            this.ItemType = itemType;
            this.GrandTotal = grandTotal;
            this.GrandSellAmount = grandAmount;
        }

        public SellItem(string name) : this(name, new Money(), string.Empty, SellItemType.Food, 0, new Money())
        {
        }

        #endregion Constructors

        #region Properties

        public string Name { get; set; }
        public Money Price { get; set; }
        public string Barcode { get; set; }
        public SellItemType ItemType { get; set; }
        public int GrandTotal { get; set; }
        public Money GrandSellAmount { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"Item Name: {Name} Price: {Price}";
        }

        #endregion Methods
    }
}