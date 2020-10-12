using System;
using System.Collections.Generic;

namespace PrintMersion.Core.Entities
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? IdAddress { get; set; }
        public string Phone { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
