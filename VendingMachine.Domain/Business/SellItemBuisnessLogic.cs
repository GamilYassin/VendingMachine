using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Models;

namespace VendingMachine.Domain.Business
{
    class SellItemBuisnessLogic
    {

        //public void Add(List<CartItem> cartItems)
        //{
        //    if (ReferenceEquals(cartItems, null))
        //        throw new NullReferenceException("Cart Items List can not be null");

        //    CartItems.AddRange(cartItems);
        //}

//        public void AddCartItem(CartItem cartItem)
//        {
//            if (ReferenceEquals(cartItem, null))
//                throw new NullReferenceException("Cart Item can not be null");

//            CartItems.Add(cartItem);
//        }

//        public Money CalculateCartAmount()
//        {
//            if (CartItems.Count < 1)
//                return Money.Empty;
//Money cartAmount = new Money();
//            foreach (CartItem item in CartItems)
//            {
//                cartAmount += item.SellItem.Price * item.Qty;
//            }

//            return cartAmount;
//        }
    }
}
