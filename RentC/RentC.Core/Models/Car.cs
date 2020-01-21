using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Core.Models
{
    public class Car : BaseEntity
    {
        public string Plate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string PricePerDay { get; set; }
    }
}
