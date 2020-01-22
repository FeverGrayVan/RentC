using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Core.Models
{
    public class Reservation : BaseEntity
    {
        [Required]
        [Display(Name = "Car Plate")]
        public string CarID { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerID { get; set; }
        public string ReservStatsID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Car Rent Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Car Rent End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        public string Location { get; set; }
        [Display(Name = "Coupon Code")]
        public string CouponCode { get; set; }

    }
}
