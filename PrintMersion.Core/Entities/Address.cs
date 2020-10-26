using PrintMersion.Core.Interfaces;
using System.Collections.Generic;

namespace PrintMersion.Core.Entities
{
    public class Address : IEntity
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string InteriorNumber { get; set; }
        public string ExteriorNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
