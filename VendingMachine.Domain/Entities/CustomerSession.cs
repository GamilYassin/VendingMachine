using System;
using System.Collections.Generic;
using VendingMachine.Domain.Base;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.ValueObjects
{
    public class CustomerSession : EntityBase
    {
        public Balance CustomerBalance { get; set; }
        public CustomerSessionStatusEnum Status { get; set; }
        public List<CartItem> CartItems { get; }

        public CustomerSession() : this(Balance.Empty)
        {
        }

        public CustomerSession(Balance custBalance, CustomerSessionStatusEnum custStatus)
        {
            CartItems = new List<CartItem>();
            Status = custStatus;
        }

        public CustomerSession(Balance custBalance) : this(custBalance, CustomerSessionStatusEnum.Active)
        {
        }

        public override string ToString()
        {
            return $"Status: {Status.ToString()} Balance Amount: {CustomerBalance.ToString()}";
        }

        public void Add(List<CartItem> cartItems)
        {
            if (ReferenceEquals(cartItems, null))
                throw new NullReferenceException("Cart Items List can not be null");

            CartItems.AddRange(cartItems);
        }

        public void AddCartItem(CartItem cartItem)
        {
            if (ReferenceEquals(cartItem, null))
                throw new NullReferenceException("Cart Item can not be null");

            CartItems.Add(cartItem);
        }

        public Money CalculateCartAmount()
        {
            if (CartItems.Count < 1)
                return Money.Empty;

            Money cartAmount = new Money();
            foreach (CartItem item in CartItems)
            {
                cartAmount += item.SellItem.Price * item.Qty;
            }

            return cartAmount;
        }
    }
}