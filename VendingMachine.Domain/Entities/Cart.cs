using System.Collections.Generic;
using VendingMachine.Domain.BaseClasses;

namespace VendingMachine.Domain.Entities
{
	public class Cart : Entity
	{
		public List<SellItem> LineItems { get; set; } = new List<SellItem>();

		public void AddLineItem(SellItem item)
		{
			this.LineItems.Add(item);
		}

		public void RemoveLineItem(SellItem item)
		{
			this.LineItems.Remove(item);
		}
	}
}