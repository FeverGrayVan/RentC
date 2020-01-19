using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Core.Models
{
    public class Client : BaseEntity
    {
        public string ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public int ZipCode { get; set; }

    }
}
