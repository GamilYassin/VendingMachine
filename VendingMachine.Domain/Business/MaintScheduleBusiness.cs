using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Models;
using VendingMachine.Services.Utils;

namespace VendingMachine.Domain.Business
{
    class MaintScheduleBusiness
    {

        public static MaintenanceSchedule MaintenanceScheduleFactory(int frequency, Date dateVal)
        {
            return new MaintenanceSchedule(frequency, dateVal);
        }

        //public Date GetNextMaintDate()
        //{
        //    return LastMaintDate.AddDays(Frequency);
        //}
    }
}
