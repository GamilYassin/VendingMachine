using System.Collections.Generic;


namespace VendingMachine.Domain.Entities
{
    public class Cart: Entity
    {
        public List<SellItem> LineItems{get; set;}= new List<SellItem>();

        public void AddLineItem(SellItem item){
            this.LineItems.Add(item);
        }

        public void RemoveLineItem(Sell item){
            this.LineItems.Remove(item);
        }
    }
}