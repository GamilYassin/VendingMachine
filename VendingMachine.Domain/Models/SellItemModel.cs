using VendingMachine.Domain.Base;
using VendingMachine.Domain.Enums;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.Domain.Models
{
    public class SellItemModel : EntityBase, IAggregateRoot
    {
        #region Constructors

        public SellItemModel(): this(0, string.Empty, Money.Empty, string.Empty, SellItemTypeEnum.Food,0,Money.Empty)
        {
        }

        public SellItemModel(int id, string name, Money price, string barCode, SellItemTypeEnum itemType, int grandTotal, Money grandAmount)
        {
            Id = id;
            Name = name;
            Price = price;
            Barcode = barCode;
            ItemType = itemType;
            GrandTotal = grandTotal;
            GrandSellAmount = grandAmount;
        }


        #endregion Constructors

        #region Properties

        public string Name { get; set; }
        public Money Price { get; set; }
        public string Barcode { get; set; }
        public SellItemTypeEnum ItemType { get; set; }
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