using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? IdAddress { get; set; }
        public string Phone { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
