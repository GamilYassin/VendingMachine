using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.ValueObjects;
using VendingMachine.Presentation.DataBaseModels;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Presentation.ModelMappers
{
	public class SellItemModelMapper : IModelMapper<SellItem, SellItemRecord>
	{
		#region Methods

		public SellItem MapBackward(SellItemRecord databaseModel)
		{
			SellItemType itemType = SellItemType.Food;

			Enum.TryParse(databaseModel.ItemType, true, out itemType);

			SellItem sellItem = new SellItem()
			{
				Id = databaseModel.Id,
				Barcode = databaseModel.Barcode,
				Name = databaseModel.Name,
				Price = Money.MoneyFactory(databaseModel.Price),
				ItemType = itemType,
				GrandTotal = databaseModel.GrandTotal,
				GrandSellAmount = Money.MoneyFactory(databaseModel.GrandSellAmount)
			};

			return sellItem;
		}

		public SellItemRecord MapForward(SellItem domainModel)
		{
			SellItemRecord sellItemRecord = new SellItemRecord()
			{
				Id = domainModel.Id,
				Barcode = domainModel.Barcode,
				Name = domainModel.Name,
				Price = domainModel.Price.MoneyField(),
				ItemType = domainModel.ItemType.ToString(),
				GrandTotal = domainModel.GrandTotal,
				GrandSellAmount = domainModel.GrandSellAmount.MoneyField()
			};

			return sellItemRecord;
		}

		#endregion Methods
	}
}