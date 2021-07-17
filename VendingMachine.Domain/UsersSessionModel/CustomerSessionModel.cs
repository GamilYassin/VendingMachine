using System;
using System.Collections.Generic;
using VendingMachine.Domain.Base;
using VendingMachine.Domain.Enums;
using VendingMachine.Services.Interfaces;
using VendingMachine.Services.Utils;

namespace VendingMachine.Domain.Models

{
    public class CustomerSessionModel : EntityBase, IAggregateRoot
    {
        public Balance CustomerBalance { get; set; }
        public CustomerSessionStatusEnum Status { get; set; }
        public List<CartItem> CartItems { get; }

        public CustomerSessionModel() : this(Balance.Empty)
        {

        }

        public CustomerSessionModel(Balance custBalance, CustomerSessionStatusEnum custStatus)
        {
            CartItems = new List<CartItem>();
            Status = custStatus;
        }

        public CustomerSessionModel(Balance custBalance) : this(custBalance, CustomerSessionStatusEnum.Active)
        {
        }

        public override string ToString()
        {
            return $"Status: {Status.ToString()} Balance Amount: {CustomerBalance.ToString()}";
        }


    }
}