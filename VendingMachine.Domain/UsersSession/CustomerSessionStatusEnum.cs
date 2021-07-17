using System.ComponentModel;
using VendingMachine.Services.EnumerationBase;

namespace VendingMachine.Domain.Models
{
    public class CustomerSessionStatusEnum: Enumeration
    {
        public CustomerSessionStatusEnum(int value, string displayName): base(value, displayName)
        {

        }

        public static CustomerSessionStatusEnum Active=new CustomerSessionStatusEnum(1,"Active");
        public static CustomerSessionStatusEnum Completed = new CustomerSessionStatusEnum(2, "Completed");
        public static CustomerSessionStatusEnum Cancelled = new CustomerSessionStatusEnum(3, "Cancelled");
    }
}