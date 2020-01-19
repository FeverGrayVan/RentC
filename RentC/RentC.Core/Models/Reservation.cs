using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Core.Models
{
    public class Reservation : BaseEntity
    {
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public float ReservStatsID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Location { get; set; }
        public string CouponCode { get; set; }

    }
}
