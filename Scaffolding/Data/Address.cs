using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string InteriorNumber { get; set; }
        public string ExteriorNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
