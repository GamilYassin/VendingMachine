using VendingMachine.Domain.Base;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.Domain.Models
{
    public class SellItemModel : EntityBase, IAggregateRoot
    {
        #region Constructors

        public SellItemModel() : this(0, string.Empty, Money.Empty, string.Empty, SellItemTypeEnum.Food)
        {
        }

        public SellItemModel(int id, string name, Money price, string barCode, SellItemTypeEnum itemType)
        {
            Id = id;
            Name = name;
            Price = price;
            Barcode = barCode;
            ItemType = itemType;
        }


        #endregion Constructors

        #region Properties

        public string Name { get; set; }
        public Money Price { get; set; }
        public string Barcode { get; set; }
        public SellItemTypeEnum ItemType { get; set; }


        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"Item Name: {Name} Price: {Price}";
        }

        #endregion Methods
    }
}