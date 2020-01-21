using RentC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Core.ViewModels
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
